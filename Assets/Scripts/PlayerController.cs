using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnim;

    public bool canMove;

    private float timePassed;

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
    public void QuestionStarted()
    {
        timePassed = Time.time;
    }
    
    private bool inputReceived = false;
    IEnumerator QuestionClock()
    {
        var timeSinceQuestion = Time.time - timePassed;
        if (inputReceived)
        {
            if (timeSinceQuestion <= 5)
            {
                //Small scale reaction
            }
            else if (timeSinceQuestion <= 15)
            {
                //Medium scale reaction
            }
            else
            {
                //All Hell is breaking loose, please wait warmly.
            }

            //Probablement stopper la coroutine en vrai
        }
        yield return new WaitForSeconds(1f); //L'appellera 1fois/seconde
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
