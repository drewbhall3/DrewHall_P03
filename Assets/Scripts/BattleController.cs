using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [Header("Connected GameObjects/Components")]

    //GameObjects
    [SerializeField] GameObject Poke1;
    [SerializeField] GameObject Poke2;

    //Components
    [SerializeField] PlayerTurn pTurn;
    [SerializeField] EnemyTurn eTurn;
    [SerializeField] UIControl UICon;


    [Header("Turn Controls")]

    public bool playerGone;
    public bool enemyGone;


    #region UI and Battle setup

    //sets up value of turn controls
    private void Awake()
    {
        playerGone = false;
        enemyGone = false;

     

    }

    //passes move pwr to Playerturn & info to UI (is connected to specific attack buttons)
    public void Button1Hit()
    {
        Pokemon1 p1 = Poke1.GetComponent<Pokemon1>();

        UICon.p1Move = p1.Attack1Name;
        UICon.p1MoveType = p1.Attack1Type;
        pTurn.movePwr = p1.Atk1Pwr;
    }

    //passes move pwr to Playerturn & info to UI (is connected to specific attack buttons)
    public void Button2Hit()
    {
        Pokemon1 p1 = Poke1.GetComponent<Pokemon1>();

        UICon.p1Move = p1.Attack2Name;
        UICon.p1MoveType = p1.Attack2Type;
        pTurn.movePwr = p1.Atk2Pwr;
    }

    #endregion

    #region Turn Control

    //at start of turn turns off button interaction and compares pokemon's speeds to determine turn order
    public void StartTurn()
    {
        Pokemon1 p1 = Poke1.GetComponent<Pokemon1>();
        Pokemon2 p2 = Poke2.GetComponent<Pokemon2>();

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
        //starts player turn
        playerGone = true;
        pTurn.StartTurn();
       
    }

    public void EnemyTurn()
    {
        Pokemon2 p2 = Poke2.GetComponent<Pokemon2>();

        //uses random chance to choose enemy pokemon move then passes info...
        //where it's needed to go
        float chance = Random.Range(1f, 10f);
        if (chance > 3f)
        {
            UICon.p2Move = p2.Attack1Name;
            UICon.p1MoveType = p2.Attack1Type;
            eTurn.movePwr = p2.Atk1Pwr;
        }
        else
        {
            UICon.p2Move = p2.Attack2Name;
            UICon.p1MoveType = p2.Attack2Type;
            eTurn.movePwr = p2.Atk2Pwr;
        }

        //starts enemy turn
        enemyGone = true;
        eTurn.StartTurn();

    }

    //resets button interaction and values at end of turn
    public void TurnEnd()
    {
        enemyGone = false;
        playerGone = false;

        UICon.TurnEndUI();
    }

    #endregion

    public void EndGame()
    {
        Pokemon1 p1 = Poke1.GetComponent<Pokemon1>();
        Pokemon2 p2 = Poke2.GetComponent<Pokemon2>();

        if (p1.currentHP <= 0 && p2.currentHP > 0)
        {
            Lose();
        }
        if(p2.currentHP <= 0 && p1.currentHP > 0)
        {
            Win();
        }


    }

    void Win()
    {
        UICon.BattletxtManager(3);
        StartCoroutine(WinTxt());
    }

    private IEnumerator WinTxt()
    {
        yield return new WaitForSeconds(5);
        UICon.BattletxtManager(4);
    }
    void Lose()
    {
        UICon.BattletxtManager(5);
        StartCoroutine(LoseTxt1());
    }

    private IEnumerator LoseTxt1()
    {
        yield return new WaitForSeconds(5);
        UICon.BattletxtManager(6);
        StartCoroutine(LoseTxt2());
    }

    private IEnumerator LoseTxt2()
    {
        yield return new WaitForSeconds(5);
        UICon.BattletxtManager(7);
 
    }
}


