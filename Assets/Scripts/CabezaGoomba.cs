using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CabezaGoomba : MonoBehaviour
{
    public GameObject goomba;
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
            collision.gameObject.GetComponent<Salto>().AutoJump();
            GameManager.instance.puntuacion += GameManager.instance.puntosEnemgos;
            Destroy(goomba);
        }
    }
   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Salto>().AutoJump();
            GameManager.instance.puntuacion += GameManager.instance.puntosEnemgos;
            Destroy(goomba);            
        }
    }*/
}

