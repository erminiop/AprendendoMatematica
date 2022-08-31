using Assets.Scripts.Persistence.DAO.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Persistence.DAO.Implementation
{
    public class MonstroDAO : IMonstroDAO
    {
        public ISqliteConnectionProvider ConnectionProvider { get; protected set; }

        public MonstroDAO(ISqliteConnectionProvider connectionProvider)
        {
            ConnectionProvider = connectionProvider;
        }

        public bool DeleteMonstro(int Id)
        {
            throw new NotImplementedException();
        }

        public bool getMonstro(int Id)
        {
            throw new NotImplementedException();
        }

        public bool SetMonstro(Monstro monstro)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMonstro(Monstro monstro)
        {
            throw new NotImplementedException();
        }
    }
}
