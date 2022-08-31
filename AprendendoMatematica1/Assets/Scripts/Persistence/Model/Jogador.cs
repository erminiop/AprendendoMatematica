using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador
{
    public Jogador()
    {
    }

    public Jogador(int id, string nome_jogador, int idade, string idioma)
    {
        Id = id;
        Nome_jogador = nome_jogador;
        Idade = idade;
        Idioma = idioma;
    }

    public int Id { get; set; }
    public string Nome_jogador { get; set; }
    public int Idade { get; set; }
    public string Idioma { get; set; }

}
