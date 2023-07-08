using System.Collections;
using System.Collections.Generic;
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
    public float fireRate = 3f;
    private float nextFireTime;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
       // enemyBullet = GameObject.FindGameObjecstWithTag("enemyBullet");
        enemyBulletSpawn = GameObject.FindGameObjectWithTag("enemyBulletSpawn");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.x < 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (rb.velocity.x > 0f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        float distancefromPlayer = Vector2.Distance(player.position, transform.position);
        if (distancefromPlayer < followDistance && distancefromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            anim.SetBool("walk",true);
        }
        else if(distancefromPlayer< shootingRange && nextFireTime < Time.time)
            {
            nextFireTime = Time.time + fireRate;
            anim.SetBool("shoot",true);
            Instantiate(enemyBullet, enemyBulletSpawn.transform.position, Quaternion.identity);
            
        }
        else
        {
            anim.SetBool("shoot",false);
            anim.SetBool("walk",false);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, followDistance);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
