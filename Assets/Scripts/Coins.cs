using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.coins ==10)
        {
            GameManager.instance.coins = 0;
            GameManager.instance.vidas++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioSource.Play();

            GameManager.instance.puntuacion += GameManager.instance.puntosCoin;
            GameManager.instance.coins++;
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            
            Destroy(gameObject, 0.9f);

            
        }

    }
}
