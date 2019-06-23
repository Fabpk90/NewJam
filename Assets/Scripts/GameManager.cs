using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public QuestionMainScript question;
    public PlayerController player;

    public Spawner spawner;
    
    [FormerlySerializedAs("musicLow")] public AudioClip[] pt1;
    [FormerlySerializedAs("musicMedium")] public AudioClip[] pt2;
    [FormerlySerializedAs("musicHigh")] public AudioClip pt3;


    public AudioClip loopLow;
    public AudioClip loopMedium;
    public AudioClip loopHigh;

    public int musicIndex; // 0->2->1
    public int intensity;

    private AudioSource sourcePlaying;
    private AudioSource sourcePlayingBuffer;

    private AudioSource actualSource;
    
    private AudioSource sourceLoop;

    public float waitTimeBeforeFirstQuestion;

    GameObject Rainbow;

    public bool lockUpdate = true;

    void Awake()
    {
        Rainbow = GameObject.Find("Rainbow");
        Rainbow.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!Instance)
        {
            Instance = this;

            musicIndex = 0;
            intensity = 0;

            sourcePlaying = gameObject.AddComponent<AudioSource>();
            sourceLoop = gameObject.AddComponent<AudioSource>();
            sourcePlayingBuffer = gameObject.AddComponent<AudioSource>();

            StartCoroutine(WaitAndLaunchQuestion(waitTimeBeforeFirstQuestion, question));
            //Spawn(spawner.amount, spawner.toSpawn, spawner.position, spawner.radius);

            sourcePlaying.clip = pt1[intensity];
            sourcePlaying.Play();

            actualSource = sourcePlaying;
            
            sourceLoop.clip = loopHigh;
            sourceLoop.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (!lockUpdate)
        {
            if (intensity == 1)
            {
                Debug.Log("intensity 1");
            }
            else if(intensity == 2)
            {
                Debug.Log("intensity 2");
                // Spawn flowers
                Spawn(100 , spawner.toSpawn, spawner.position, spawner.radius);
            }
            else if(intensity == 3)
            {
                Debug.Log("intensity 3");
                //Spawn flowers
                Spawn(300 , spawner.toSpawn, spawner.position, spawner.radius * 2);
                Rainbow.SetActive(true);
                // Display arc-en-ciel
            }

            lockUpdate = true;
        }

    }

    IEnumerator WaitAndLaunchQuestion(float amount, QuestionMainScript q)
    {
        yield return new WaitForSeconds(amount);
        player.QuestionStarted(q);
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

        StartCoroutine(CrossFade());
    }

    public void PlayReflexionSound()
    {
        actualSource.Stop();
        
        
        if (intensity == 0)
        {
            Debug.Log("intensity 1");
            sourceLoop.clip = loopLow;
        }
        else if(intensity == 1)
        {
            Debug.Log("intensity 2");
            // Spawn flowers
            Spawn(spawner.amount , spawner.toSpawn, spawner.position, spawner.radius);
            Spawn(spawner.amount , spawner.toSpawn, new Vector3(80f, 2f, 0f), spawner.radius);
            Spawn(spawner.amount , spawner.toSpawn, new Vector3(80f, 2f, 80f), spawner.radius);
            Spawn(spawner.amount , spawner.toSpawn, new Vector3(80f, 2f, -80f), spawner.radius);

            sourceLoop.clip = loopMedium;
        }
        else if(intensity == 2)
        {
            Debug.Log("intensity 3");
            //Spawn flowers
            Spawn(spawner.amount * 3 , spawner.toSpawn, spawner.position, spawner.radius * 2);
            Spawn(spawner.amount * 3 , spawner.toSpawn, new Vector3(80f, 2f, 0f), spawner.radius * 2);
            Spawn(spawner.amount * 3 , spawner.toSpawn, new Vector3(80f, 2f, 80f), spawner.radius * 2);
            Spawn(spawner.amount * 3 , spawner.toSpawn, new Vector3(80f, 2f, -80f), spawner.radius * 2);
            Rainbow.SetActive(true);
            // Display arc-en-ciel
            
            sourceLoop.clip = loopHigh;
        }
        
        sourceLoop.Play();
    }

    IEnumerator CrossFade()
    {
        AudioSource previousSource = null;
        if (actualSource == sourcePlaying)
        {
            previousSource = sourcePlaying;
            actualSource = sourcePlayingBuffer;
        }
            
        else if (actualSource == sourcePlayingBuffer)
        {
            previousSource = sourcePlayingBuffer;
            actualSource = sourcePlaying;
        }
            
        if(!sourceLoop.isPlaying)
            sourceLoop.Play();
        
        
        if (musicIndex == 0)
        {
            actualSource.clip = pt1[intensity];
        }
        else if(musicIndex == 1)
        {
            actualSource.clip = pt2[intensity];
        }
        else if(musicIndex == 2)
        {
            actualSource.clip = pt3;
            sourceLoop.Stop();
        }
        
        for (int i = 0; i < 10; i++)
        {
            previousSource.volume = 1 - i / 10;
            actualSource.volume = i/10;
            yield return new WaitForSeconds(0.1f);
        }
        
        actualSource.Play();
    }
}
