﻿using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Persistence.DAO.Specification
{
    public interface ISqliteConnectionProvider
    {
        SqliteConnection Connection { get; }

    }
}
