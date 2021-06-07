using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

public class NetworkTester : MonoBehaviourPunCallbacks
{
    private Text Log;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        // Make the user able to connect to the Network. The User can join only others who use the same game version.
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;

        Log = GameObject.Find("Log").GetComponent<Text>();
        Log.text = "";

        DontDestroyOnLoad(GameObject.Find("LogCanvas"));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PhotonNetwork.NetworkClientState.ToString());

        if (SceneManager.GetActiveScene().name == "CoopMenuScreen")
        {
            if(!PhotonNetwork.IsConnected)
            {
                PhotonNetwork.ConnectUsingSettings();
            }
            else
            {
                if (!PhotonNetwork.InLobby)
                {
                    PhotonNetwork.JoinLobby();
                }
            }      
        }
    }   
    // Invoked when the user is connected to the cloud
    public override void OnConnectedToMaster()
    {
        Log.text = "You are connected, "+ PhotonNetwork.NickName+".";
        Log.color = Color.green;
    }

    public override void OnJoinedLobby()
    {
        Log.text = "Now, you can join a team.";
        Log.color = Color.white;
    }

    // Invoked when the user joined a room
    public override void OnJoinedRoom()
    {
        Log.text = "You joined \"" + PhotonNetwork.CurrentRoom.Name + "\".";
        Log.color = Color.green;

        if (SceneManager.GetActiveScene().name == "CoopMenuScreen")
        {
            ChangeScene.GoToScene("WaitingRoom");
        }
    }

    public void OnApplicationQuit()
    {
        if(PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
        if(PhotonNetwork.InLobby)
        {
            PhotonNetwork.LeaveLobby();
        }
    }
}
