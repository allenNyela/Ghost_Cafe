using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerFood : MonoBehaviour
{

    string[] food = { "Pie", "Coffee", "Turkey" };
    public string customerFoodRequest = "";
    bool isDone = false; //lets chair and game manager know customer is done and can leave the restaurant
    bool isWaiting = false; // if waiting for a certain amount of time, score is decremented
    float customerScore = 0; // change depending on the food item it requests
    private float timer = 0.0f;
    float foodDeduct = 0;
    private float waitTime = 5.0f;
    public bool hasFood = false;
    bool foundChair = false;

    [SerializeField]
    private GameObject chair = null;
    [SerializeField]
    public int customerType = 0;

    private GameObject foodSpeechBubble;
    [SerializeField]
    private GameObject wantCoffee;
    [SerializeField]
    private GameObject wantPie;
    [SerializeField]
    private GameObject wantTurkey;

    // Update is called once per frame
    void Update()
    {

        if (chair != null && !foundChair)
        {
            findTable();
        }

        if (customerType == 1)
        {
            foodDeduct = 2f;
        }
        else if (customerType == 2)
        {
            foodDeduct = 1.5f;
        }
        else
        {
            foodDeduct = 1f;
        }
        

        if (isWaiting)
        {

            timer += Time.deltaTime;

            if (timer > waitTime)
            {
                decrementScore(foodDeduct);
                timer = 0;
            }

        }

        if (hasFood)
        {
            eatFood();
        }
    }

    void eatFood()
    {
        isWaiting = false;
        //wait 10 seconds for customer to eat
        Invoke("doneEatingFood", 10.0f);
    }

    void doneEatingFood()
    {
        if (!isDone)
        {
            PlayerPrefs.SetInt("currentScore", PlayerPrefs.GetInt("currentScore") + (int)Math.Round(customerScore));
            if (PlayerPrefs.GetInt("currentScore") < 0)
            {
                PlayerPrefs.SetInt("currentScore", 0);
            }
            Debug.Log("Score = " + PlayerPrefs.GetInt("currentScore"));
        }
        
        isDone = true;
        leaveRestaurant();

        
    }

    public void askForFood()
    {
        //generate random food enum
        int RandomNum = UnityEngine.Random.Range(0, 3);
        if (RandomNum == 0)
        {
            customerFoodRequest = "Pie";
            foodSpeechBubble = Instantiate(wantPie, new Vector2(transform.position.x + 1.2f, transform.position.y + 1.1f), Quaternion.identity, transform);
        }
        else if (RandomNum == 1)
        {
            customerFoodRequest = "Coffee";
            foodSpeechBubble = Instantiate(wantCoffee, new Vector2(transform.position.x + 1.2f, transform.position.y + 1.1f), Quaternion.identity, transform);
        }
        else if (RandomNum == 2)
        {
            customerFoodRequest = "Turkey";
            foodSpeechBubble = Instantiate(wantTurkey, new Vector2(transform.position.x + 1.2f, transform.position.y + 1.1f), Quaternion.identity, transform);
        }

        Debug.Log("I want " + customerFoodRequest);

        if (customerFoodRequest == "Pie")
        {
            customerScore = 10;
        }
        else if (customerFoodRequest == "Coffee")
        {
            customerScore = 8;
        }
        else
        {
            customerScore = 12;
        }

        isWaiting = true;
    }

    void leaveRestaurant()
    {
        GetComponent<CustomerMovement>().WalkOut();

    }

    public void findTable()
    {
        GetComponent<CustomerMovement>().WalkIn(chair);
        foundChair = true;
    }

    //decrements the local customer score
    void decrementScore(float deduct)
    {
        this.customerScore -= deduct;
    }

    public bool getCustomerEatingStatus()
    {
        return isDone;
    }

    public string getFood()
    {
        return customerFoodRequest;
    }

    public float getCustomerScore()
    {
        return customerScore;
    }

    public void setGotFood(bool hasFood, string playerIsHolding)
    {
        if (playerIsHolding == customerFoodRequest)
        {
            this.hasFood = hasFood;
            chair.GetComponent<ChairBehavior>().StringtoGameObject(customerFoodRequest);
            Destroy(foodSpeechBubble);
            isWaiting = false;

            
        }
        else
        {
            Debug.Log("Wrong Food");
        }
    }

    public void setChairObject(GameObject chair)
    {
        this.chair = chair;
    }
}