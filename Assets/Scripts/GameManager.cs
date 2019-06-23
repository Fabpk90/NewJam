using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public QuestionMainScript question;
    public PlayerController player;

    public Spawner spawner;
    
    public AudioClip musicLow;
    public AudioClip musicMedium;
    public AudioClip musicHigh;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!Instance)
        {
            Instance = this;
            
            player.QuestionStarted(question);
            Spawn(spawner.amount, spawner.toSpawn, spawner.position, spawner.radius);
            
            AudioSource.PlayClipAtPoint(musicLow, Vector3.zero);
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Spawn(uint amount, GameObject toSpawn, Vector3 position, float radius)
    {
        for (uint i = 0; i < amount; i++)
        {
            Vector2 v = (Random.insideUnitCircle * radius);
            Instantiate(toSpawn, new Vector3(v.x + position.x, position.y, v.y + position.z), Quaternion.identity);
        }
    }
}
