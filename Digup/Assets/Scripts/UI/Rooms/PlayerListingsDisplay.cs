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

    public void Update()
    {
        GetCurrentRoomPlayers();
    }

    public void AddPlayerListing(KeyValuePair<int, Player> PlayerInfo)
    {
        PlayerListing Listing = Instantiate(_playerListing, _content);

        if (Listing != null)
        {
            Listing.SetPlayerInfo(PlayerInfo.Value, PlayerInfo.Key);
            _listings.Add(Listing);
        }
    }

    public override void OnPlayerLeftRoom(Player OtherPlayer)
    {
        int Index = _listings.FindIndex(x => x.Player == OtherPlayer);
        if (Index != -1)
        {
            Destroy(_listings[Index].gameObject);
            _listings.RemoveAt(Index);

            foreach(PlayerListing Listing in _listings)
            {
                if (Listing.ID != 1 && Listing.ID != 2)
                {
                    Listing.ID -= 1;
                }
            }
        }
    }

    private void GetCurrentRoomPlayers()
    {
        foreach (KeyValuePair<int, Player> PlayerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            bool AlreadyInList = false;

            foreach (PlayerListing ShowedListing in _listings)
            {
                ShowedListing.GetComponent<RawImage>().texture = Resources.Load<Texture2D>("Textures/Sprites/GUI/Icons/Player" + ShowedListing.ID);

                if (ShowedListing.Player == PlayerInfo.Value)
                {
                    AlreadyInList = true;

                    if (ShowedListing.IsReady == true)
                    {
                        ShowedListing.ReadyIcon().transform.localScale = new Vector3(1, 1, 1);
                    }
                    break;
                }
                    
            }

            if((!AlreadyInList))
            {
                AddPlayerListing(PlayerInfo);
            }
        }
    }

    public void OnClick_SetPlayerReady()
    {
        foreach(PlayerListing Listing in _listings)
        {
            if(Listing.Player.NickName == PhotonNetwork.NickName)
            {
                Listing.SetIsReady();
            }
        }
    }
}
