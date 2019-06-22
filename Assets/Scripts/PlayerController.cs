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
        
        //anim.SetBool("monBool", true/false);
    }

    /// <summary>
    /// Called by the question manager to start the timer
    /// </summary>
    public void QuestionStarted()
    {
        timePassed = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (Input.GetMouseButtonDown(0)) // left button
            {
                canMove = false;
            }
            else if (Input.GetMouseButtonDown(1)) // right
            {
                canMove = false;
            }
            else if (Input.GetMouseButtonDown(2))
            {
                canMove = false;
            }
        }
    }
}
