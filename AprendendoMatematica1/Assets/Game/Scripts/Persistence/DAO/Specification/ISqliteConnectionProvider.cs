using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;


namespace Assets.Scripts.Persistence.DAO.Specification
{
    public interface ISqliteConnectionProvider
    {
        SqliteConnection Connection { get; }

    }
}
