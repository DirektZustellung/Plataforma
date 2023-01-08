using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector_Raycast : MonoBehaviour
{
    public float length=1;
    public bool grounded;
    public LayerMask mask;
    public List<Vector3> originPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        grounded = false;
        for (int i = 0; i < originPoints.Count; i++)
        {
            Debug.DrawRay(transform.position+ originPoints[i], Vector3.down*length, Color.red); // Comando para ver la linea del Raycast
            RaycastHit2D hit=Physics2D.Raycast(transform.position + originPoints[1], Vector3.down, length, mask); // Lanzamos el Raycast en la misma posicion y distancia que hemos visualizado
            if(hit.collider != null)
            {
                if(hit.collider.tag == "PlataformaMovil")
                {
                    transform.parent = hit.transform;
                }
                Debug.DrawRay(transform.position + originPoints[i], Vector3.down * hit.distance, Color.green);
                grounded=true;
             /*   if(hit.collider.gameObject.tag == "Cabeza")
                {
                    GetComponent<Salto>().AutoJump();
                    GameManager.instance.puntuacion += GameManager.instance.puntosEnemgos;
                    //hit.collider.GetComponent<MovimientoAutomatico>().Muerte();
                    hit.collider.GetComponentInParent<MovimientoAutomatico>().Muerte();
                }
             */
            }
            if (!grounded)
            {
                transform.parent=null;
            }
        }
        
        
    }
   
}
