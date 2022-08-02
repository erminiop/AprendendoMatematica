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
        //CreateDatabaseFileIfNotExists();

    }
    private void CopyDatabaseFileIfNotExists()
    {
        this.databasePath = Path.Combine(Application.persistentDataPath, this.DatabaseName);
        //Se file existe retorna
        if (File.Exists(this.databasePath))
          return;

        var originalDatabasePath = string.Empty;
        var isAndroid = false;
        //if de decisão para uso da inicializacao do banco usando stream assets path
#if UNITY_EDITOR || UNITY_WP8 || UNITY_WINRT
     originalDatabasePath = Path.Combine(Application.streamAssetsPath, this.DatabaseName);
#elif UNITY_STANDALONE_OSX
     originalDatabasePath = Path.Combine(Application.dataPath, "/Ressources/Data/StreamingAssets/",this.DatabaseName);
#elif UNITY_IOS
      originalDatabasePath = Path.Combine(Application.dataPath, "/Raw/",this.DatabaseName); 
#elif UNITY_ANDROID
      isAndroid = true;
      originalDatabasePath = "jar:file://" + Application.dataPath + "!/assets" + this.DatabaseName;
      StartCoroutine(GetInternalFileAndroid(originalDatabasePath
#endif
        //Se não for android ira executar, pois android já esta copiando no metodo
        if (!isAndroid)
        {
            File.Copy(originalDatabasePath, this.databasePath);
        }
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
    private IEnumerator GetInternalFileAndroid(string path)
    {
        var request = UnityWebRequest.Get(path);
        yield return request.SendWebRequest();

        if(request.isHttpError || request.isNetworkError)
        {
            Debug.LogError($"Error build Android File:{request.error}")
        }else
        {
            File.WriteAllBytes(this.databasePath, request.downloadHandler.data);
            Debug.LogError("Arquivo copiado!");
        }
    }
}
