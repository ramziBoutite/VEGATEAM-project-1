using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
//     void Start() {
//       Cursor.visible = false;
      
//    }
//     void Update() {
//       if(gameOverUI.activeInHierarchy)
//       {
//           Cursor.visible = true;
      
//       }else{
//           Cursor.visible = false;
      
//       }
//    }
   public GameObject gameOverUI;


   public void gameOver(){
    SceneManager.LoadScene("GameOver");
   }
    public void restartfromDEATH()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
 

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
