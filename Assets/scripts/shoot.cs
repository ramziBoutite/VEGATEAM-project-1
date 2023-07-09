using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public Transform aimTransform;
    private float timer;
    public float timeBetweenFiring;
    public bool canFire;
    public GameObject mov;
    public Animator upShootAnim;

    

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        if(mov.transform.localScale==new Vector3(1,1,1)){
          Vector3 rotation = mousePos - transform.position;
          float rot2 = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot2);

        }else if(mov.transform.localScale==new Vector3(-1,1,1)){
            Vector3 rotation = transform.position - mousePos;
            float rot2 = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot2);
            

        }
        if (Input.GetMouseButton(0) && canFire)
        {

            FindObjectOfType<AudioManager>().Play("Shoot");
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            upShootAnim.SetBool("shoot", true);

        }
        else if (!canFire)
        {
            upShootAnim.SetBool("shoot", false);
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
    }
    
}
