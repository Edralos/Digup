
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class AvatarListingsDisplay : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private PlayerListing _avatarListing;

    private List<PlayerListing> _listings = new List<PlayerListing>();

    public void Awake()
    {
        if(PhotonNetwork.InRoom)
        {
            GameObject.Find("MenuTitle").GetComponent<Text>().text = PhotonNetwork.CurrentRoom.Name;
        }

        foreach(KeyValuePair<int, Player> PlayerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            int Index = _listings.FindIndex(x => x.Player == PlayerInfo.Value);
            if (Index == -1)
            {
                PlayerListing NewListing = Instantiate(_avatarListing, _content);
                if (NewListing != null)
                {
                    NewListing.SetPlayerInfo(PlayerInfo.Value, PlayerInfo.Key);
                    _listings.Add(NewListing);
                    NewListing.GetComponent<RawImage>().texture = Resources.Load<Texture2D>("Textures/Sprites/GUI/Icons/Player" + NewListing.ID);
                }
            }
        }
    }

    public void OnClick_ChooseAvatar(int choice)
    {
        int Index = _listings.FindIndex(x => x.Player.NickName == PhotonNetwork.NickName);
        if(Index != -1)
        {
            string SpritePath = "Textures/Sprites/GUI/Icons/";

            switch (choice)
            {
                case 0:
                default:
                    SpritePath += "Avatar_captain";
                    break;
            }

            _listings[Index].GetComponent<RawImage>().texture = Resources.Load<Texture2D>(SpritePath);
        } 
    }
}