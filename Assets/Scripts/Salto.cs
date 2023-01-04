using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
   
{
    public Rigidbody2D rb;
    public Transform p1, p2, gp1, gp2;
    public LayerMask groundMask;
    private bool isGrounded;
    private Animator anim;
    public int jumpForce, autoJumpForce;

    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.powerUp)
        {
            isGrounded = Physics2D.OverlapArea(gp1.position, gp2.position, groundMask);
            
        }
        else
        {
            isGrounded = Physics2D.OverlapArea(p1.position, p2.position, groundMask);
        }
        
        if(isGrounded)
        {
            anim.SetBool("grounded", isGrounded);
            if(Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                
            }
                
            
        }
        else
        {
            anim.SetBool("grounded", false);
        }
    }
    public void AutoJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * autoJumpForce, ForceMode2D.Impulse);
    }
}
