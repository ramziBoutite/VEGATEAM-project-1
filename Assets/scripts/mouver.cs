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
    public bool isonair;
    private Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inp = Input.GetAxis("Horizontal");
        rb.velocity = new  Vector2(inp * speed, rb.velocity.y);
        if(inp<0f)
        {
            Anim.SetBool("startRun", true);
            transform.localScale = new Vector3(-1, 1, 1); 
        }
        else if (inp>0f)
        { 
            Anim.SetBool("startRun",true);
            transform.localScale = new Vector3(1, 1, 1); 
        }
        else
        {
            Anim.SetBool("startRun", false);
        }
        if(Input.GetButtonDown("Jump")&& !isonair)
        {
            rb.AddForce(new Vector2(rb.velocity.x,jump));
        }

    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("gnd"))
        {
            Anim.SetBool("jump", false);
            isonair = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (Mathf.Abs(rb.velocity.y) > 1f)
        {
            Anim.SetBool("jump", true);
        }
       
        if (other.gameObject.CompareTag("gnd")) isonair = true;
    }
    
}
