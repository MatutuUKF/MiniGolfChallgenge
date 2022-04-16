using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float force, radius,up;
    public ParticleSystem explosion;
    Vector3 explosion_position;

    private void Start()
    {
        explosion_position = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ball") {
            other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(force,transform.position,radius,up);
            
            Instantiate(explosion, explosion_position ,Quaternion.identity);

            Destroy(gameObject);

        Debug.Log(other.gameObject.name +"Vybuchol"); 
        }
         
    }
}

