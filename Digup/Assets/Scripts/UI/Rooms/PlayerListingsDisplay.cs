using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PlayerListingsDisplay : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private PlayerListing _playerListing;

    private List<PlayerListing> _listings = new List<PlayerListing>();

    public void Start()
    {
        GetCurrentRoomPlayers();
    }

    public void Update()
    {
        GetCurrentRoomPlayers();
    }

    public void AddPlayerListing(Player NewPlayer)
    {
        PlayerListing Listing = Instantiate(_playerListing, _content);

        if (Listing != null)
        {
            Listing.SetPlayerInfo(NewPlayer);
            _listings.Add(Listing);
        }
    }

    public override void OnPlayerEnteredRoom(Player NewPlayer)
    {
        AddPlayerListing(NewPlayer);
    }

    public override void OnPlayerLeftRoom(Player OtherPlayer)
    {
        int Index = _listings.FindIndex(x => x.Player == OtherPlayer);
        if (Index != -1)
        {
            Destroy(_listings[Index].gameObject);
            _listings.RemoveAt(Index);
        }
    }

    private void GetCurrentRoomPlayers()
    {
        foreach (KeyValuePair<int, Player> PlayerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            bool AlreadyInList = false;

            foreach (PlayerListing ShowedListing in _listings)
            {
                if(ShowedListing.Player == PlayerInfo.Value)
                {
                    AlreadyInList = true;
                    break;
                }
                    
            }

            if(!AlreadyInList)
            {
                AddPlayerListing(PlayerInfo.Value);
            }
        }
    }
}
