using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstro
{
    public string Nome_Monstro { get; set; }
    public float Vel_Monstro { get; set; }
    public float Alcance { get; set; }
    public float Dano { get; set; }
    public float Vida { get; set; }

    public Monstro(string nome_Monstro, float vel_Monstro, float alcance, float dano, float vida)
    {
        Nome_Monstro = nome_Monstro;
        Vel_Monstro = vel_Monstro;
        Alcance = alcance;
        Dano = dano;
        Vida = vida;
    }
}