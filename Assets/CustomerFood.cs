using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerFood : MonoBehaviour
{

    String food[3] = {"Pie", "Coffee", "Turkey"};
    String customerFoodRequest = "";
    boolean isDone = false; //lets chair and game manager know customer is done and can leave the restaurant
    boolean isWaiting = false; // if waiting for a certain amount of time, score is decremented
    float customerScore = 0; // change depending on the food item it requests
    private float timer = 0.0;
    float foodDeduct = 0;
    private float waitTime = 5.0;
    private float eatingTimer = 0;
    boolean hasFood = false;
    boolean foundChair = false;

    [SerializeField]
    private GameObject chair = null;
    [SerializeField]
    public int customerType = 0;

    // Update is called once per frame
    void Update()
    {

        if (chair != null && !foundChair) {
            findTable();
        }

        if (customerType == 0) {
            if (customerType == 1) {
                foodDeduct = 1.5;
            } else if (customerType == 2) {
                foodDeduct = 1;
            } else {
                foodDeduct = .5;
            }
        }

        if (isWaiting) {

            timer += Time.deltaTime;

            if (timer % waitTime == 0) {
                decrementScore(foodDeduct);
            }

        }

        if (hasFood) {
            eatFood();
        }
    }

    void eatFood() 
    {
        isWaiting = false;
        //wait 10 seconds for customer to eat
        System.Threading.Thread.Sleep(10000);
        isDone = true;
        hasFood = false;
        leaveRestaurant();

    }

    void askForFood()
    {
        //generate random food enum
        Random r = new Random();
        String[] fA = food;
        customerFoodRequest = fA[(r.Next(fA.length))];

        if (customerFoodRequest == "Pie") {
            customerScore = 18;
        } else if (customerFoodRequest == "Coffee") {
            customerScore = 10;
        } else {
            customerScore = 23;
        }

        isWaiting = true;
    }

    void leaveRestaurant() 
    {
        GameObject.GetComponent<CustomerMovement>().WalkOut();

    }

    void findTable()
    {
        GameObject.GetComponent<CustomerMovement>().WalkIn(chair);
        foundChair == true;
    }

    //decrements the local customer score
    void decrementScore(float deduct)
    {
        this.customerScore -= deduct;
    }

    public boolean getCustomerEatingStatus()
    {
        return isDone;
    }

    public String getFood()
    {
        return customerFoodRequest;
    }

    public float getCustomerScore() 
    {
        return customerScore;
    }

    public void setGotFood(Boolean hasFood) {
        this.hasFood = hasFood;
    }

    public void setChairObject(GameObject chair) {
        this.chair = chair;
    }
}
