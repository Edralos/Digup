using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingsDisplay : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private RoomListing _roomListing;

    private List<RoomListing> _listings = new List<RoomListing>();

    public override void OnRoomListUpdate(List<RoomInfo> RoomList)
    {
        foreach(RoomInfo Info in RoomList)
        {
            if(Info.RemovedFromList)
            {
                int Index = _listings.FindIndex(x => x.RoomInfo.Name == Info.Name);
                if(Index != -1)
                {
                    Destroy(_listings[Index].gameObject);
                    _listings.RemoveAt(Index);
                }  
            }
            else
            {
                RoomListing Listing = Instantiate(_roomListing, _content);
                if (Listing != null)
                {
                    Listing.SetRoomInfo(Info);
                    _listings.Add(Listing);
                }
            }
        }
    }
}
