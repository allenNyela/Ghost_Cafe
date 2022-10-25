using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairBehavior : MonoBehaviour

{
    [SerializeField]
    private GameObject dirtyPlate;
    private GameObject currentDirtyPlate;
    private bool occupied;
    private bool clean;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Customer")
        {
            onCustomerEnter();
            occupied = true;
            
        }
        if (collision.gameObject.tag == "Player")
        {
            if (occupied == false)
            {

            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Customer")
        {
            onCustomerExit();
            


        }

    }
    
    private void onCustomerExit()
    {
        clean = false;
        currentDirtyPlate = Instantiate(dirtyPlate, new Vector2(transform.position.x, transform.position.y), Quaternion.identity, transform);
    }

    private void onCustomerEnter()
    {
        throw new NotImplementedException();
    }
}
