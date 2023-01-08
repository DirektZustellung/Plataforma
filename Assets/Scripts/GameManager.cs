using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool win,finish;
    public bool powerUp = false;
    public int puntosEnemgos = 50;
    public int puntosCoin = 10;
    public int created;
    
    public bool agachado = false;
    public bool key = false;
    
    public int vidas=3;
    
    public int puntuacion=0;
    
    public int coins;
    


    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
   
        
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
