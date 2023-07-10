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
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        Vector3 rotation = transform.position - mousePos;
        float rot2 = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot2 );
        Destroy(this.gameObject, 1.8f);

    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }

}