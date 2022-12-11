using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Persistence.DAO.Implementation;

public class Death : MonoBehaviour, IDamageble
{

    //PlayerController playerController;
    public bool isDead {get; private set;}

    public event Action DeathEvent;

    private void Awake()
    {
        isDead = false;
      //  player = iniPlayer(1);
              
    }
    
    //player = playerController.player;
   


    public void TakeDamage(int damage)
    {
        //Destroy(gameObject);
        
            Debug.Log("Death");
            isDead = true;
            DeathEvent.Invoke();
        
        
    }
   /* private Player iniPlayer(int id_player)
    {
        Player returnPlayer = null;
        returnPlayer = GamesCodeDataSource.Instance.JogadorDAO.getJogador(id_player);
        return returnPlayer;
    }*/
}
