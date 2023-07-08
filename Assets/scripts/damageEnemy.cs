using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageEnemy : MonoBehaviour
{ 
    private GameObject other ;
    // Start is called before the first frame update
    void Start()
    {
        other = GameObject.FindGameObjectWithTag("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
         void OnCollisionEnter2D(Collision2D other) {
       if(other.gameObject.CompareTag("Enemy")){
        Destroy(gameObject);
       } 
    }
}
}