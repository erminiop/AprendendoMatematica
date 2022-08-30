using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstro
{
    public Monstro(string nome_Monstro, float vel_Monstro, float alcance, float dano, float vida)
    {
        this.nome_Monstro = nome_Monstro;
        this.vel_Monstro = vel_Monstro;
        this.alcance = alcance;
        this.dano = dano;
        this.vida = vida;
    }

    public string nome_Monstro { get; set; }
    public float vel_Monstro { get; set; }
    public float alcance { get; set; }
    public float dano { get; set; }
    public float vida { get; set; }
}