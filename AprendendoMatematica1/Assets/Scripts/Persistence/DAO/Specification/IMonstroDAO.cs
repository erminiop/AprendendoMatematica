using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Persistence.DAO.Specification
{
    public interface IMonstroDAO
    {
        ISqliteConnectionProvider ConnectionProvider { get; }
        bool SetMonstro(Monstro monstro);
        Monstro getMonstro(int Id);
        bool UpdateMonstro(Monstro monstro);
        bool DeleteMonstro(int Id);

    }
}
