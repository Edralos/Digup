using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifebarBehavior : MonoBehaviour
{
    public Transform HealthTransform;
    private Vector3 newHealth;

    public void Set(float amount)
    {
        newHealth = new Vector3(amount, HealthTransform.localScale.y, HealthTransform.localScale.z);
    }

    private void Start()
    {
        newHealth = HealthTransform.localScale;
    }

    private void Update()
    {
        if (newHealth != null)
        {
            HealthTransform.localScale = Vector3.Lerp(HealthTransform.localScale, newHealth, 0.05f);
        }
    }
}
