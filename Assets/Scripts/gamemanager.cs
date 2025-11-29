using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    bool play = false;

    public Button playButton;
    public Button stopButton;
    // Start is called before the first frame update
    void Start()
    {

        stopButton.onClick.AddListener(Stop);
        playButton.onClick.AddListener(Play);

        stopButton.image.color = Color.gray;
        playButton.image.color = Color.white;
        
        play = false;
    }

    private void Awake()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Play()
    {
        if (play == false)
        {
            play = true;
            Time.timeScale = 1f;
            playButton.image.color = Color.gray;
            stopButton.image.color = Color.white;
        }
    }
    public void Stop()
    {
        if (play == true)
        {
            play = false;
            Time.timeScale = 0;
            playButton.image.color = Color.white;
            stopButton.image.color = Color.gray;
        }
    }
}
