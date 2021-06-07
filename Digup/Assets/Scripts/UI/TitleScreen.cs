using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    GameObject[] MenuButtons;

    // Start is called before the first frame update
    void Start()
    {
        MenuButtons = GameObject.FindGameObjectsWithTag("Button");

        foreach(GameObject MenuButton in MenuButtons)
        {
            MenuButton.SetActive(false);
        }

        this.transform.localPosition = new Vector3(17, -200, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.localPosition.y < 118)
        {
            this.transform.localPosition += new Vector3(0, 1, 0);

            foreach(GameObject MenuButton in MenuButtons)
            {
                float TitlePosition = this.transform.localPosition.y;

                if (TitlePosition >= MenuButton.GetComponent<Transform>().localPosition.y*8)
                {
                    MenuButton.SetActive(true);
                }
            }
        }

        if(this.transform.localScale.y > 1)
        {
            this.transform.localScale = new Vector3(1,1,0);
        }
    }
}
