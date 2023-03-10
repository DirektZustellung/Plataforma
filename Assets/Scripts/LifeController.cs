using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    public int lifes_current;
    public int lifes_max;
    public float invencible_time;
    bool invencible;

    public enum DeathMode { Teleport, ReloadScene, Destroy}
    public DeathMode death_mode;
    public Transform respawn;
    Rigidbody2D rb;
    Animator anim;
    public AudioSource powerSource;



    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        lifes_current = lifes_max;
        anim = GetComponent<Animator>();
        
    }

    public void Damage(int damage = 1, bool ignoreInvencible = false)
    {
        if (!invencible || ignoreInvencible)
        {
            if (GameManager.instance.powerUp)
            {
                GameManager.instance.powerUp = false;
                powerSource.Play();
                anim.SetBool("upgrading", GameManager.instance.powerUp);
                //rb.gameObject.SetActive(false);
                gameObject.GetComponent<PlayerConfig>().MarioConfig();
                StartCoroutine(Invencible_Corutine());
                
            }
            else
            {
                lifes_current -= damage;
                StartCoroutine(Invencible_Corutine());
                if(lifes_current <=0)
                {
                    StartCoroutine(Death_Time());
                    GameManager.instance.vidas--;
                    
                }

            }
            gameObject.GetComponent<PlayerConfig>().MarioConfig();
        }
        if (ignoreInvencible)
        {
            GameManager.instance.powerUp = false;
            gameObject.GetComponent<PlayerConfig>().MarioConfig();
            StartCoroutine(Death_Time());
        }
    }
    public void Death()
    {
        switch (death_mode)
        {
            case DeathMode.Teleport:
                rb.velocity = new Vector2(0, 0);
                transform.position = respawn.position;
                lifes_current = lifes_max;
                GameManager.instance.key = false;
                GameManager gameManager = FindObjectOfType<GameManager>();
                gameManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
            case DeathMode.ReloadScene:
                break;
            case DeathMode.Destroy:
                Destroy(gameObject);
                break;
            default:
                break;
        }

    }
    IEnumerator Invencible_Corutine()
    {
        invencible = true;  
        yield return new WaitForSeconds(invencible_time);
        invencible = false;
    }
    IEnumerator Death_Time()
    {
        anim.SetBool("death", true);
        gameObject.GetComponent<MovimientoHorizontal>().enabled = false;
        yield return new WaitForSeconds(.3f);
        Death();
        anim.SetBool("death", false);
        gameObject.GetComponent<MovimientoHorizontal>().enabled =true;  
    }
}
