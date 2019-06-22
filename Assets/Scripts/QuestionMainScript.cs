using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMainScript : MonoBehaviour
{
    public string quest;
    public Animator questAnim;
    
    // Start is called before the first frame update
    void Awake()
    {
        questAnim = GetComponentInChildren<Animator>();
    }
}
