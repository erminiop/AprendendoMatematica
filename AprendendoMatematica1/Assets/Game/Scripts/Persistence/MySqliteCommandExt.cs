using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public static class MySqliteCommandExt
{ 
    //metodo de extensao da classe sqlite connection para validar Fk de forma direta no metodo
    public static int ExecuteNonQueryWithFK(this SqliteCommand command) 
    {
        var temp = command.CommandText;

        command.CommandText = $"PRAGMA foreign_keys = true;{temp}";
        return command.ExecuteNonQuery();

    }
}
