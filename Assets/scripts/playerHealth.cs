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
    private float deadTimer;
    public float deadSoundTime;
    // Start is called before the first frame update
    void Start()
    {
        maxhealth = health;

    }



    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxhealth, 0, 1);
        if (health <= 0 && !isDead)
        {
            

            GameObject.FindGameObjectWithTag("enemy").GetComponent<enemyAi>().gameOver = true;

            isDead = true;
            if (isDead)
            {
                deadTimer -= Time.deltaTime; if (deadTimer > deadSoundTime) { gameObject.SetActive(false); }



               
                }
                
               
            FindObjectOfType<AudioManager>().Play("Death");
            
            
            SceneManager.LoadScene("GameOver");

           

    }
                
            }


        }
       
    
    

             
                  
