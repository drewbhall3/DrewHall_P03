using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    [Header("Connected GameObjects/Components")]

    [SerializeField] GameObject Poke1;
    [SerializeField] GameObject Poke2;
    [SerializeField] Button Attack1_btn;
    [SerializeField] Button Attack2_btn;
    [SerializeField] PlayerTurn pTurn;
    [SerializeField] EnemyTurn eTurn;
    [SerializeField] GameObject Menuselect;
    [SerializeField] GameObject BattleUI;

    [Header("Turn Controls")]

    [SerializeField] public bool playerGone;
    [SerializeField] public bool enemyGone;

    private void Awake()
    {
        playerGone = false;
        enemyGone = false;
    }

    public void Button1Hit()
    {
        Pokemon1 p1 = Poke1.GetComponent<Pokemon1>();
        pTurn.pokeName = p1.name;
        pTurn.pokeMove = p1.Attack1Name;
        pTurn.pokeMoveType = p1.Attack1Type;
        pTurn.movePwr = p1.Atk1Pwr;
    }

    public void Button2Hit()
    {
        Pokemon1 p1 = Poke1.GetComponent<Pokemon1>();
        pTurn.pokeName = p1.name;
        pTurn.pokeMove = p1.Attack2Name;
        pTurn.pokeMoveType = p1.Attack2Type;
        pTurn.movePwr = p1.Atk2Pwr;
    }

    //at start of turn turns off button interaction and compares pokemon's speeds to determine turn order
    public void StartTurn()
    {
        Pokemon1 p1 = Poke1.GetComponent<Pokemon1>();
        Pokemon2 p2 = Poke2.GetComponent<Pokemon2>();

        Attack1_btn.interactable = false;
        Attack2_btn.interactable = false;

        if (p1.speed > p2.speed)
        {
            playerGone = true;

            PlayerTurn();

        }
        if (p1.speed < p2.speed)
        {
            enemyGone = true;

            EnemyTurn();

        }

        //if speeds are equal randomly determines who goes first
        if (p1.speed == p2.speed)
        {
            float chance = Random.Range(1f, 10f);

            if(chance >= 6)
            {
                
                PlayerTurn();
            }
            else
            {

                EnemyTurn();
            }

        }

    }

    //checks to see if both pokemon have/haven't gone and ends turn or starts respective turn code accordingly
    public void PlayerTurn()
    {
        if (playerGone && enemyGone)
        {
            TurnEnd();
        }
        else
        {
            playerGone = true;
            pTurn.StartTurn();
        }

    }

    public void EnemyTurn()
    {
        Pokemon2 p2 = Poke2.GetComponent<Pokemon2>();
        float chance = Random.Range(1f, 10f);
        if (chance > 3f)
        {
            eTurn.pokeName = p2.name;
            eTurn.pokeMove = p2.Attack1Name;
            eTurn.pokeMoveType = p2.Attack1Type;
            eTurn.movePwr = p2.Atk1Pwr;
        }
        else
        {
            eTurn.pokeName = p2.name;
            eTurn.pokeMove = p2.Attack2Name;
            eTurn.pokeMoveType = p2.Attack2Type;
            eTurn.movePwr = p2.Atk2Pwr;
        }

        if (playerGone && enemyGone)
        {
            TurnEnd();
        }
        else
        {
            enemyGone = true;
            eTurn.StartTurn();
        }

    }

    //resets button interaction and values at end of turn
    public void TurnEnd()
    {

        Attack1_btn.interactable = true;
        Attack2_btn.interactable = true;

        enemyGone = false;
        playerGone = false;

        BattleUI.SetActive(false);
        Menuselect.SetActive(true);

    }
}
