using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public QuestionMainScript question;
    public PlayerController player;

    public Spawner spawner;
    
    public AudioClip[] musicLow;
    public AudioClip[] musicMedium;
    public AudioClip[] musicHigh;


    public AudioClip loopLow;
    public AudioClip loopMedium;
    public AudioClip loopHigh;

    public int musicIndex; // 0->2->1
    public int intensity;

    private AudioSource source0;
    private AudioSource source01;
    
    private AudioSource source1;

    // Start is called before the first frame update
    void Start()
    {
        if (!Instance)
        {
            Instance = this;

            musicIndex = 0;
            intensity = 0;
            
            source0 = new AudioSource();
            source1 = new AudioSource();

            player.QuestionStarted(question);
            Spawn(spawner.amount, spawner.toSpawn, spawner.position, spawner.radius);

            source0.clip = musicLow[intensity];
            source0.Play();
            
            source1.clip = loopLow;
            source1.Play();
            
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

    public void ChangeMusicIndex(int index)
    {
        musicIndex = index;
        
        //TODO: crossfade music
        if (intensity == 0)
        {
            source0.clip = musicLow[musicIndex];
        }
        else if(intensity == 1)
        {
            source0.clip = musicMedium[musicIndex];
        }
        else if(intensity == 2)
        {
            source0.clip = musicHigh[musicIndex];
        }
       
        source0.Play();
    }
}
