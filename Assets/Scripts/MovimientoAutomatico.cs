using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAutomatico : MonoBehaviour
{
    public float speed = 10;
    public float horizontal = -0.1f;
    public float length = 1;
    public int prueba;
    
    public LayerMask mask;
    public List<Vector3> originPoints;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(horizontal * Time.deltaTime * speed, 0);
        for (int i = 0; i < originPoints.Count; i++)
        {
           Debug.DrawRay(transform.position + originPoints[i], Vector3.right * length, Color.red); // Comando para ver la linea del Raycast
           RaycastHit2D hit = Physics2D.Raycast(transform.position + originPoints[1], Vector3.right, length, mask); // Lanzamos el Raycast en la misma posicion y distancia que hemos visualizado
            if (hit.collider != null)
            {
                
                
                    Debug.DrawRay(transform.position + originPoints[i], Vector3.right * hit.distance, Color.green);
                    horizontal = horizontal * -1;
                    changeDirection();
                

             }

        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.tag == "Enemy")
        {
            horizontal = horizontal * -1;
            changeDirection();
            
            
            
        }
    }
   
    public void changeDirection()
    {
                if (horizontal > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                if (horizontal < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                

    }
    public void Muerte()
    {
       // anim.SetBool("death", true);
        StartCoroutine(Death_Corutine());
        //Destroy(gameObject);
    }
    IEnumerator Death_Corutine()
    {
        anim.SetBool("death", true);
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }
    
    
        
    

}
