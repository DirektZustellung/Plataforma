using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    public float speed;
    public GameObject target;
    public Vector2 minimo;
    public Vector2 maximo;
    Vector2 velocity;
    void Start()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
      
        
        

        float posX = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref velocity.x, speed);
        float posY = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref velocity.y, speed);

        transform.position = new Vector3(Mathf.Clamp(posX,minimo.x,maximo.x),Mathf.Clamp(posY,minimo.y,maximo.y), transform.position.z);
        
    }
}
