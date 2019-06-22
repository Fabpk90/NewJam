using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnim;

    public bool canMove;

    private float timePassed;
    private QuestionMainScript _quest;
    
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
        _quest = Q;
        print("OOOHH YEAGHG");
    }
    
    private bool inputReceived = false;
    public void QuestionClock()
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
            //Probablement stopper la coroutine en vrai
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
           // print("CanMove");
           // print(_quest);
            if (Input.GetMouseButtonDown(0) && _quest) // left button
            {
                print("Yoo");
                canMove = false;
               // playerAnim.SetTrigger("ToAssis");
               // playerAnim.ResetTrigger("ToCouche");
               // playerAnim.ResetTrigger("ToDebout");
                
                GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                
                _quest.questAnim.SetBool("IsRunning", true);
                
            }
            else if (Input.GetMouseButtonDown(1) && _quest) // right
            {
                canMove = false;
               // playerAnim.SetTrigger("ToCouche");
               // playerAnim.ResetTrigger("ToAssis");
               // playerAnim.ResetTrigger("ToDebout");
                
               GetComponentInChildren<MeshRenderer>().material.color = Color.green;
            }
            else if (Input.GetMouseButtonDown(2) && _quest) // middle btn
            {
                canMove = false;
               // playerAnim.SetTrigger("ToDebout");
               // playerAnim.ResetTrigger("ToCouche");
               // playerAnim.ResetTrigger("ToAssis");
                
               GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;
            }
        }
    }
}
