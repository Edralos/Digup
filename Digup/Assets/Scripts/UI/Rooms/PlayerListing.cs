﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using ExitGames.Client.Photon;

public class PlayerListing : MonoBehaviourPun
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private GameObject _readyIcon;

    private const byte SET_READY_EVENT = 0;

    public Player Player { get; private set; }

    public void SetPlayerInfo(Player Player)
    {
        this.Player = Player;
        _text.text = Player.NickName;
        _readyIcon.transform.localScale = Vector3.zero;
    }

    public bool IsReady { get; set; }

    public GameObject ReadyIcon()
    {
        return _readyIcon;
    }

    public void SetIsReady()
    {
        IsReady = true;
        object[] SendedObjects = new object[] { Player, IsReady };
        PhotonNetwork.RaiseEvent(SET_READY_EVENT, SendedObjects, RaiseEventOptions.Default, SendOptions.SendUnreliable);
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
        if(obj.Code == SET_READY_EVENT)
        {
            object[] ReceivedObjects = (object[]) obj.CustomData;
            if (Player == (Player) ReceivedObjects[0])
            {
                IsReady = (bool) ReceivedObjects[1];
            }
        }
    }
}