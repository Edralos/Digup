using UnityEngine;

public static class Transforms
{
    public static void DestroyChildren(this Transform Children, bool DestroyImmediately = false)
    {
        foreach(Transform Child in Children)
        {
            if(DestroyImmediately)
            {
                MonoBehaviour.DestroyImmediate(Child.gameObject);
            }
            else
            {
                MonoBehaviour.Destroy(Child.gameObject);
            }
        }
    }

}
