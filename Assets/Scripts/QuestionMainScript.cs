using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionMainScript : MonoBehaviour
{
    public string quest;
    public Animator questAnim;

    public bool isSpawning;
    public GameObject toSpawning;
    public uint amount;
    public Vector3 position;
    
    // Start is called before the first frame update
    void Awake()
    {
        questAnim = GetComponentInChildren<Animator>();
    }
}
