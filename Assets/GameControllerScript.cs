using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{

    public GameObject scoreLabel;
    public GameObject menuBackgroundImage;
    public GameObject startButton;

    private float score = 0;
    private bool _isStarted = false;

    private void Start()
    {
        startButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate {
            menuBackgroundImage.SetActive(false);
            _isStarted = true;
        });
    }

    public bool isStarted()
    {
        return _isStarted;
    }

    public void increaseScore(int increment)
    {
        score += increment;
        scoreLabel.GetComponent<UnityEngine.UI.Text>().text = "Score: " + score;
    }
}
