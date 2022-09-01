using Assets.Scripts.Persistence.DAO.Implementation;
using Assets.Scripts.Persistence.DAO.Specification;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class GamesCodeDataSource : SqliteDataSource 
{
    public JogadorDAO JogadorDAO { get; set; } 
    public MonstroDAO MonstroDAO { get; set; }

    private static GamesCodeDataSource instance;
    public static GamesCodeDataSource Instance 
    { 
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GamesCodeDataSource>();
                if (instance == null)
                {
                    var gameCodeDataSource = new GameObject("GameCodeDataSource");
                    instance = gameCodeDataSource.AddComponent<GamesCodeDataSource>();
                    DontDestroyOnLoad(gameCodeDataSource);

                }
            }
            return instance;
        }
    }  

protected void Awake()
    {
        try
        {
            this.databaseName = "GameDB.db";
            this.CopyDatabase = true;


        }
        catch(Exception ex)
        {
            Debug.LogError($"Database não criado:!{ex.Message}");
        }
        
    }
}
