using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SartMenu : MonoBehaviour
{
   public void StartGame()
   {
    Time.timeScale =1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
   }
   public void QuitGame()
{
    Application.Quit();
}
}
