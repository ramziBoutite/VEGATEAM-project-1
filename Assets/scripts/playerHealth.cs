using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour

{
    public float health;
    public float maxhealth;
    public Image healthBar;
    public GameManager gameManager;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        maxhealth=health;
        
    }
    

    
    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxhealth, 0, 1);
        if(health <= 0 && !isDead){

            
            GameObject.FindGameObjectWithTag("enemy").GetComponent<enemyAi>().gameOver = false;

            GameObject.FindGameObjectWithTag("enemy").GetComponent<enemyAi>().gameOver = true;

            isDead = true;
            gameObject.SetActive(false);
         
FindObjectOfType<AudioManager>().Play("Death");
     IEnumerator Start()
    {
        yield return StartCoroutine(FirstTask());
        
    }
    

     IEnumerator FirstTask()
    {
        
        print("wait");
        yield return new WaitForSeconds(4f);
    }

     
    SceneManager.LoadScene("GameOver");
}

             
            }         
            
        }
    
    

             
                  
