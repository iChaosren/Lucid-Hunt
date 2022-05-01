using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public int damageAmount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthController healthController = collision.GetComponent<HealthController>();
        if(healthController != null)
            healthController.DoDamage(damageAmount);
        Destroy(this);
    }
}
