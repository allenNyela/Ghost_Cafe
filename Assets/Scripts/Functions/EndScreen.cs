using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    private float timer;
    [SerializeField]
    private GameObject theScore;
 
    void Start()
    {
        timer = Time.time + 5.0f;

        int b = PlayerPrefs.GetInt("currentScore");
        theScore.GetComponent<TextMeshProUGUI>().text = b.ToString();
    }

    private void Update()
    {
        if (Time.time > timer)
        {
            SceneManager.LoadScene(0);
        }



    }


}
