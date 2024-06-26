using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip successClip;
    [SerializeField] AudioClip crashClip;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crashParticle;

    float levelLoadDelay = 2f;
    bool isTransitioning = false;
    bool collisionDisabled = false;

    void Update()
    {
        RespondToDebugKeys();
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning|| collisionDisabled) { return; }
 
            switch (other.gameObject.tag)
            {
                case "Fuel":
                    Debug.Log("You picked up fuel");
                    break;
                case "Friendly":
                    Debug.Log("This thing is friendly");
                    break;
                case "Finish":
                    StartSuccessSequence();
                    Debug.Log("Congrats, yo, You finished!");
                    break;
                default:
                    StartCrashSequence();
                    break;
            }
        
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex); // you can write integer 0 or scene name
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0; 
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        crashParticle.Play();
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(crashClip);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        successParticle.Play();
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(successClip);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled; //toggle collision 
        }
    }
}
