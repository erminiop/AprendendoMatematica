using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var w = GamesCodeDataSource.Instance.JogadorDAO.getJogador(1);
        print(w.Nome_jogador);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
