using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cntrl : MonoBehaviour
{
    private Animator Anim;
    public Rigidbody2D parrent;//for running animation
    public GameObject parrentGO;//for jumping animation
    public GameObject shootgo;//for shooting animation
    private bool jumping;
    private bool fireGreenFlag;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
       // parrentGO = GameObject.FindGameObjectWithTag("parrentGO");
        shootgo = GameObject.FindGameObjectWithTag("shootgo");
    }

    // Update is called once per frame
    void Update()
    {

        if(parrent.velocity.x <0f || parrent.velocity.x >0f)
        {
            Anim.SetBool("startRun", true);
        }
        else
        {
            Anim.SetBool("startRun", false);
        }
        //////////////////////////////////////////
        jumping = parrentGO.gameObject.GetComponent<mouver>().isonair;
        if (jumping)
        {
            Anim.SetBool("jump", true);
        }
        else
        {
            Anim.SetBool("jump", false);
        }
        //fireGreenFlag = shootgo.gameObject.GetComponent<shoot>().canFire;
        if (Input.GetMouseButton(0) && fireGreenFlag)
        {
            Anim.SetBool("shoot", true);
        }
        else
        {
            Anim.SetBool("shoot",false);
        }

    }
}
