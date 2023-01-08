using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovimientoHorizontal : MonoBehaviour
{
    public float speed = 20;
    GroundDetector_Raycast ground;
    Animator anim;
    Boolean agachado;
    BoxCollider2D Collider;
    public float distanciaAgachado;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        ground = GetComponent<GroundDetector_Raycast>();    
        anim = GetComponent<Animator>();
        Collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
       
        anim.SetBool("moving", horizontal != 0);
        if (horizontal >0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (vertical <0 && horizontal == 0)
        {
            anim.SetBool("agachado", true);
            if (!GameManager.instance.agachado)
            {
                Collider.size = new Vector2(Collider.size.x, Collider.size.y * 0.5f);
                transform.position = new Vector3(transform.position.x, transform.position.y - distanciaAgachado);
                
            }
            GameManager.instance.agachado = true;
            agachado = true;
        }
        else if (GameManager.instance.agachado)
        {
            anim.SetBool("agachado", false);
            Collider.size = new Vector2(Collider.size.x, Collider.size.y * 2);
            transform.position = new Vector3(transform.position.x, transform.position.y + distanciaAgachado, 0);
            GameManager.instance.agachado = false;  
            agachado=false;
        }
        gameObject.GetComponent<PlayerConfig>().MarioConfig();
    }

}
