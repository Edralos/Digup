using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class PlayerListing : MonoBehaviourPun
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private GameObject _readyIcon;

    public Player Player { get; private set; }
    public int ID { get; set; }
    public bool IsReady { get; set; }

    private const byte SET_READY_EVENT = 14;

    public void SetPlayerInfo(Player Player, int ID)
    {
        this.Player = Player;
        this.ID = ID;
        _text.text = Player.NickName;
        _readyIcon.transform.localScale = Vector3.zero;
    }

    public void SetIsReady()
    {
        IsReady = true;
        object[] SendedObjects = new object[] { Player, IsReady };
        PhotonNetwork.RaiseEvent(SET_READY_EVENT, SendedObjects, RaiseEventOptions.Default, SendOptions.SendUnreliable);
    }

    public GameObject ReadyIcon()
    {
        return _readyIcon;
    }

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived;
    }

    private void NetworkingClient_EventReceived(EventData obj)
    {
        if (obj.Code == SET_READY_EVENT)
        {
            object[] ReceivedObjects = (object[]) obj.CustomData;

            if (Player == (Player) ReceivedObjects[0])
            {
                IsReady = (bool) ReceivedObjects[1];
            }
        }
    }
}