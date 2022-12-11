using System.Runtime.Remoting.Lifetime;

public class Player
{
    public int id { get; set; }
    public string name { get; set; }
    public string language { get; set; }
    public int life { get; set; }
    public int modelPlayer { get; set; }


    

    public Player(int id, string name, int modelPlayer, string language, int life)
    {
        this.id = id;
        this.name = name;
        this.language = language;
        this.modelPlayer = modelPlayer;
        this.life = life;
    }
}
