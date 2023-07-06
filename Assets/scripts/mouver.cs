using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class mouver : MonoBehaviour
{
    public float speed;
    private float inp;
    private Rigidbody2D rb;
    public float jump;
    private bool isonair;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inp = Input.GetAxis("Horizontal");
        rb.velocity = new  Vector2(inp * speed, rb.velocity.y);
        if(Input.GetButtonDown("Jump")&& !isonair)
        {
            rb.AddForce(new Vector2(rb.velocity.x,jump));
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("gnd"))
        {
            isonair = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("gnd")) isonair = true;
    }
    
}
