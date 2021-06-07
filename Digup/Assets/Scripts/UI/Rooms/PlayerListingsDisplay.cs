using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class PlayerListingsDisplay : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private PlayerListing _playerListing;

    private List<PlayerListing> _listings = new List<PlayerListing>();

    private GameObject LaunchButtonObject;

    private const byte EVENT_ISREADY = 14;

    public void Start()
    {
        LaunchButtonObject = GameObject.Find("LaunchButton");

        if (!PhotonNetwork.IsMasterClient)
        {
            LaunchButtonObject.SetActive(false);
        }
        else
        {
            LaunchButtonObject.SetActive(true);
            LaunchButtonObject.GetComponent<Button>().interactable = false;
        }

        foreach(KeyValuePair<int, Player> PlayerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(PlayerInfo.Value, PlayerInfo.Key);
        }


    }
    public void Update()
    {
        Debug.Log("Nombre de joueurs : " + PhotonNetwork.CurrentRoom.Players.Count);
        Debug.Log("Nombre de listings : " + _listings.Count);
        GetCurrentRoomPlayers();
        UpdateListings();

        foreach (KeyValuePair<int, Player> PlayerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            Debug.Log(PlayerInfo.Value.NickName + " is active : "+ PlayerInfo.Value.IsInactive);        
        }
    }

    public void AddPlayerListing(Player AddedPlayer, int PlayerID)
    {
        int Index = _listings.FindIndex(x => x.Player == AddedPlayer);
        if (Index == -1)
        {
            PlayerListing NewListing = Instantiate(_playerListing, _content);
            if (NewListing != null)
            {
                int MaxID = 1;

                foreach(PlayerListing Listing in _listings)
                {
                    if(Listing.Player != AddedPlayer && Listing.ID >= MaxID)
                    {
                        MaxID = Listing.ID;
                    }
                }

                if(PlayerID + 1 > MaxID)
                {
                    PlayerID = PlayerID + (PlayerID + 1 - MaxID);
                }

                NewListing.SetPlayerInfo(AddedPlayer, PlayerID);
                Debug.Log("Player " + NewListing.ID + " joined the room !");
                _listings.Add(NewListing);
            }
        }
    }

    private void GetCurrentRoomPlayers()
    {
        if (!PhotonNetwork.IsConnected)
            return;
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
            return;

        foreach (KeyValuePair<int, Player> PlayerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(PlayerInfo.Value, PlayerInfo.Key);
        }
    }

    private void UpdateListings()
    {
        int ReadyPlayersCount = 0;
        PlayerListing ListingToDelete = null;

        foreach (PlayerListing Listing in _listings)
        {
            Listing.GetComponent<RawImage>().texture = Resources.Load<Texture2D>("Textures/Sprites/GUI/Icons/Player" + Listing.ID);

            Debug.Log(Listing.Player.NickName + " ready : " + Listing.IsReady);

            SendEvent_PlayerIsReady(Listing.Player, Listing.IsReady);

            if (Listing.IsReady == true)
            {
                ReadyPlayersCount += 1;
                Listing.ReadyIcon().transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                Listing.ReadyIcon().transform.localScale = Vector3.zero;
            }

            if(!PhotonNetwork.CurrentRoom.Players.Values.Contains(Listing.Player))
            {
                ListingToDelete = Listing;
            }
        }

        if(ListingToDelete != null)
        {
            Destroy(ListingToDelete.gameObject);
            //PhotonNetwork.CurrentRoom.Players.Remove(ListingToDelete.ID);
            _listings.Remove(ListingToDelete);


            foreach (PlayerListing Listing in _listings)
            {
                if (Listing.ID != 1 && Listing.ID != 2)
                {
                    Listing.ID -= 1;
                }
            }
        }

        if (ReadyPlayersCount == _listings.Count)
        {
            LaunchButtonObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            LaunchButtonObject.GetComponent<Button>().interactable = false;
        }
    }

    public void OnClick_SetPlayerReady()
    {
        foreach (PlayerListing Listing in _listings)
        {
            if (Listing.Player.NickName == PhotonNetwork.NickName)
            {
                Listing.SwitchIsReady();
                SendEvent_PlayerIsReady(Listing.Player, Listing.IsReady);
            }
        }
    }

    public override void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += OnReceivedEvent;
    }

    public override void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= OnReceivedEvent;
    }

    private void OnReceivedEvent(EventData obj)
    {
        object[] ReceivedObjects = (object[])obj.CustomData;

        if (obj.Code == EVENT_ISREADY)
        {
            foreach (PlayerListing Listing in _listings)
            {
                if (Listing.Player == (Player) ReceivedObjects[0])
                {
                    Listing.IsReady = (bool) ReceivedObjects[1];
                }
            }
        }
    }

    private void SendEvent_PlayerIsReady(Player Gamer, bool IsReady)
    {
        object[] SendedObjects = new object[] { Gamer, IsReady };
        PhotonNetwork.RaiseEvent(EVENT_ISREADY, SendedObjects, RaiseEventOptions.Default, SendOptions.SendUnreliable);
    }
}