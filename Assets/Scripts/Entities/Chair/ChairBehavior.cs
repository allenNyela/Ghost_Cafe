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
    private bool occupied = false;
    private bool clean = true;

    public bool getclean()
    {
        return clean;
    }
    public void setclean(bool value)
    {
        this.clean = value;
    }
    public bool getoccupied()
    {
        return occupied;
    }
    public void setoccupied(bool value)
    {
        this.occupied = value;
    }
    public GameObject getCustomer()
    {
        return customer;
    }
    public void setCustomer(GameObject value)
    {
        this.customer = value;
    }




    // Start is called before the first frame update
    void Start()
    {
        setclean(true);
        setoccupied(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlate == null && occupied == false)
        {
            setclean(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == customer)
        {
            onCustomerEnter(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == customer)
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
        currentPlate = Instantiate(dirtyPlate, new Vector2(tablePlaceholder.transform.position.x, tablePlaceholder.transform.position.y + 0.5f), Quaternion.identity, tablePlaceholder.transform);
    }

    private void onCustomerEnter(GameObject customer)
    {
        setoccupied(true);
        setCustomer(customer);
        customer.GetComponent<CustomerFood>().askForFood();

    }

    public void StringtoGameObject(string value)
    {
        if (value == "Turkey")
        {
            currentPlate = Instantiate(turkey, tablePlaceholder.transform.position, Quaternion.identity, tablePlaceholder.transform);
        }
        if (value == "Coffee")
        {
            currentPlate = Instantiate(coffee, tablePlaceholder.transform.position, Quaternion.identity, tablePlaceholder.transform);
        }
        if (value == "Pie")
        {
            currentPlate = Instantiate(pie, tablePlaceholder.transform.position, Quaternion.identity, tablePlaceholder.transform);
        }

    }


}