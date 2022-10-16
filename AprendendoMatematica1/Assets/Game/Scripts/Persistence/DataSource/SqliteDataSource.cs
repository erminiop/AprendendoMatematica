using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine.Networking;
using System;
using Assets.Scripts.Persistence.DAO.Specification;


public class SqliteDataSource : MonoBehaviour, ISqliteConnectionProvider
{
    //Nome do banco de dados
    public string databaseName;
    //Caminho do banco de dados
    protected string databasePath;
    
    public SqliteConnection Connection => new SqliteConnection($"Data Source = {this.databasePath};");

    [SerializeField]protected bool CopyDatabase;
    protected void Awake()
    {
        
        //verifica se nome do DB foi informado
        if (string.IsNullOrEmpty(this.databaseName))
        {
            Debug.LogError("Nome do database não informado!");
            return;
        }
        
        CopyDatabaseFileIfNotExists();
       
    }
    #region Copia DB
    private void CopyDatabaseFileIfNotExists()
    {
        this.databasePath = Path.Combine(Application.persistentDataPath, this.databaseName);
        //Se file existe retorna
        if (File.Exists(this.databasePath))
        {
            Debug.Log($"Database já criado no caminho : {this.databasePath}");
            return;
        }
            

        var originalDatabasePath = string.Empty;
        var isAndroid = false;
        //if de decisão para uso da inicializacao do banco usando stream assets path
#if UNITY_EDITOR || UNITY_WP8 || UNITY_WINRT
      originalDatabasePath = Path.Combine(Application.streamingAssetsPath, this.databaseName);
#elif UNITY_STANDALONE_OSX
      originalDatabasePath = Path.Combine(Application.dataPath, "/Ressources/Data/StreamingAssets/",this.databaseName);
#elif UNITY_IOS
      originalDatabasePath = Path.Combine(Application.dataPath, "/Raw/",this.databaseName); 
#elif UNITY_ANDROID
      isAndroid = true;
      originalDatabasePath = "jar:file://" + Application.dataPath + "!/assets" + this.databaseName;
      StartCoroutine(GetInternalFileAndroid(originalDatabasePath));
#endif

      
        //Se não for android ira executar, pois android já esta copiando no metodo
        if (!isAndroid)
        {

            /* debug usados para teste e retronar caminho do arquivo onde foi copiado
            Debug.Log($"O caminho: {this.databasePath}");
            Debug.Log($"O origem: {originalDatabasePath}");*/
            File.Copy(originalDatabasePath, this.databasePath);
            //Debug.Log($"O caminho: {this.databasePath}");
        }

    }

    //Criar banco de dados se ele ainda não existe
    private void CreateDatabaseFileIfNotExists()
    {
        //informando caminho de criacao do DB
        //Usando Path.Combine para combinar string do caminho com nome do BD
        this.databasePath = Path.Combine(Application.persistentDataPath, this.databaseName);
        if (!File.Exists(this.databasePath))
        {
            SqliteConnection.CreateFile(this.databasePath);
            //Debug.Log($"O caminho: {this.databasePath}");
        }
    }
    private IEnumerator GetInternalFileAndroid(string path)
    {
        var request = UnityWebRequest.Get(path);
        yield return request.SendWebRequest();

        if (request.isHttpError || request.isNetworkError)
        {
            Debug.LogError($"Error build Android File:{request.error}");
        }
        else
        {
            File.WriteAllBytes(this.databasePath, request.downloadHandler.data);
            Debug.LogError("Arquivo copiado!");
        }
    }
    #endregion
    #region Criacao Tabelas
    protected void CreateTableJogador()
    {
        using (var con = Connection)
        {
            
            var commandTableJogador = $"Create Table CadastroJogador" +
                $"(" +
                $" Id INTEGER PRIMARY KEY NOT NULL," +
                $" Nome_jogador TEXT NOT NULL," +
                $" Idade INTEGER," +
                $" Idioma TEXT NOT NULL" +
                $");";

            var commandTablePontuacao = $"Create Table PontuacaoJogador" +
                $"(" +
                $" Id_jogador INTEGER," +
                $" Livros_coletados INTEGER," +
                $" Fase INTEGER," +
                $" Porcentagem_acerto REAL," +
                $" Pontuacao_total INTEGER, " +
                $" FOREIGN kEY (Id_jogador) REFERENCES CadastroJogador(Id) ON UPDATE CASCADE" +
                $");";

            var commandTableMonstro = $"Create Table Monstro" +
                $"(" +
                $" Nome_Monstro PRIMARY KEY," +
                $" Vel_Monstro REAL," +
                $" Alcance REAL," +
                $" Dano REAL," +
                $" Vida REAL" +
                $");";

            con.Open();

            using (var command = con.CreateCommand())
            {
                command.CommandText = commandTableJogador;
                command.ExecuteNonQuery();
                Debug.Log("Cria Tabela Jogador");
                command.CommandText = commandTablePontuacao;
                command.ExecuteNonQuery();
                Debug.Log("Cria Tabela Pontuacao");
                command.CommandText = commandTableMonstro;
                command.ExecuteNonQuery();
                Debug.Log("Cria Tabela Monstro");
            }

        } 
    }
    protected void CreateTablePontuacao()
    {
        using (var con = Connection)
        {
            var commandTablePontuacao = $"Create Table PontuacaoJogador" +
                $"(" +
                $" Id_jogador INTEGER," +
                $" Livros_coletados INTEGER," +
                $" Fase INTEGER," +
                $" Porcentagem_acerto REAL," +
                $" Pontuacao_total INTEGER, " +
                $" FOREIGN kEY (Id_jogador) REFERENCES CadastroJogador(Id_jogador) ON UPDATE CASCADE" +
                $");";

            
            con.Open();

            using (var command = con.CreateCommand())
            {
                
                command.CommandText = commandTablePontuacao;
                command.ExecuteNonQuery();
                Debug.Log("Cria Tabela Pontuacao");
                
            }

        }
    }
    protected void CreateTableMonstro()
    {
        using (var con = Connection)
        {

            
            var commandTableMonstro = $"Create Table Monstro" +
                $"(" +
                $" nome_Monstro PRIMARY KEY," +
                $" vel_Monstro REAL," +
                $" alcance REAL," +
                $" dano REAL," +
                $" vida REAL" +
                $");";

            con.Open();

            using (var command = con.CreateCommand())
            {
                command.CommandText = commandTableMonstro;
                command.ExecuteNonQuery();
                Debug.Log("Cria Tabela Monstro");
            }

        }
    }
#endregion
}
