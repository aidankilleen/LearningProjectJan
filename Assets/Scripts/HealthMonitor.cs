using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMonitor : MonoBehaviour
{

    public int health = 100;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            health -= 10;
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            health -= 20;
        } 
        Debug.Log("Health: " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Debug.Log("Increasing score");

            health = 100;
            Destroy(other.gameObject);
        }
    }
}

