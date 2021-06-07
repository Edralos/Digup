using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class RoomMaker: MonoBehaviourPunCallbacks
{
    private string RoomDifficulty, RoomName, RoomPassword, JoinedRoomName;
    private Text Log;
    private Dropdown DifficultyDropdown;
    private RoomInfo SelectedRoom;


    [SerializeField]
    private Text _roomName;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("RoomCreationCanvas").GetComponent<Transform>().localScale = Vector3.zero;
        GameObject.Find("EnterRoomCanvas").GetComponent<Transform>().localScale = Vector3.zero;
        DifficultyDropdown = GameObject.Find("DifficultyDropdown").GetComponent<Dropdown>();
        Log = GameObject.Find("Log").GetComponent<Text>();
        Log.text = "";

        GameObject.Find("PasswordField").GetComponent<InputField>().inputType = InputField.InputType.Password;
        GameObject.Find("PwdField").GetComponent<InputField>().inputType = InputField.InputType.Password;
    }

    public void SetSelectedRoom(RoomInfo Info)
    {
        SelectedRoom = Info;
    }

    public void OnClick_SetDifficulty()
    {
        int difficulty = DifficultyDropdown.value;

        switch (difficulty)
        {
            case 0:
                RoomDifficulty = "Easy"; break;
            case 1:
                RoomDifficulty = "Medium"; break;
            case 2:
                RoomDifficulty = "Hard"; break;
        }

        Log.text = "You chose : " + RoomDifficulty.ToLower() + " expedition.";
        Log.color = Color.white;
    }

    public void OnClick_CreateNewRoom()
    {
        RoomName = _roomName.text;

        Hashtable RoomProperties = new ExitGames.Client.Photon.Hashtable();

        if (!PhotonNetwork.IsConnected)
            return;

        if (RoomDifficulty == "")
        {
            RoomDifficulty = "Easy";
        }

        RoomProperties.Add("Difficulty", RoomDifficulty);

        if (RoomName == "")
        {
            Log.text = "Your team's name is missing !";
            Log.color = Color.red;
        }
        else
        {
            RoomPassword = GameObject.Find("PasswordField").GetComponent<InputField>().text;
            RoomProperties.Add("Password", RoomPassword);

            bool IsProtected = false;

            if(RoomPassword != string.Empty)
            {
                IsProtected = true;
            }

            RoomProperties.Add("IsProtected", IsProtected);

            RoomOptions NewGameOptions = new RoomOptions();
            NewGameOptions.MaxPlayers = 6;
            NewGameOptions.CleanupCacheOnLeave = true;
            NewGameOptions.CustomRoomProperties = RoomProperties;
            NewGameOptions.CustomRoomPropertiesForLobby = new string[3] { "Difficulty", "Password", "IsProtected" };

            if (PhotonNetwork.CreateRoom(RoomName, NewGameOptions))
            {
                Log.text = "Success : You created \"" + RoomName + "\" !";
                Log.color = Color.green;
                JoinedRoomName = RoomName;
                GameObject.Find("RoomCreationCanvas").GetComponent<Transform>().localScale = Vector3.zero;
            }
            else
            {
                Log.text = "Error : \"" + RoomName + "\" creation failed !";
                Log.color = Color.red;
                GameObject.Find("RoomCreationCanvas").GetComponent<Transform>().localScale = Vector3.zero;
            }
        }  
    }

    public void OnClick_CallRoomMakerBox()
    {
        if (GameObject.Find("EnterRoomCanvas").GetComponent<Transform>().localScale != Vector3.zero)
        {
            GameObject.Find("EnterRoomCanvas").GetComponent<Transform>().localScale = Vector3.zero;
        }

        GameObject.Find("RoomCreationCanvas").GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
    }

    public void OnClick_CheckRoomPassword()
    {
        string RoomName = SelectedRoom.Name;

        if (SelectedRoom.CustomProperties["Password"].ToString() != GameObject.Find("PwdField").GetComponent<InputField>().text)
        {
            Log.text = "Error : the password of \"" + RoomName + "\" is wrong !";
            Log.color = Color.red;
        }
        else
        {
            JoinRoom(RoomName);
        }
    }

    public void JoinRoom(string RoomName)
    {
        if (PhotonNetwork.JoinRoom(RoomName))
        {
            Log.text = "Waiting...";
            Log.color = Color.white;
            GameObject.Find("EnterRoomCanvas").GetComponent<Transform>().localScale = Vector3.zero;
        }
        else
        {
            Log.text = "Error : \"" + RoomName + "\" joining failed !";
            Log.color = Color.red;
            GameObject.Find("EnterRoomCanvas").GetComponent<Transform>().localScale = Vector3.zero;
        }
    }
}
