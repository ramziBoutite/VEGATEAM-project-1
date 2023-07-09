using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mine : MonoBehaviour
{
    private bool isdead;
    private float deadTimer;
    public float deadAnimTime;
    private Animator anim;
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isdead)
        {
            deadTimer += Time.deltaTime;
            if (deadTimer > deadAnimTime)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))

        {
            FindObjectOfType<AudioManager>().Play("Mine");
            anim.SetBool("explode", true);
            isdead = true;
        }
        
    }
}
