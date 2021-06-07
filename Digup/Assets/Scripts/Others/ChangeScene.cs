using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static void GoToScene(string SceneName)
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LoadLevel(SceneName);
        }
        else
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
