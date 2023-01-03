using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuGameObject;
    public GameObject menuButtonGameObject;    
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");        
    }
    public void StopAndResume()
    {        
        menuGameObject.SetActive(!menuGameObject.activeInHierarchy);
        menuButtonGameObject.SetActive(!menuButtonGameObject.activeInHierarchy);
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;
        else
            Time.timeScale = 0f;
    }
}
