using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class NetworkTester : MonoBehaviourPunCallbacks
{
    private Text Log;

    // Start is called before the first frame update
    void Start()
    {
        // Make the user able to connect to the Network. The User can join only others who use the same game version.
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;

        Log = GameObject.Find("Log").GetComponent<Text>();
        Log.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PhotonNetwork.NetworkClientState.ToString());
    }   
    // Invoked when the user is connected to the cloud
    public override void OnConnectedToMaster()
    {
        Log.text = "You are connected, "+ PhotonNetwork.NickName+".";
        Log.color = Color.green;

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Log.text = "Now, you can join a game.";
        Log.color = Color.white;
    }
}
