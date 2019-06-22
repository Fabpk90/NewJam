using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMainScript : MonoBehaviour
{
    private string quest;
    public Animator questAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        questAnim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
