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

    public override void OnJoinedRoom()
    {
        _content.DestroyChildren();
        _listings.Clear();
    }

    public override void OnRoomListUpdate(List<RoomInfo> RoomList)
    {
        Debug.Log("OnRoomListUpdate");

        foreach(RoomInfo Info in RoomList)
        {
            if(Info.RemovedFromList)
            {
                RoomListing ListingToDelete = _listings.Find(x => x.RoomInfo.Name == Info.Name);
                if(ListingToDelete != null)
                {
                    Destroy(ListingToDelete.gameObject);
                    _listings.Remove(ListingToDelete);
                }  
            }
            else
            {
                int Index = _listings.FindIndex(x => x.RoomInfo.Name == Info.Name);
                if(Index == -1)
                {
                    RoomListing NewListing = Instantiate(_roomListing, _content);
                    if (NewListing != null)
                    {
                        NewListing.SetRoomInfo(Info);
                        _listings.Add(NewListing);
                    }
                }
                else
                {

                }
            }
        }
    }
}
