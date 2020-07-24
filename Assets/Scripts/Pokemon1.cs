using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon1 : MonoBehaviour
{
    [Header("Attached GameObjects/Components")]

    [SerializeField] SpriteRenderer renderer;

    [Header("Pokemon 1 Info")]

    [SerializeField] public string Pokemon1Name = "BunBun";
    [SerializeField] public string Pokemon1Type = "Grass";
    [SerializeField] Sprite p1_sprite;
    

    [Header("Pokemon 1 Stats")]

    [SerializeField] public float maxHP = 20;
    [SerializeField] public float currentHP = 20;
    [SerializeField] public float attack = 50;
    [SerializeField] public float defense = 50;
    [SerializeField] public float speed = 50;

    [Header("Pokemon 1 Move Info")]

    [Header("Attack 1")]

    [SerializeField] public string Attack1Name = "Tackle";
    [SerializeField] public string Attack1Type = "Normal";
    [SerializeField] public float Atk1Pwr = 35;

    [Header("Attack 2")]

    [SerializeField] public string Attack2Name = "Vine Whip";
    [SerializeField] public string Attack2Type = "Grass";
    [SerializeField] public float Atk2Pwr = 40;


    void Update()
    {

    }

    public void Attack1()
    {

    }
    public void Attack2()
    {

    }
}
