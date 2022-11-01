using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] chairs;

    private GameObject[] customers;

    [SerializeField]
    private GameObject customerSpawnLocation;
    [SerializeField]
    private GameObject customerExit;
    [SerializeField]
    private GameObject customerNice;
    [SerializeField]
    private GameObject customerNeutral;
    [SerializeField]
    private GameObject customerMean;

    // spawn timers
    private float spawnTimer = 0;
    [SerializeField]
    private float spawnAttemptDelay;

    // game timers
    [SerializeField]
    private float gameTimer = 120;


    void Awake()
    {
        customers = new GameObject[chairs.Length];

        PlayerPrefs.SetInt("currentScore", 0);

        if (!PlayerPrefs.HasKey("highScore1"))
        {
            PlayerPrefs.SetInt("highScore1", 0);
            PlayerPrefs.SetInt("highScore2", 0);
            PlayerPrefs.SetInt("highScore3", 0);
            PlayerPrefs.SetInt("highScore4", 0);
            PlayerPrefs.SetInt("highScore5", 0);
        }
            
    }

    void Update()
    {
        if (Time.time > spawnTimer)
        {
            spawnTimer = Time.time + spawnAttemptDelay;
            spawnCustomer();
        }

        if (Time.time > gameTimer)
        {
            gameOver();
        }
    }

    private void spawnCustomer()
    {
        int randomChair = Random.Range(0, chairs.Length);

        Debug.Log("Spawning Attempt Now");

        bool isChairAvailable = false;
        for (int i = 0; i < chairs.Length; i++)
        {
            if (chairs[i].GetComponent<ChairBehavior>().getoccupied() == false
            && chairs[i].GetComponent<ChairBehavior>().getclean() == true)
            {
                isChairAvailable = true;
            }
        }
        if (isChairAvailable == false)
        {
            return;
        }



        if (chairs[randomChair].GetComponent<ChairBehavior>().getoccupied() == false
            && chairs[randomChair].GetComponent<ChairBehavior>().getclean() == true)
        {
            chairs[randomChair].GetComponent<ChairBehavior>().setoccupied(true);
            int randomType = Random.Range(0, 3);
            Debug.Log("Spawn now");
            switch (randomType)
            {
                case 0:
                    customers[randomChair] = Instantiate(customerMean, customerSpawnLocation.transform.position, Quaternion.identity, customerSpawnLocation.transform);
                    break;
                case 1:
                    customers[randomChair] = Instantiate(customerNeutral, customerSpawnLocation.transform.position, Quaternion.identity, customerSpawnLocation.transform);
                    break;
                case 2:
                    customers[randomChair] = Instantiate(customerNice, customerSpawnLocation.transform.position, Quaternion.identity, customerSpawnLocation.transform);
                    break;
            }

            customers[randomChair].GetComponent<CustomerFood>().setChairObject(chairs[randomChair]);
            customers[randomChair].GetComponent<CustomerFood>().findTable();
            customers[randomChair].GetComponent<CustomerMovement>().setExit(customerExit);

            chairs[randomChair].GetComponent<ChairBehavior>().setCustomer(customers[randomChair]);

        }

        else
        {
            spawnCustomer();
        }
    }


    public void gameOver()
    {
        if (PlayerPrefs.GetInt("currentScore") > PlayerPrefs.GetInt("highScore1"))
        {
            PlayerPrefs.SetInt("highScore1", PlayerPrefs.GetInt("currentScore"));
        }

        else if (PlayerPrefs.GetInt("currentScore") > PlayerPrefs.GetInt("highScore2"))
        {
            PlayerPrefs.SetInt("highScore2", PlayerPrefs.GetInt("currentScore"));
        }

        else if (PlayerPrefs.GetInt("currentScore") > PlayerPrefs.GetInt("highScore3"))
        {
            PlayerPrefs.SetInt("highScore3", PlayerPrefs.GetInt("currentScore"));
        }

        else if (PlayerPrefs.GetInt("currentScore") > PlayerPrefs.GetInt("highScore4"))
        {
            PlayerPrefs.SetInt("highScore4", PlayerPrefs.GetInt("currentScore"));
        }

        else if (PlayerPrefs.GetInt("currentScore") > PlayerPrefs.GetInt("highScore5"))
        {
            PlayerPrefs.SetInt("highScore5", PlayerPrefs.GetInt("currentScore"));
        }

        // open the end scene
    }
}
