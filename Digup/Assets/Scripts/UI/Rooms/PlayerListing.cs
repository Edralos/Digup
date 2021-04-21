using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerListing : MonoBehaviour, IPunObservable
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private GameObject _readyIcon;

    public Player Player { get; private set; }
    public int ID { get; set; }

    public void SetPlayerInfo(Player Player, int ID)
    {
        this.Player = Player;
        this.ID = ID;
        _text.text = Player.NickName;
        _readyIcon.transform.localScale = Vector3.zero;
    }

    public bool IsReady { get; private set; }

    public void SetReadyToBegin()
    {
        _readyIcon.transform.localScale = new Vector3(1, 1, 1);
    }

    public void OnPhotonSerializeView(PhotonStream Stream, PhotonMessageInfo Message)
    {
        if(Stream.IsWriting)
        {
            Stream.SendNext(_readyIcon.transform.localScale);
        }
        if (Stream.IsReading)
        {
            _readyIcon.transform.localScale = (Vector3) Stream.ReceiveNext();
        }
    }
}