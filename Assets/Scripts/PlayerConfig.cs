using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig : MonoBehaviour
{

    public BoxCollider2D MarioGrande, MarioPequeño;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MarioConfig()
    {
        if (GameManager.instance.powerUp && !GameManager.instance.agachado)
        {
            MarioGrande.enabled = true;
            MarioPequeño.enabled = false;
        }
        else
        {
            MarioGrande.enabled = false;
            MarioPequeño.enabled = true;
        }
    }
}
