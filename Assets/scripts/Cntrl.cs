using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cntrl : MonoBehaviour
{
    private Animator Anim;
    public Rigidbody2D parrent;//for running animation
    public GameObject parrentGO;//for jumping animation
   // public GameObject shootgo;//for shooting animation
    public shoot shoot;
    private bool jumping;
    private bool fireGreenFlag;
    private float time;
    public float shoot_anim_time;
    // Start is called before the first frame update

     void Awake()
    {
        Anim = GetComponent<Animator>();
        
    }
    void Start()
    {

        
       // parrentGO = GameObject.FindGameObjectWithTag("parrentGO");
       // shootgo = GameObject.FindGameObjectWithTag("shootgo");
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
        

       /* if (Input.GetMouseButton(0) && shoot.canFire )
        {
            Anim.SetBool("shoot", true);
            time += Time.deltaTime;
            if(time > shoot_anim_time*Time.deltaTime)
            {
                time = 0f;
                Anim.SetBool("shoot", false);
            }
        }*/


    }
}
