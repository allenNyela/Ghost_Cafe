using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerFood : MonoBehaviour
{

    enum food
    {
        Pie=18,
        Coffee=10,
        Turkey=23
    }

    food customerFoodRequest = null;
    boolean isDone = false; //lets chair and game manager know customer is done and can leave the restaurant
    boolean waiting = false; // if waiting for a certain amount of time, score is decremented
    float customerScore = 0; // change depending on the food item it requests

    [SerializedField]
    private GameObject table;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void eatFood() 
    {

        //wait 10 seconds for customer to eat
        System.Threading.Thread.Sleep(10000);
        //switch isDone to true
        isDone = true;

    }

    void askForFood()
    {
        //generate random food enum
        Random r = new Random();
        food[] fA = Enum.GetValues(typeof (food));
        customerFoodRequest = fA.GetValue(r.Next(fA.length));

        waiting = true;
        customerScore = (float)customerFoodRequest;
    }

    void leaveRestaurant() 
    {

    }

    void findTable()
    {

    }

    //decrements the local customer score
    void decrementScore(float deduct)
    {
        this.customerScore -= deduct;
    }

    boolean getCustomerEatingStatus()
    {
        return isDone;
    }

    food getFood()
    {
        return customerFoodRequest;
    }

Time.time + Time.deltaTIme;

}
