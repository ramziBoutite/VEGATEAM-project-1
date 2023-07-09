using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    private GameObject player;
    public float speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        Vector2 movdir = (player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(movdir.x, movdir.y+ Random.Range(0.5f,1.25f));
        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
