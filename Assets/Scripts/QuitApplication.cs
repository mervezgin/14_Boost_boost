using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0; // Oyunu durdurur
            Debug.Log("we pushed escape");
        }
        
    }
    /*
    // Update is called once per frame
    void Update()
    {

        if (EditorApplication.isPlaying && Input.GetKeyDown(KeyCode.Escape))
        {
            EditorApplication.isPlaying = false;
            Debug.Log("we pushed escape");
        }
    }
    
    void PlayModeEsc()
    {
        // EditorApplication.update, editör her güncellendiğinde çağrılır.
        //EditorApplication.update += Update;
    }
    */
}
