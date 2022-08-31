using Assets.Scripts.Persistence.DAO.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Persistence.DAO.Implementation
{
    public class JogadorDAO : IJogadorDAO
    {
        public ISqliteConnectionProvider ConnectionProvider {get; protected set;}

        public JogadorDAO(ISqliteConnectionProvider connectionProvider)
        {
            ConnectionProvider = connectionProvider;
        }

        public bool DeleteJogador(int Id)
        {
            var commandText = "DELETE FROM CadastroJogador WHERE Id = @Id;";
            using (var connection = ConnectionProvider.Connection)
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.Parameters.AddWithValue("@Id", Id);

                    return command.ExecuteNonQueryWithFK() > 0;
                }
            }
        }

        public bool getJogador(int Id)
        {
            throw new NotImplementedException();
        }

        public bool SetJogador(Jogador jogador)
        {
            var commandText = "INSERT INTO CadastroJogador(Id, Nome_jogador, Idade, Idioma) " + 
                "Values (@id, @nome_jogador,@idade, @idioma);";

            using(var connection = ConnectionProvider.Connection)
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = commandText;

                    command.Parameters.AddWithValue("@id", jogador.Id);
                    command.Parameters.AddWithValue("@nome_jogador", jogador.Nome_jogador);
                    command.Parameters.AddWithValue("@idade", jogador.Idade);
                    command.Parameters.AddWithValue("@idioma", jogador.Idioma);
                    return command.ExecuteNonQueryWithFK() > 0;
                }    
            }
            
        }

        public bool UpdateJogador(Jogador jogador)
        {
            var commandText =
            "UPDATE CadatroJogador SET" +
            "Nome_jogador = @nome_jogador" +
            "Idade = @idade" +
            "Idioma = @idioma" +
            "Where Id = @id;";

            using (var connection = ConnectionProvider.Connection)
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = commandText;

                    command.Parameters.AddWithValue("@id", jogador.Id);
                    command.Parameters.AddWithValue("@nome_jogador", jogador.Nome_jogador);
                    command.Parameters.AddWithValue("@idade", jogador.Idade);
                    command.Parameters.AddWithValue("@idioma", jogador.Idioma);


                    return command.ExecuteNonQueryWithFK() > 0;

                }
            }
        }
    }
}
