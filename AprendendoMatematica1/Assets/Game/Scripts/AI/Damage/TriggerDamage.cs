using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
  [SerializeField][Min(1)] private int damage = 10;

   private void OnTriggerEnter2D(Collider2D collision)
    {
        
        IDamageble damageble = collision.GetComponent<IDamageble>();
        Debug.Log("Teste: "+damageble);
        if (damageble != null)
        {
           // Debug.Log("Trigger: "+collision.name);
            damageble.TakeDamage(10);
        }
    }
}
