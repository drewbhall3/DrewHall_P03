using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationControl : MonoBehaviour
{
    [Header("Connected GameObjects/Components")]

    [SerializeField] GameObject Art1;
    [SerializeField] GameObject Art2;
    [SerializeField] GameObject Poke1;
    [SerializeField] GameObject Poke2;
    [SerializeField] GameObject Audio;

    public float tackle = 0.75f;
    public float scratch = 0.5f;
    public float thunder = 0.75f;
    public float bite = 0.62f;
    public float dmg = 0.42f;


    // Update is called once per frame

    public void Tackle()
    {
        #region setup var
        Animator anim1 = Poke1.GetComponent<Animator>();
        Animator art2 = Art2.GetComponent<Animator>();
        Animator art1 = Art1.GetComponent<Animator>();
        Animator anim2 = Poke1.GetComponent<Animator>();
        AudioManager audio = Audio.GetComponent<AudioManager>();
        #endregion

        #region Var Correction
        art1.SetBool("Hit", false);
        art1.SetBool("Damage", false);
        art1.SetBool("Bite", false);

        art2.SetBool("Tackle", false);
        art2.SetBool("Hit", false);
        art2.SetBool("Damage", false);

        anim1.SetBool("Thunder", false);
        anim1.SetBool("Bite", false);
        anim1.SetBool("Scratch", false);
        anim1.SetBool("Tackle", false);

        anim1.SetBool("Thunder", false);
        anim1.SetBool("Tackle", false);
        #endregion

        StartCoroutine(Tackle1());
    }

    #region Tackle Coroutines

    private IEnumerator Tackle1()
    {
        #region setup var
        Animator anim1 = Poke1.GetComponent<Animator>();
        Animator art2 = Art2.GetComponent<Animator>();
        Animator art1 = Art1.GetComponent<Animator>();
        Animator anim2 = Poke2.GetComponent<Animator>();
        AudioManager audio = Audio.GetComponent<AudioManager>();
        #endregion

        art1.SetBool("Tackle", true);

        yield return new WaitForSeconds(0.25f);
        StartCoroutine(Tackle2());
    }

    private IEnumerator Tackle2()
    {
        #region setup var
        Animator anim1 = Poke1.GetComponent<Animator>();
        Animator art2 = Art2.GetComponent<Animator>();
        Animator art1 = Art1.GetComponent<Animator>();
        Animator anim2 = Poke2.GetComponent<Animator>();
        AudioManager audio = Audio.GetComponent<AudioManager>();
        #endregion

        audio.PlayAudio(5);

        anim2.SetBool("Tackle", true);
        art2.SetBool("Hit", true);
        yield return new WaitForSeconds(0.5f);
        anim2.SetBool("Tackle", false);
        art2.SetBool("Hit", false);
        art1.SetBool("Tackle", false);

    }

    #endregion

    public void Scratch()
    {
        #region setup var
        Animator anim1 = Poke1.GetComponent<Animator>();
        Animator art2 = Art2.GetComponent<Animator>();
        Animator art1 = Art1.GetComponent<Animator>();
        Animator anim2 = Poke1.GetComponent<Animator>();
        AudioManager audio = Audio.GetComponent<AudioManager>();
        #endregion

        #region Var Correction
        art1.SetBool("Hit", false);
        art1.SetBool("Damage", false);
        art1.SetBool("Bite", false);

        art2.SetBool("Tackle", false);
        art2.SetBool("Hit", false);
        art2.SetBool("Damage", false);

        anim1.SetBool("Thunder", false);
        anim1.SetBool("Bite", false);
        anim1.SetBool("Scratch", false);
        anim1.SetBool("Tackle", false);

        anim1.SetBool("Thunder", false);
        anim1.SetBool("Tackle", false);
        #endregion

        StartCoroutine((Scratch1()));
    }

    #region Scratch Coroutines
    private IEnumerator Scratch1()
    {
        #region setup var
        Animator anim1 = Poke1.GetComponent<Animator>();
        Animator art2 = Art2.GetComponent<Animator>();
        Animator art1 = Art1.GetComponent<Animator>();
        Animator anim2 = Poke2.GetComponent<Animator>();
        AudioManager audio = Audio.GetComponent<AudioManager>();
        #endregion

        audio.PlayAudio(3);
        anim1.SetBool("Scratch",true);
        art1.SetBool("Hit",true);

        yield return new WaitForSeconds(0.5f);

        anim1.SetBool("Scratch", false);
        art1.SetBool("Hit", false);
    }


    #endregion

    public void Thundershock()
    {
        #region setup var
        Animator anim1 = Poke1.GetComponent<Animator>();
        Animator art2 = Art2.GetComponent<Animator>();
        Animator art1 = Art1.GetComponent<Animator>();
        Animator anim2 = Poke1.GetComponent<Animator>();
        AudioManager audio = Audio.GetComponent<AudioManager>();
        #endregion

        #region Var Correction
        art1.SetBool("Hit", false);
        art1.SetBool("Damage", false);
        art1.SetBool("Bite", false);

        art2.SetBool("Tackle", false);
        art2.SetBool("Hit", false);
        art2.SetBool("Damage", false);

        anim1.SetBool("Thunder", false);
        anim1.SetBool("Bite", false);
        anim1.SetBool("Scratch", false);
        anim1.SetBool("Tackle", false);

        anim1.SetBool("Thunder", false);
        anim1.SetBool("Tackle", false);
        #endregion

        StartCoroutine(Thunder1());
    }

    #region ThunderShock Coroutines
    private IEnumerator Thunder1()
    {
        #region setup var
        Animator anim1 = Poke1.GetComponent<Animator>();
        Animator art2 = Art2.GetComponent<Animator>();
        Animator art1 = Art1.GetComponent<Animator>();
        Animator anim2 = Poke2.GetComponent<Animator>();
        AudioManager audio = Audio.GetComponent<AudioManager>();
        #endregion

        anim1.SetBool("Thunder", true);

        yield return new WaitForSeconds(0.25f);

        StartCoroutine(Thunder2());
    }

    private IEnumerator Thunder2()
    {
        #region setup var
        Animator anim1 = Poke1.GetComponent<Animator>();
        Animator art2 = Art2.GetComponent<Animator>();
        Animator art1 = Art1.GetComponent<Animator>();
        Animator anim2 = Poke2.GetComponent<Animator>();
        AudioManager audio = Audio.GetComponent<AudioManager>();
        #endregion

        audio.PlayAudio(2);
        anim2.SetBool("Thunder", true);
        art2.SetBool("Hit", true);
        anim1.SetBool("Thunder", false);

        yield return new WaitForSeconds(0.5f);

        anim2.SetBool("Thunder", false);
        art2.SetBool("Hit", false);

    }

    #endregion

    public void Bite()
    {
        #region setup var
        Animator anim1 = Poke1.GetComponent<Animator>();
        Animator art2 = Art2.GetComponent<Animator>();
        Animator art1 = Art1.GetComponent<Animator>();
        Animator anim2 = Poke1.GetComponent<Animator>();
        AudioManager audio = Audio.GetComponent<AudioManager>();
        #endregion

        #region Var Correction
        art1.SetBool("Hit", false);
        art1.SetBool("Damage", false);
        art1.SetBool("Bite", false);

        art2.SetBool("Tackle", false);
        art2.SetBool("Hit", false);
        art2.SetBool("Damage", false);

        anim1.SetBool("Thunder", false);
        anim1.SetBool("Bite", false);
        anim1.SetBool("Scratch", false);
        anim1.SetBool("Tackle", false);

        anim1.SetBool("Thunder", false);
        anim1.SetBool("Tackle", false);
        #endregion

        StartCoroutine(Bite1());
    }

    #region Bite Coroutines

    private IEnumerator Bite1()
    {
        #region setup var
        Animator anim1 = Poke1.GetComponent<Animator>();
        Animator art2 = Art2.GetComponent<Animator>();
        Animator art1 = Art1.GetComponent<Animator>();
        Animator anim2 = Poke1.GetComponent<Animator>();
        AudioManager audio = Audio.GetComponent<AudioManager>();
        #endregion

        
        art2.SetBool("Bite", true);

        yield return new WaitForSeconds(0.12f);

        StartCoroutine(Bite2());



    }

    private IEnumerator Bite2()
    {
        #region setup var
        Animator anim1 = Poke1.GetComponent<Animator>();
        Animator art2 = Art2.GetComponent<Animator>();
        Animator art1 = Art1.GetComponent<Animator>();
        Animator anim2 = Poke2.GetComponent<Animator>();
        AudioManager audio = Audio.GetComponent<AudioManager>();
        #endregion

        audio.PlayAudio(4);
        anim1.SetBool("Bite", true);
        art1.SetBool("Hit", true);
        yield return new WaitForSeconds(0.5f);

        art2.SetBool("Bite", false);
        anim1.SetBool("Bite", false);
        art1.SetBool("Hit", false);

    }

    #endregion


    public void Damage(float num)
    {
        #region setup var
        Animator anim1 = Poke1.GetComponent<Animator>();
        Animator art2 = Art2.GetComponent<Animator>();
        Animator art1 = Art1.GetComponent<Animator>();
        Animator anim2 = Poke2.GetComponent<Animator>();
        AudioManager audio = Audio.GetComponent<AudioManager>();
        #endregion

        #region Var Correction
        art1.SetBool("Hit", false);
        art1.SetBool("Damage", false);
        art1.SetBool("Bite", false);

        art2.SetBool("Tackle", false);
        art2.SetBool("Hit", false);
        art2.SetBool("Damage", false);

        anim1.SetBool("Thunder", false);
        anim1.SetBool("Bite", false);
        anim1.SetBool("Scratch", false);
        anim1.SetBool("Tackle", false);

        anim1.SetBool("Thunder", false);
        anim1.SetBool("Tackle", false);
        #endregion

        if (num == 1)
        {
            StartCoroutine(Damage1());
        }
        if(num == 2)
        {
            StartCoroutine(Damage2());
        }
    }

    #region Damage Coroutines
    private IEnumerator Damage1()
    {
        #region setup var
        Animator anim1 = Poke1.GetComponent<Animator>();
        Animator art2 = Art2.GetComponent<Animator>();
        Animator art1 = Art1.GetComponent<Animator>();
        Animator anim2 = Poke2.GetComponent<Animator>();
        AudioManager audio = Audio.GetComponent<AudioManager>();
        #endregion

        audio.PlayAudio(1);
        art1.SetBool("Damage", true);
        yield return new WaitForSeconds(0.42f);
        art1.SetBool("Damage", false);
    }
    private IEnumerator Damage2()
    {
        #region setup var
        Animator anim1 = Poke1.GetComponent<Animator>();
        Animator art2 = Art2.GetComponent<Animator>();
        Animator art1 = Art1.GetComponent<Animator>();
        Animator anim2 = Poke2.GetComponent<Animator>();
        AudioManager audio = Audio.GetComponent<AudioManager>();
        #endregion

        audio.PlayAudio(1);
        art2.SetBool("Damage", true);
        yield return new WaitForSeconds(0.42f);
        art2.SetBool("Damage", false);
    }
    #endregion

    public void Faint(float num)
    {
        #region setup var
        Animator anim1 = Poke1.GetComponent<Animator>();
        Animator art2 = Art2.GetComponent<Animator>();
        Animator art1 = Art1.GetComponent<Animator>();
        Animator anim2 = Poke2.GetComponent<Animator>();
        AudioManager audio = Audio.GetComponent<AudioManager>();
        #endregion

        #region Var Correction
        art1.SetBool("Hit", false);
        art1.SetBool("Damage", false);
        art1.SetBool("Tackle", false);

        art2.SetBool("Bite", false);
        art2.SetBool("Hit", false);
        art2.SetBool("Damage", false);


        anim1.SetBool("Thunder", false);
        anim1.SetBool("Bite", false);
        anim1.SetBool("Scratch", false);
        anim1.SetBool("Tackle", false);

        anim1.SetBool("Thunder", false);
        anim1.SetBool("Tackle", false);
        #endregion

        if (num == 1)
        {
            art1.SetBool("Faint", true);
            audio.PlayAudio(6);
        }
        if (num == 2)
        {
            art2.SetBool("Faint", true);
            audio.PlayAudio(6);
        }
    }

}
