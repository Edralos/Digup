using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerListing : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    public Player Player { get; private set; }

    public void SetPlayerInfo(Player Player)
    {
        this.Player = Player;
        _text.text = Player.NickName;
    }
}