using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour

{
    public static bool GameIsPaused = false;
     
     

    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Start(){
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
             pauseMenuUI.SetActive(true);
             
             
     Time.timeScale = 0f;
     GameIsPaused = true;
        }
    }
    public void Resume(){
     pauseMenuUI.SetActive(false);
     Time.timeScale = 1f;
     GameIsPaused = false;
    }
    public void restart()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     pauseMenuUI.SetActive(false);
     Time.timeScale = 1f;
     GameIsPaused= false;

   }
    
    public void restartfromDEATH()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
     pauseMenuUI.SetActive(false);
     Time.timeScale = 1f;
     GameIsPaused= false;

   }
    

    
    
    
        
    }

