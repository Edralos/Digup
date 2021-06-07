using UnityEngine;

/// <summary>
/// Launch map generation at the launch of the game
/// </summary>
public class StartSinglePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public void HandleClick()
    {
        //Stop previous music
        AudioSource MusicPlayer = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
        MusicPlayer.Stop();
        //MusicPlayer.clip = Resources.Load<AudioClip>("Musics/default_theme");


        //Load map and keep map
        Stage.InitStage("Gallery", 5);

        //Play new music
        //todo: faire la musique

        //Change scene
        ChangeScene.GoToScene("StartRoomScene");
    }
}
