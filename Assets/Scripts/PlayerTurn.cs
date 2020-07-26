using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurn : MonoBehaviour
{
    [Header("Connected GameObject/Components")]

    [SerializeField] BattleController bCon;
    [SerializeField] UIControl UICon;
    [SerializeField] GameObject Poke1;
    [SerializeField] GameObject Poke2;

    public string pokeName;
    public string pokeMove;
    public string pokeMoveType;
    public float movePwr;

    float tempNum;
    bool healthScroll;

    private void Awake()
    {
        healthScroll = false;
    }
    private void Update()
    {
        Pokemon2 p2 = Poke2.GetComponent<Pokemon2>();

        if (healthScroll)
        {
            if(p2.currentHP > tempNum)
            {
                p2.currentHP -= 0.3f;
            }
        }

    }


    public void StartTurn()
    {
        StartCoroutine(Step1());
    }

    //in order the timed steps of enemy's turn
    private IEnumerator Step1()
    {
        //text call out move used
        UICon.BattletxtManager(1);

        yield return new WaitForSeconds(3);

        StartCoroutine(Step2());

    }
    private IEnumerator Step2()
    {
        //attack animation
        Debug.Log("Attack Animation");

        yield return new WaitForSeconds(3);

        StartCoroutine(Step3());
    }
    private IEnumerator Step3()
    {
        //target damage animation & health adjusted
        Debug.Log("Damage Applied to enemy and enemy damage Animation");
        GiveDamage(movePwr);
        yield return new WaitForSeconds(3);

        StartCoroutine(Step4());
    }

    
    private IEnumerator Step4()
    {
        Pokemon1 p1 = Poke1.GetComponent<Pokemon1>();
        Pokemon2 p2 = Poke2.GetComponent<Pokemon2>();

        Debug.Log("End Player Turn");
        yield return new WaitForSeconds(3);

        healthScroll = false;
        p2.currentHP = tempNum;

        //runs check to see if any poke have < hp, if so it will run the end game code
        //otherwise will check to see what turns have been performed and will end turn...
        //...order if both have gone, or will start next turn
        if (p1.currentHP > 0 && p2.currentHP > 0)
        {
            if (bCon.enemyGone && bCon.playerGone)
            {
                bCon.TurnEnd();
                Debug.Log("End Turn");
            }
            else
            {
                Debug.Log("Enemy Turn Start");
                bCon.EnemyTurn();
            }
        }
        else
        {
            bCon.EndGame();
        }


    }

    //damage formula is simplified pokemon damage formula adjusted for simplified combat
    public void GiveDamage(float mPwr)
    {
        Pokemon1 p1 = Poke1.GetComponent<Pokemon1>();
        Pokemon2 p2 = Poke2.GetComponent<Pokemon2>();

        tempNum = p2.currentHP;
        tempNum -= Mathf.Round(((0.2f * (p1.attack / p2.defense)) * mPwr) + 2);
        healthScroll = true;
    }

}
