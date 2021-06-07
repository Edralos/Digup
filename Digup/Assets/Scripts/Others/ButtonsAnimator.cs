using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsAnimator : MonoBehaviour
{ 
    Animator AnimationController;
    void Start()
    {
        AnimationController = GetComponent<Animator>();
    }

    void OnMouseOver()
    {
        AnimationController.SetBool("IsHighlighted", true);
    }

    void OnMouseExit()
    {
        AnimationController.SetBool("IsHighlighted", false);
    }

    private void OnMouseDown()
    {
        if( this.name.Contains("Back"))
        {
            switch(SceneManager.GetActiveScene().name)
            {
                case "SoloMenuScreen":
                case "CoopMenuScreen" :
                case "WaitingRoom" :
                    if(PhotonNetwork.InRoom)
                    {
                        PhotonNetwork.LeaveRoom(false);
                        Debug.Log("Leaving room...");
                    }
                    if (PhotonNetwork.InLobby)
                    { 
                        PhotonNetwork.LeaveLobby();
                        PhotonNetwork.Disconnect();
                    }
                    ChangeScene.GoToScene("HomeScreen");
                    DestroyImmediate(GameObject.Find("GameManager"));
                    break;
            }   
        }
    }
}
