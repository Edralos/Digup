using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource AudioController;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        AudioController = this.GetComponent<AudioSource>();
        AudioController.loop = true;
        AudioController.clip = Resources.Load<AudioClip>("Musics/chill_theme");
        AudioController.Play();
    }

}
