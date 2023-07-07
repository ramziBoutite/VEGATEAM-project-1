using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour

{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public mouver mov2;
    void Start()
    {
         mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
         rb = GetComponent<Rigidbody2D>();
         mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
         Vector3 direction = mousePos - transform.position;
         
       



          if (direction.x > 0f)
        {
            rb.velocity = new Vector2(direction.x, 0).normalized * force;
        }
        else
        {
           
            Destroy(gameObject);
        }
       }
       
        
       
    


    

    // Update is called once per frame
    void Update()
    {
        
    }
}
