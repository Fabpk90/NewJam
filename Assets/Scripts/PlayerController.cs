using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnim;

    public bool canMove;

    private float timePassed;
    private QuestionMainScript Quest;
    
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;

        playerAnim = GetComponent<Animator>();
        //anim.SetBool("monBool", true/false);
    }

    /// <summary>
    /// Called by the question manager to start the timer
    /// </summary>
    public void QuestionStarted(QuestionMainScript Q)
    {
        timePassed = Time.time;
        Quest = Q;
        StartCoroutine("QuestionClock");
    }
    
    private bool inputReceived = false;
    IEnumerator QuestionClock()
    {
        bool cont = true;
        while (cont)
        {
            if (inputReceived)
            {
                var timeSinceQuestion = Time.time - timePassed;
                if (timeSinceQuestion <= 5)
                {
                    //Quest.questAnim.SetTrigger("Light");
                    //Où alors les questions ont des fonctions PlayLight/Medium/Hard comme ça on peut gérer les bruits dans ces fonctions ?
                    //Et on a juste à les appeller ici, ça serait pour utiliser la surcharge d'une classe question vers Orage/Fusée etc
                }
                else if (timeSinceQuestion <= 15)
                {
                    //Quest.questAnim.SetTrigger("Medium");//Medium scale reaction
                }
                else
                {
                    //Quest.questAnim.SetTrigger("Heavy");//All Hell is breaking loose, please wait warmly.
                }

                cont = false;
                //Probablement stopper la coroutine en vrai
            }

            yield return new WaitForSeconds(1f); //L'appellera 1fois/seconde
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (Input.GetMouseButtonDown(0)) // left button
            {
                //canMove = false;
                playerAnim.SetTrigger("ToAssis");
                playerAnim.ResetTrigger("ToCouche");
                playerAnim.ResetTrigger("ToDebout");
            }
            else if (Input.GetMouseButtonDown(1)) // right
            {
                //canMove = false;
                playerAnim.SetTrigger("ToCouche");
                playerAnim.ResetTrigger("ToAssis");
                playerAnim.ResetTrigger("ToDebout");
            }
            else if (Input.GetMouseButtonDown(2)) // middle btn
            {
                //canMove = false;
                playerAnim.SetTrigger("ToDebout");
                playerAnim.ResetTrigger("ToCouche");
                playerAnim.ResetTrigger("ToAssis");
            }
        }
    }
}
