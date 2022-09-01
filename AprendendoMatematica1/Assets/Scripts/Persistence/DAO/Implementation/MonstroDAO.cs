using Assets.Scripts.Persistence.DAO.Specification;
using System;
using System.Collections.Generic;
using System.Data;
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
            var commandText = "DELETE FROM Monstro WHERE Id = @Id;";
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

        public Monstro getMonstro(int Id)
        {
            var commandText = "SELECT FROM Monstro WHERE Id= @id;";
            Monstro returnMonstro = null;
            
            using (var connection = ConnectionProvider.Connection)
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.Parameters.AddWithValue("@id", Id);

                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        returnMonstro = new Monstro();

                        returnMonstro.Nome_Monstro = reader.GetString(0);
                        returnMonstro.Vel_Monstro = reader.GetFloat(1);
                        returnMonstro.Alcance = reader.GetFloat(2);
                        returnMonstro.Dano = reader.GetFloat(3);
                        returnMonstro.Vida = reader.GetFloat(4);

                    }
                }
            }
            return returnMonstro;
        }

        public bool SetMonstro(Monstro monstro)
        {
            var commandText = "INSERT INTO Monstro(Nome_Monstro, Vel_Monstro, Alcance, Dano, Vida) " +
                "Values (@nome_monstro, @vel_monstro,@alcance,@dano, @vida);";
            
            using (var connection = ConnectionProvider.Connection)
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = commandText;

                    command.Parameters.AddWithValue("@nome_monstro", monstro.Nome_Monstro);
                    command.Parameters.AddWithValue("@vel_monstro", monstro.Vel_Monstro);
                    command.Parameters.AddWithValue("@alcance", monstro.Alcance);
                    command.Parameters.AddWithValue("@dano", monstro.Dano);
                    command.Parameters.AddWithValue("@vida", monstro.Vida);
                    return command.ExecuteNonQueryWithFK() > 0;
                }
            }
        }

        public bool UpdateMonstro(Monstro monstro)
        {
            var commandText =
            "UPDATE Monstro SET" +
            "Nome_Monstro = @nome_monstro" +
            "Vel_Monstro = @vel_monstro" +
            "Alcance = @alcance" +
            "Dano = @dano" +
            "Vida = @vida" +
            "Where Id = @id;";

            using (var connection = ConnectionProvider.Connection)
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = commandText;

                    command.Parameters.AddWithValue("@nome_monstro", monstro.Nome_Monstro);
                    command.Parameters.AddWithValue("@vel_monstro", monstro.Vel_Monstro);
                    command.Parameters.AddWithValue("@alcance", monstro.Alcance);
                    command.Parameters.AddWithValue("@dano", monstro.Dano);
                    command.Parameters.AddWithValue("@vida", monstro.Vida);


                    return command.ExecuteNonQueryWithFK() > 0;

                }
            }
        }
    }
}
