using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    [Header("Connected GameObject/Components")]

    [SerializeField] BattleController bCon;

    [Header("Battle Dialogue")]

    [SerializeField] string moveCallOut;

    public string pokeName;
    public string pokeMove;
    public string pokeMoveType;
    public float movePwr;

    public void StartTurn()
    {
        StartCoroutine(Step1());
    }

    //in order the timed steps of enemy's turn
    private IEnumerator Step1()
    {
        //text call out move used
        Debug.Log(pokeName + " used " + pokeMove);
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
        Debug.Log("Damage Applied to enemy and enemy Attack Animation");
        yield return new WaitForSeconds(3);

        StartCoroutine(Step4());
    }
    private IEnumerator Step4()
    {
        Debug.Log("Move Effective Text");
        yield return new WaitForSeconds(3);

        StartCoroutine(Step5());
    }
    private IEnumerator Step5()
    {
        Debug.Log("End Player Turn");
        yield return new WaitForSeconds(3);
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

}
