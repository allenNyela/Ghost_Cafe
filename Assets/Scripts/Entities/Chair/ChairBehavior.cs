using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairBehavior : MonoBehaviour

{
    [SerializeField]
    private GameObject dirtyPlate;
    private GameObject currentPlate;

    private bool occupied;
    public bool clean;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlate == null && occupied==false)
        {
            clean = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Customer"))
        {
            onCustomerEnter();
            
            
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (occupied == false)
            {
                if (currentPlate=dirtyPlate)
                {
                    //current plate is selectable only if dirty, food plates should not be picked up if being used by customer thats rude. 
                }
            }
            else
            {
               // if plate the player tries to give matches the customer order that plate becomes the current plate until the customer leaves.
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Customer"))
        {
            onCustomerExit();
            


        }

    }
    
    private void onCustomerExit()
    {
        clean = false;
        currentPlate = Instantiate(dirtyPlate, new Vector2(transform.position.x, transform.position.y), Quaternion.identity, transform);
    }

    private void onCustomerEnter()
    {
        occupied = true;


    }
}
