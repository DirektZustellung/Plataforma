using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject win;
    public GameObject key;
    public GameObject moneda;
    public GameObject life;
    public TextMeshProUGUI puntuacion;
    public TextMeshProUGUI vida;
    public TextMeshProUGUI coin;
    public GameObject puntos;
    public GameObject pausa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puntuacion.text = GameManager.instance.puntuacion.ToString();
        vida.text = GameManager.instance.vidas.ToString();
        coin.text = GameManager.instance.coins.ToString();


        if(GameManager.instance.key)
        {
            key.gameObject.SetActive(true);
        }
        
        if(GameManager.instance.vidas <= 0)
        {
            gameObject.GetComponent<AudioSource>().Stop();
            gameOver.SetActive(true);
            life.gameObject.SetActive(false);
            moneda.gameObject.SetActive(false);
            key.gameObject.SetActive(false);
            puntos.gameObject.SetActive(false);
            
            Time.timeScale = 0;
            if (Input.anyKeyDown)
            {
                Destroy (GameManager.instance.gameObject);
                SceneManager.LoadScene(0);
            }
            Time.timeScale = 1;
        }
      /*  if(GameManager.instance.win)
        {
            GameManager.instance.GetComponent<MovimientoHorizontal>().enabled = false;
            GameManager.instance.GetComponent<Salto>().enabled = false; 

        }
      */
        if (GameManager.instance.finish)
        {
            winner();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            life.gameObject.SetActive(false);
            moneda.gameObject.SetActive(false);
            key.gameObject.SetActive(false);
            puntos.gameObject.SetActive(false);
            pausa.gameObject.SetActive(true);

        }
    }
    public void winner()
    {
        gameObject.GetComponent<AudioSource>().Stop();
        life.gameObject.SetActive(false);
        moneda.gameObject.SetActive(false);
        key.gameObject.SetActive(false);
        puntos.gameObject.SetActive(false);

        win.SetActive(true);
        Time.timeScale = 0;
        if (Input.anyKeyDown)
        {
            Destroy(GameManager.instance.gameObject);
            SceneManager.LoadScene(0);
        }
        Time.timeScale = 1;

    }
    public void continuar()
    {
        Time.timeScale = 1;
        life.gameObject.SetActive(true);
        moneda.gameObject.SetActive(true);
        key.gameObject.SetActive(GameManager.instance.key);
        puntos.gameObject.SetActive(true);
        pausa.gameObject.SetActive(false);
    }
    public void salir()
    {
        Time.timeScale = 1;
        Destroy(GameManager.instance.gameObject);   
        SceneManager.LoadScene(0);
    }
}
