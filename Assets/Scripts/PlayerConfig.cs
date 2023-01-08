using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig : MonoBehaviour
{

    public BoxCollider2D MarioGrande, MarioPeque�o;
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
            MarioPeque�o.enabled = false;
        }
        else
        {
            MarioGrande.enabled = false;
            MarioPeque�o.enabled = true;
        }
    }
}
