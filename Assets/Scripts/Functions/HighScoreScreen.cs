using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreScreen : MonoBehaviour
{
    public GameObject topScore1;
    public GameObject topScore2;
    public GameObject topScore3;
    public GameObject topScore4;
    void Start()
    {
        topScore1.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("highScore1").ToString();
        topScore2.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("highScore2").ToString();
        topScore3.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("highScore3").ToString();
        topScore4.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("highScore4").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
