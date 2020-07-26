using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pokemon2 : MonoBehaviour
{
    [Header("Pokemon 2 Info")]

    [SerializeField] public string Pokemon2Name = "Evil BunBun";
    [SerializeField] public string Pokemon2Type = "Normal";

    [Header("Pokemon 2 Stats")]

    [SerializeField] public float maxHP = 20;
    [SerializeField] public float currentHP = 20;
    [SerializeField] public float attack = 50;
    [SerializeField] public float defense = 50;
    [SerializeField] public float speed = 50;

    [Header("Pokemon Move Info")]

    [Header("Attack 1")]

    [SerializeField] public string Attack1Name = "Scratch";
    [SerializeField] public string Attack1Type = "Normal";
    [SerializeField] public float Atk1Pwr = 20;

    [Header("Attack 2")]

    [SerializeField] public string Attack2Name = "Bite";
    [SerializeField] public string Attack2Type = "Dark";
    [SerializeField] public float Atk2Pwr = 60;


}
