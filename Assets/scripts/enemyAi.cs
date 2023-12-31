using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEngine;

public class enemyAi : MonoBehaviour
{
    public float speed;
    private Transform player;
    public float followDistance;
    public float shootingRange;
    public GameObject enemyBullet;
    public GameObject enemyBulletSpawn;
    private Animator anim;
    public float fireRate;
    private float timeOffiring;
    private bool canFire;
    private Rigidbody2D rb;
    private Vector2 dir;
    public bool gameOver;
    private bool isdead ;
    private float deadTimer;
    public float deadAnimTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        //enemyBulletSpawn = GameObject.FindGameObjectWithTag("enemyBulletSpawn");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameOver = false;
        deadTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        dir = player.position - transform.position;
        if (Mathf.Sign(dir.x) ==1 )
        {
            transform.localScale = new Vector3(-1,1,1);        }

        else if (Mathf.Sign(dir.x) == -1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
       
        float distancefromPlayer = Vector2.Distance(player.position, transform.position);
        if (distancefromPlayer < followDistance && distancefromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            anim.SetBool("walk",true);
        }
        else if(distancefromPlayer <= shootingRange && canFire && !gameOver && !isdead)
            {
            Instantiate(enemyBullet, enemyBulletSpawn.transform.position, Quaternion.identity);
            anim.SetTrigger("shootTrigger");
            canFire = false;
            
            
        }
        else
        {
           
            anim.SetBool("walk",false);
        }
        if(!canFire) {
           
            timeOffiring += Time.deltaTime;
            if (timeOffiring > Random.Range( fireRate,fireRate+ 0.9f))
            {
                canFire = true;
                timeOffiring = 0f;
                
            }  
        }
        if(isdead)
        {
            deadTimer += Time.deltaTime;
            if (deadTimer > deadAnimTime)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, followDistance);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            anim.SetTrigger("death");
            isdead = true;

        }
    }
}
