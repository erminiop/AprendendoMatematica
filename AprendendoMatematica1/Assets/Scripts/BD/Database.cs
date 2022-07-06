using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;

public class Database : MonoBehaviour
{
    //Nome do banco de dados
    public string DatabaseName;
    //Caminho do banco de dados
    protected string databasePath;
    protected SqliteConnection Connection => new SqliteConnection($"Data Source = {this.databasePath};");
    private void Awake()
    {
        //verifica se nome do DB foi informado
        if (string.IsNullOrEmpty(this.DatabaseName))
        {
            Debug.LogError("Nome do database não informado!");
            return;
        }
        CreateDatabaseFileIfNotExists();

    }
    //Criar banco de dados se ele ainda não existe
    private void CreateDatabaseFileIfNotExists()
    {
        //informando caminho de criacao do DB
        //Usando Path.Combine para combinar string do caminho com nome do BD
        this.databasePath = Path.Combine(Application.persistentDataPath, this.DatabaseName);
        if (!File.Exists(this.databasePath))
        {
            SqliteConnection.CreateFile(this.databasePath);
            Debug.Log($"Database caminho: {this.databasePath}");
        }
    }
}
