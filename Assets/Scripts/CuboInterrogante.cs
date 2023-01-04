using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
 


public class CuboInterrogante : MonoBehaviour
{
    public GameObject coin;
    public bool setaActive;
    public bool keyActive;
    public GameObject cuboUsado;
    public GameObject Seta;
    public GameObject cubo;
    public Transform puntoSalidaSeta;
    public GameObject Key;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            
            if (!cuboUsado.activeSelf)
            {
                if (!setaActive && !keyActive)
                {
                    coin.SetActive(true);
                }
                if (setaActive)
                {

                    GameObject temp1 = Instantiate(Seta, puntoSalidaSeta.position, puntoSalidaSeta.rotation);

                }
                if (keyActive)
                {
                    Key.SetActive(true);
                    Destroy(Key, 0.6f);
                    GameManager.instance.key = true;
                }
            }
            
            cuboUsado.SetActive(true);
        }
    }
    
}
