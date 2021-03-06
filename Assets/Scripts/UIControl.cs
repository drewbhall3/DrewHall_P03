﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    [Header("Connected GameObjects/Components")]

    //GameObjects

    [SerializeField] GameObject MenuSelect;
    [SerializeField] GameObject BattleUI;
    [SerializeField] GameObject MoveSelect;
    [SerializeField] GameObject Poke1;
    [SerializeField] GameObject Poke2;
    [SerializeField] GameObject BCon;
    [SerializeField] GameObject selectArrow;
    [SerializeField] GameObject SelectArrowGroup;
    [SerializeField] GameObject fill1;
    [SerializeField] GameObject fill2;
    [SerializeField] GameObject Audio;

    //UI

    [SerializeField] Slider p1Slider;
    [SerializeField] Slider p2Slider;

    [SerializeField] Text Attack1;
    [SerializeField] Text Attack2;
    [SerializeField] Text MenuTxt;
    [SerializeField] Text Battletxt;
    [SerializeField] Text p1Nametxt;
    [SerializeField] Text p2Nametxt;
    [SerializeField] Text p1HPcountertxt;
    [SerializeField] Text p1HPmaxtxt;

    //Components

    [SerializeField] Transform T1;
    [SerializeField] Transform T5;
    [SerializeField] Transform T6;




    [Header("UI Setup")]

    //Pokemon 1 setup
    public string p1Name;
    public string p1Move;
    public string p1MoveType;

    //Pokemon 2 setup
    public string p2Name;
    public string p2Move;
    public string p2MoveType;

    string txt;
    string mTxt;
    bool MenufirstEntry;
    float MoveChoice;
    bool MovefirstEntry;
    bool inputPause;

    private void Awake()
    {
        Pokemon1 p1 = Poke1.GetComponent<Pokemon1>();
        Pokemon2 p2 = Poke2.GetComponent<Pokemon2>();

        //setup min/max values for HP sliders and labels
        p1Slider.maxValue = p1.maxHP;
        p1Slider.value = p1.maxHP;
        p1Slider.minValue = 0;

        p2Slider.maxValue = p2.maxHP;
        p2Slider.value = p1.maxHP;
        p2Slider.minValue = 0;

        p1HPmaxtxt.text = " /" + p1.maxHP;

        //changes pokemon Name on status bar to pokemon's name;

        p1Nametxt.text = p1.Pokemon1Name;
        p2Nametxt.text = p2.Pokemon2Name;

        //setting name values

        p1Name = p1.Pokemon1Name;
        p2Name = p2.Pokemon2Name;

        Attack1.text = p1.Attack1Name;
        Attack2.text = p1.Attack2Name;

        //text setup

        BattletxtManager(8);

        selectArrow.transform.position = T1.position;
        MenufirstEntry = true;
        MovefirstEntry = true;
    }

    //setup UI elements
    void Update()
    {
        BattleController bCon = BCon.GetComponent<BattleController>();
        AudioManager audio = Audio.GetComponent<AudioManager>();

        #region Arrow Nav MenuSelect
        if (MenuSelect.activeInHierarchy)
        {
            inputPause = true;
            if (MenufirstEntry)
            {
                selectArrow.transform.position = T1.position;
                MenufirstEntry = false;
            }

            if(selectArrow.transform.position == T1.position)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    audio.PlayAudio(7);
                    StartCoroutine(InputPause());
                    MoveSelect.SetActive(true);
                    MenuSelect.SetActive(false);
                }

            }

        }
        #endregion

        #region Arrow Nav MoveSelect
        if (MoveSelect.activeInHierarchy)
        {
            if(MoveChoice == 1)
            {
                selectArrow.transform.position = T6.position;
                MoveChoice = 0;
            }

            if (MoveChoice == 2)
            {
                selectArrow.transform.position = T5.position;
                MoveChoice = 0;
            }

            if (MovefirstEntry)
            {
             selectArrow.transform.position = T6.position;
             MovefirstEntry = false;
            }

            if (inputPause == false)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    MenufirstEntry = true;
                    MenuSelect.SetActive(true);
                    MoveSelect.SetActive(false);
                }
                if (selectArrow.transform.position == T6.position)
                {
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        audio.PlayAudio(7);
                        selectArrow.transform.position = T5.position;
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        MoveChoice = 1;
                        audio.PlayAudio(7);
                        SelectArrowGroup.SetActive(false);
                        BattleUI.SetActive(true);
                        MoveSelect.SetActive(false);
                        bCon.Button1Hit();
                        bCon.StartTurn();
                    }
                }
                if (selectArrow.transform.position == T5.position)
                {
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        audio.PlayAudio(7);
                        selectArrow.transform.position = T6.position;
                    }
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        MoveChoice = 2;
                        audio.PlayAudio(7);
                        SelectArrowGroup.SetActive(false);
                        BattleUI.SetActive(true);
                        MoveSelect.SetActive(false);
                        bCon.Button2Hit();
                        bCon.StartTurn();
                    }
                }
            }

        }
        #endregion

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene("Battle Scene");
        }

        //updates player health counter to match slider values
        Pokemon1 p1 = Poke1.GetComponent<Pokemon1>();
        Pokemon2 p2 = Poke2.GetComponent<Pokemon2>();

        float tempNum = Mathf.Round(p1.currentHP);

        if (tempNum >= 0)
        {
            p1HPcountertxt.text = tempNum.ToString();
        }
        else
        {
            p1HPcountertxt.text = "0";
        }

        p1Slider.value = p1.currentHP;
        p2Slider.value = p2.currentHP;

        #region HpSlider Color Change

        Image f1 = fill1.GetComponent<Image>();
        Image f2 = fill2.GetComponent<Image>();

        if (p1.currentHP <= p1.maxHP/2)
        {
            f1.color = Color.yellow;
        }

        if (p1.currentHP <= p1.maxHP / 5)
        {
            f1.color = Color.red;
        }

        if (p1.currentHP <= 0)
        {
            f1.color = Color.gray;
        }

        if (p2.currentHP <= p2.maxHP / 2)
        {
            f2.color = Color.yellow;
        }

        if (p2.currentHP <= p2.maxHP / 5)
        {
            f2.color = Color.red;
        }

        if (p2.currentHP <= 0)
        {
            f2.color = Color.gray;
        }

        #endregion
    }

    private IEnumerator InputPause()
    {

        yield return new WaitForSeconds(0.5f);
        inputPause = false;
    }

    public void BattletxtManager(float value)
    {
        StopCoroutine(BTextScroll(txt));
        StopCoroutine(MTextScroll(mTxt));

        if (value == 1)
        {
            txt = p1Name + " used " + p1Move + "!";
            StartCoroutine(BTextScroll(txt));
        }
        if(value == 2)
        {
            txt = p2Name + " used " + p2Move + "!";
            StartCoroutine(BTextScroll(txt));
        }
        if(value == 3)
        {
            txt = "Wild " + p2Name + " fainted.";
            StartCoroutine(BTextScroll(txt));
        }
        if(value == 4)
        {
            txt = "You Won!";
            StartCoroutine(BTextScroll(txt));
        }
        if(value == 5)
        {
            txt = p1Name + " fainted!";
            StartCoroutine(BTextScroll(txt));
        }
        if (value == 6)
        {
            txt = "You Whited Out!";
            StartCoroutine(BTextScroll(txt));

        }
        if (value == 7)
        {
            txt = "You Lost!";
            StartCoroutine(BTextScroll(txt));
            
        }
        if(value == 8)
        {
            mTxt = "What will " + p1Name + " do?";
            StartCoroutine(MTextScroll(mTxt));
        }
    }

    private IEnumerator BTextScroll(string sentence)
    {
        Battletxt.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            Battletxt.text += letter;
            yield return null;

        }

    }

    private IEnumerator MTextScroll(string sentence)
    {
        MenuTxt.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            MenuTxt.text += letter;
            yield return null;
        }

    }


    public void TurnEndUI()
    {
        MenufirstEntry = true;
        BattleUI.SetActive(false);
        MenuSelect.SetActive(true);
        SelectArrowGroup.SetActive(true);
        BattletxtManager(8);
    }
}
