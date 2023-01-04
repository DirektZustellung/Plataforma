using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLogic : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject Cubo;
    

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
                collision.gameObject.GetComponent<Animator>().SetBool("upgrading", GameManager.instance.powerUp);
                collision.gameObject.GetComponent<PlayerConfig>().MarioConfig();
                Destroy(gameObject);
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


        }

    }
    IEnumerator PausaDoor()
    {

        yield return new WaitForSeconds(1.2f);
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

    }
}
