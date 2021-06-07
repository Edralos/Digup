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

    public void SetPlayerInfo(Player Player, int ID)
    {
        this.Player = Player;
        this.ID = ID;
        _text.text = Player.NickName;
        _readyIcon.transform.localScale = Vector3.zero;
    }

    public void SwitchIsReady()
    {
        IsReady = !IsReady;  
    }

    public GameObject ReadyIcon()
    {
        return _readyIcon;
    }
}