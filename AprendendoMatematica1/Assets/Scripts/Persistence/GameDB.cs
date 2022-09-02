using Assets.Scripts.Persistence.DAO.Implementation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDB : SqliteDataSource 
{
    public JogadorDAO JogadorDAO { get; protected set; }
    public MonstroDAO MonstroDAO { get;protected set; }
    protected void Awake()
    {
        this.databaseName = "GameDB.db";
        this.CopyDatabase = true;
        try
        {
            base.Awake();
            JogadorDAO = new JogadorDAO(this);
            MonstroDAO = new MonstroDAO(this);
        }
        catch (Exception ex)
        {
            Debug.LogError("Database não criado "+ ex.Message);
        }
    }
}
