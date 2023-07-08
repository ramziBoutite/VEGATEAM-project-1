using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start() {
      Cursor.visible = false;
      Cursor.lockState =CursorLockMode.Locked;
   }
    void Update() {
      if(gameOverUI.activeInHierarchy)
      {
          Cursor.visible = true;
      Cursor.lockState =CursorLockMode.Locked;
      }else{
          Cursor.visible = false;
      Cursor.lockState =CursorLockMode.Locked;
      }
   }
   public GameObject gameOverUI;

   public void gameOver(){
    gameOverUI.SetActive(true);
   }
   public void restart()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }
   public void mainMenu(){
    SceneManager.LoadScene("MainMenu");
   }
   public void quit(){
    Application.Quit();
   }
}
