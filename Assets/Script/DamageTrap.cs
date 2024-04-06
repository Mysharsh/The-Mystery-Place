using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrap : MonoBehaviour
{
    [HideInInspector]
    public float damageAmount = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            HealthSystem healthSystem = other.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                healthSystem.TakeDamage(damageAmount);
            }
        }
    }
}
