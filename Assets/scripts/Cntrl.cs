using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cntrl : MonoBehaviour
{
    private Animator Anim;
    public Rigidbody2D parrent;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
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
        if (parrent.velocity.y < 0f || parrent.velocity.y > 0)
        {
            Anim.SetBool("jump", true);
        }
        else
        {
            Anim.SetBool("jump", false);
        }


    }
}
