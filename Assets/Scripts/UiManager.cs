using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.vidas <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
            if (Input.anyKeyDown)
            {
                Destroy (GameManager.instance.gameObject);
                SceneManager.LoadScene(0);
            }
            Time.timeScale = 1;
        }
    }
}
