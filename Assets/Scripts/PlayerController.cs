using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnim;

    public bool canMove;

    private float timePassed;
    private QuestionMainScript _quest;

    public TextMeshProUGUI text;
    
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

        text.enabled = true;
        text.text = _quest.quest;
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
                if (!_quest.isSpawning)
                {
                    _quest.questAnim.SetFloat("ClockTime",Time.time - timePassed);
                    _quest.questAnim.SetBool("IsRunning", true);
                }
                else
                {
                    GameManager.Instance.Spawn(_quest.amount, _quest.toSpawning, _quest.position, 5f);
                }
                
                
            }
            else if (Input.GetMouseButtonDown(1) && _quest) // right
            {
                canMove = false;
               // playerAnim.SetTrigger("ToCouche");
               // playerAnim.ResetTrigger("ToAssis");
               // playerAnim.ResetTrigger("ToDebout");
                
               GetComponentInChildren<MeshRenderer>().material.color = Color.green;
               
               _quest.questAnim.SetFloat("ClockTime",Time.time - timePassed);
               _quest.questAnim.SetBool("IsRunning", true);
            }
            else if (Input.GetMouseButtonDown(2) && _quest) // middle btn
            {
                canMove = false;
               // playerAnim.SetTrigger("ToDebout");
               // playerAnim.ResetTrigger("ToCouche");
               // playerAnim.ResetTrigger("ToAssis");
                
               GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;
               
               _quest.questAnim.SetFloat("ClockTime",Time.time - timePassed);
               _quest.questAnim.SetBool("IsRunning", true);
            }
        }
    }
}
