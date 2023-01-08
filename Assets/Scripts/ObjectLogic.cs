using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLogic : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject Cubo;
    
    public AudioSource powerSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Seta")
            {
                GameManager.instance.powerUp = true;
                powerSource.Play();
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;

                collision.gameObject.GetComponent<Animator>().SetBool("upgrading", GameManager.instance.powerUp);
                collision.gameObject.GetComponent<PlayerConfig>().MarioConfig();
                Destroy(gameObject, 0.8f);
            }
            if (gameObject.tag == "Cubo" && GameManager.instance.powerUp)
            {
                
                GameObject temp = Instantiate(Explosion, transform.position, transform.rotation);
                Destroy(temp, 1.5f);
                Destroy(Cubo);
            }
            if (gameObject.tag == "Door" && GameManager.instance.key)
            {
                GameManager.instance.key = false;
                gameObject.GetComponent<Animator>().SetBool("Open", true);
                StartCoroutine(PausaDoor());

            }
            if (gameObject.tag == "Flag")
            {
                collision.gameObject.GetComponent<MovimientoHorizontal>().enabled = false;
                collision.gameObject.GetComponent<Salto>().enabled = false;
                GameManager.instance.win = true;

            }
            if (gameObject.tag == "Finish")
            {
                
                GameManager.instance.finish = true;
            }

        }

    }
    IEnumerator PausaDoor()
    {

        yield return new WaitForSeconds(1.2f);
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

    }
}
