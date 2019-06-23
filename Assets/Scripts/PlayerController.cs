﻿using System.Collections;
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


    public float firstPalier;
    public float secondPalier;
    public float thirdPalier;
    
    
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
        
        GameManager.Instance.ChangeMusicIndex(1);
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
                Action();
                
                
            }
            else if (Input.GetMouseButtonDown(1) && _quest) // right
            {
                canMove = false;
               // playerAnim.SetTrigger("ToCouche");
               // playerAnim.ResetTrigger("ToAssis");
               // playerAnim.ResetTrigger("ToDebout");
                
               GetComponentInChildren<MeshRenderer>().material.color = Color.green;
               
               Action();
            }
            else if (Input.GetMouseButtonDown(2) && _quest) // middle btn
            {
                canMove = false;
               // playerAnim.SetTrigger("ToDebout");
               // playerAnim.ResetTrigger("ToCouche");
               // playerAnim.ResetTrigger("ToAssis");
                
               GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;
               
               Action();
            }
        }
    }

    private void Action()
    {
        var timeElapsed = Time.time - timePassed;

        if (timeElapsed <= firstPalier)
        {
            GameManager.Instance.intensity = 0;
        }
        else if (timeElapsed <= secondPalier)
        {
            GameManager.Instance.intensity = 1;
        }
        else if (timeElapsed <= thirdPalier)
        {
            GameManager.Instance.intensity = 2;
        }
        
        GameManager.Instance.ChangeMusicIndex(2);
        
        if (!_quest.isSpawning)
        {
            _quest.questAnim.SetFloat("ClockTime", timeElapsed);
            _quest.questAnim.SetBool("IsRunning", true);
        }
        else
        {
            GameManager.Instance.Spawn(_quest.amount, _quest.toSpawning, _quest.position, 5f);
        }
        
        
    }
}
