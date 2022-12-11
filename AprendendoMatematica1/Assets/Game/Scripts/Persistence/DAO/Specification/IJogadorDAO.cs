using System;
using System.Collections.Generic;


namespace Assets.Scripts.Persistence.DAO.Specification
{
    public interface IJogadorDAO
    {
        ISqliteConnectionProvider ConnectionProvider { get; }
        bool InsertJogador(Player _player);
        Player getJogador(int id_player);
        bool SetJogador(Player _player);
        bool DeleteJogador(int id_player);


    }
}
