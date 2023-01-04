using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTaker : MonoBehaviour
{
    public int damage;
    public bool ignoreInvencible;
    public string target = "Player";
    
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == target)
        {
            
            collision.gameObject.GetComponent<LifeController>().Damage(damage, ignoreInvencible);
        }
    }
   
}
