using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour

{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
   
    public float force;
    
    void Start()
    {
         mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
         rb = GetComponent<Rigidbody2D>();
         mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
         Vector3 direction = mousePos - transform.position;
         
       



        
        
            rb.velocity = new Vector2(direction.x, 0).normalized * force;
        
        
         
        
            
       
        
       }
       
        
       
    


    

    // Update is called once per frame
    void Update()
    {
          
}
}
