using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private int playedScene;

   // loads next scene based on the scene ordering defined on Unity > build settings
   public void LoadNextScene()
   {
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        playedScene = PlayerPrefs.GetInt("playedScene", 1);
        if (currentSceneIndex >= playedScene)
        {
            PlayerPrefs.SetInt("playedScene", currentSceneIndex);
        }
        
      SceneManager.LoadScene(currentSceneIndex + 1);
   }

   // loads scene by its name
   public void LoadSceneByName(string sceneName)
   {
      SceneManager.LoadScene(sceneName: sceneName);
   }

   // always the 0 indexed scene
   public void LoadStartScene()
   {
      // FindObjectOfType<GameState>().ResetState();
      SceneManager.LoadScene(0);
   }

   public void Quit()
   {
      Application.Quit();
   }

   /**
    * Hides the mouse cursor.
    */
   public void Start()
   {
      Cursor.visible = false;
   }
}
