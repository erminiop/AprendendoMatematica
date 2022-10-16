using System;
using System.Collections.Generic;


namespace Assets.Scripts.Persistence.DAO.Specification
{
    public interface IJogadorDAO
    {
        ISqliteConnectionProvider ConnectionProvider { get; }
        bool SetJogador(Jogador jogador);
        Jogador getJogador(int Id);
        bool UpdateJogador(Jogador jogador);
        bool DeleteJogador(int Id);


    }
}
