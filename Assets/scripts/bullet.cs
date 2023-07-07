using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour

{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public mouver dir;
    public float force;
    
    void Start()
    {
         mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
         rb = GetComponent<Rigidbody2D>();
       
        
       }
       
        
       
    


    

    // Update is called once per frame
    void Update()
    {
          mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
         Vector3 direction = mousePos - transform.position;
         
       



          if (direction.x > 0f && dir.transform.localScale == new Vector3(1,1,1) )
        {
            rb.velocity = new Vector2(direction.x, 0).normalized * force;
        }
        else
        {
           
            Destroy(gameObject);
        }
         if (direction.x < 0f && dir.transform.localScale == new Vector3(-1,1,1) )
        {
            rb.velocity = new Vector2(direction.x, 0).normalized * force;
        }
        else
        {
           
            Destroy(gameObject);
        }
    }
}
