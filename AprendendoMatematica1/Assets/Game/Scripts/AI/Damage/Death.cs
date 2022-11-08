using System;
using UnityEngine;

public class Death : MonoBehaviour, IDamageble
{
    public bool isDead {get; private set;}

    public event Action DeathEvent;

    private void Awake()
    {
        isDead = false;   
    }
    public void TakeDamage(int damage)
    {
        //Destroy(gameObject);
        isDead = true;
        DeathEvent.Invoke();
    }
}
