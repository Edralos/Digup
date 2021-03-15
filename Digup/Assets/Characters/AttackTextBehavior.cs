using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AttackTextBehavior : MonoBehaviour
{
    public Transform TextTransform;
    public TextMesh Text;
    public float TimeFade;

    private Color originColor;
    private Color targetColor;
    private Vector3 origin;
    private Vector3 target;


    // Start is called before the first frame update
    void Start()
    {
        originColor = new Color(Text.color.r, Text.color.g, Text.color.b, Text.color.a);
        targetColor = new Color(Text.color.r, Text.color.g, Text.color.b, 0);
        origin = new Vector3(TextTransform.localPosition.x, TextTransform.localPosition.y, TextTransform.localPosition.z);
        target = new Vector3(TextTransform.localPosition.x - 3, TextTransform.localPosition.y + 5, TextTransform.localPosition.z);


    }

    public void DisplayText(string txt)
    {
        Text.text = txt;
        StartCoroutine(DisplayCoroutine());
    }


    private IEnumerator DisplayCoroutine()
    {
        for (float i = 0f; i < TimeFade; i+= Time.deltaTime)
        {
            TextTransform.localPosition = Vector3.Lerp(TextTransform.localPosition, target, Mathf.Min(1, i /(int)(TimeFade * 3)));
            Text.color = Color.Lerp(originColor, targetColor, Mathf.Min(1, i / TimeFade));
            yield return null;
        }
        Debug.Log("end for");
        TextTransform.localPosition = origin;
        Text.color = originColor;
        Text.text = "";
        yield return null;

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
