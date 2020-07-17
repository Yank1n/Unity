using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody bullet;
    private float forceSpeed = 5f;
    private float TopBound = 12f;
    private float BottomBound = -60f;
    public bool isHitted = false;

    private void Start()
    {
        bullet = GetComponent<Rigidbody>();
    }
    void Update()
    {
        bullet.AddForce(transform.forward * forceSpeed, ForceMode.Impulse);
        if (transform.position.x >= TopBound || 
            transform.position.z >= TopBound || 
            transform.position.x <= BottomBound || 
            transform.position.z <= BottomBound)
            Destroy(gameObject);
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Hitted");
            isHitted = true;
        }
    }*/
}
