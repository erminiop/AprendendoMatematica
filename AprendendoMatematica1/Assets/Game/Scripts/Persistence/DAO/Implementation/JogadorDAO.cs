using Assets.Scripts.Persistence.DAO.Specification;



namespace Assets.Scripts.Persistence.DAO.Implementation
{
    public class JogadorDAO : IJogadorDAO
    {
        public Player player = null;
        public ISqliteConnectionProvider ConnectionProvider { get; protected set; }
        public JogadorDAO(ISqliteConnectionProvider connectionProvider) => ConnectionProvider = connectionProvider;

       public bool DeleteJogador(int Id)
        {
            var commandText = "DELETE FROM Player WHERE id_player = @id_player";
            using (var connection = ConnectionProvider.Connection)
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.Parameters.AddWithValue("@id_player", Id);

                    return command.ExecuteNonQueryWithFK() > 0;
                }
            }
        }

        public Player getJogador(int id_player)
        {
            var commandText = "SELECT * FROM Player WHERE id_player= @id_player;";
            //Player returnJogador = null;

            using( var connection = ConnectionProvider.Connection)
            {
                connection.Open();
                using(var command = connection.CreateCommand())
                {
                    command.CommandText= commandText;
                    command.Parameters.AddWithValue("@id_player", id_player);

                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int _id;
                        string _name;
                        int _modelPlayer;
                        string _language;
                        int _life;
                        //returnJogador = new Jogador();
                        
                        //returnJogador.Id = reader.GetInt32(0);
                        _id= reader.GetInt32(0);
                        //returnJogador.Nome_jogador = reader.GetString(1);
                        _name= reader.GetString(1);
                        //returnJogador.Idade = reader.GetInt32(2);
                        _modelPlayer= reader.GetInt32(2);
                        //returnJogador.Idioma = reader.GetString(3);
                        _language= reader.GetString(3);
                        //returnJogador.life = reader.GetInt32(4);
                        _life = reader.GetInt32(4);


                        //returnJogador = new Player(_id,_name,_modelPlayer,_language,_life);
                        player = new Player(_id, _name, _modelPlayer, _language, _life);

                    }
                }
            }
            
            return player;

        }

        public bool InsertJogador(Player jogador)
        {
            var commandText = "INSERT INTO Player(id_player, name, modelPlayer, language, life) " +
                "Values (@id_player, @name,@modelPlayer, @language, @life);";

            using(var connection = ConnectionProvider.Connection)
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = commandText;

                    command.Parameters.AddWithValue("@id_player", jogador.id);
                    command.Parameters.AddWithValue("@name", jogador.name);
                    command.Parameters.AddWithValue("@modelPlayer", jogador.modelPlayer);
                    command.Parameters.AddWithValue("@language", jogador.language);
                    command.Parameters.AddWithValue("@life", jogador.life);
                    return command.ExecuteNonQueryWithFK() > 0;
                    
                }
                

            }

        }

        public bool SetJogador(Player jogador)
        {
            var commandText =
            "UPDATE Player SET" +
            "name = @name" +
            "modelPlayer = @modelPlayer" +
            "language = @language" +
            "life = @life"+
            "Where Id = @id_player;";

            using (var connection = ConnectionProvider.Connection)
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = commandText;

                    command.Parameters.AddWithValue("@id_player", jogador.id);
                    command.Parameters.AddWithValue("@name", jogador.name);
                    command.Parameters.AddWithValue("@modelPlayer", jogador.modelPlayer);
                    command.Parameters.AddWithValue("@language", jogador.language);
                    command.Parameters.AddWithValue("@life", jogador.life);


                    return command.ExecuteNonQueryWithFK() > 0;

                }
            }
            
        }
    }
}
