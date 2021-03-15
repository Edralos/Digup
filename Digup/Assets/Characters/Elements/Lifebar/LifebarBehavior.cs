using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifebarBehavior : MonoBehaviour
{
    public Transform HealthTransform;
    public float SlideTime;
    public void Set(float amount)
    {
        StartCoroutine(SetRoutine(amount));
    }


    private IEnumerator SetRoutine(float amount)
    {
        for (float i = 0.01f; i < SlideTime; i += Time.deltaTime)
        {
            HealthTransform.localScale = Vector3.Lerp(HealthTransform.localScale, new Vector3(amount, HealthTransform.localScale.y, HealthTransform.localScale.z), Mathf.Min(1, i / SlideTime));
            yield return null;

        }

    }
    

    
}
