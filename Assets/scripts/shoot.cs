using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour

{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    private float timer;
    public float timeBetweenFiring;
    public bool canFire;
     
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rot2 = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg; 

         

        transform.rotation = Quaternion.Euler(0,0,rot2);
        

        if(!canFire)
        {
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer =0;
            }
        }

        if (Input.GetMouseButton(0) && canFire)
{
    canFire = false;
    if (Input.GetKey(KeyCode.LeftArrow))
    {
        Instantiate(bullet, bulletTransform.position, Quaternion.Euler(0, 0, 180f));
    }
    else
    {
        Instantiate(bullet, bulletTransform.position, Quaternion.identity);
    }
}

           
            
            

        }
    }

     








