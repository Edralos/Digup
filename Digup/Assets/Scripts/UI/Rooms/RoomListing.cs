using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    public RectTransform _isProtected;

    public RoomInfo RoomInfo { get; private set; }

    

    public void OnClick_CallEnterRoomBox()
    {
        Debug.Log(RoomInfo.CustomProperties);

        GameObject RoomSelectionMenu = GameObject.Find("RoomSelectionMenu");

        if ((bool) RoomInfo.CustomProperties["IsProtected"] == true)
        {
            if (GameObject.Find("RoomCreationCanvas").GetComponent<Transform>().localScale != Vector3.zero)
            {
                GameObject.Find("RoomCreationCanvas").GetComponent<Transform>().localScale = Vector3.zero;
            }

            GameObject.Find("EnterRoomCanvas").GetComponent<Transform>().localScale = new Vector3(1, 1, 1);

            Text RoomName = GameObject.Find("EnterRoomCanvas").transform.GetChild(0).GetComponent<Text>();

            RoomName.text = "You want to join\n" + _text.text + " : ";

            RoomSelectionMenu.GetComponent<RoomManager>().SetSelectedRoom(RoomInfo);
        }
        else
        {
            RoomSelectionMenu.GetComponent<RoomManager>().JoinRoom(RoomInfo.Name);
        }
    }

    public void SetRoomInfo(RoomInfo Info)
    {
        RoomInfo = Info;
        _text.text = " "+Info.Name;

        if ((bool) RoomInfo.CustomProperties["IsProtected"] == false)
        {
            _isProtected.localScale = Vector3.zero;
        }
    }
}
