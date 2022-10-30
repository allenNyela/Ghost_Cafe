using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairBehavior : MonoBehaviour

{
    [SerializeField]
    private GameObject dirtyPlate;
    [SerializeField]
    private GameObject turkey;
    [SerializeField]
    private GameObject pie;
    [SerializeField]
    private GameObject coffee;
    [SerializeField]
    private GameObject tablePlaceholder;

    private GameObject customer;
    private GameObject currentPlate; 
    private bool occupied;
    private bool clean;

    public bool getclean() {
        return clean;
    }
    public void setclean(bool value) {
        this.clean = value;
    }
    public bool getoccupied() {
        return occupied;
    }
    public void setoccupied(bool value) {
        this.occupied = value;
    }
    public Customer getCustomer() {
        return customer;
    }
    public void setCustomer(Customer value) {
        this.customer = value;
    }
    public string getDirtyPlate()
    {
        return dirtyPlate;
    }
    public void setDirtyPlate(string value)
    {
        this.dirtyPlate = value;
    }


   

    // Start is called before the first frame update
    void Start()
    {
    setclean(true);
    setoccupied(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlate == null && occupied==false)
        {
        setClean(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Customer"))
        {
            onCustomerEnter();           
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
        setclean(false);
        setoccupied(false);
        setCustomer(null);
        Destroy(currentPlate);
        currentPlate = Instantiate(DirtyPlate, new Vector2(transform.position.x, transform.position.y), Quaternion.identity, transform);
    }

    private void onCustomerEnter()
    {
    setoccupied(true);

    }
   
    public void StringtoGameObject(string value)
    {
        if (value == "turkey")
        {
            currentPlate = Instantiate(turkey, tablePlaceholder.transform.position, Quaternion.identity, tablePlaceholder.transform);
        }
        if(value == "coffee")
        {
            currentPlate = Instantiate(coffee, tablePlaceholder.transform.position, Quaternion.identity, tablePlaceholder.transform);
        }
        if(value== "pie")
        {
            currentPlate = Instantiate(pie, tablePlaceholder.transform.position, Quaternion.identity, tablePlaceholder.transform);
        }

    }
   
    
}
