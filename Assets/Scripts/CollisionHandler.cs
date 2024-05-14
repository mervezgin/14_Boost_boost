using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Fuel":
                Debug.Log("You picked up fuel");
                break;
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                Debug.Log("Congrats, yo, You finished!");
                break;
            default:
                ReloadLevel();
                break;
        }
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("Boost"); // you can write integer 0 or SceneManager.GetActiveScene().buildIndex
    }
}
