using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHands : MonoBehaviour
{
    // Variables for hands
    [SerializeField]
    private GameObject leftHand;
    [SerializeField]
    private GameObject rightHand;

    private GameObject inLeftHand;
    private GameObject inRightHand;

    // Check Interactions
    [SerializeField]
    private float checkRadius;
    [SerializeField]
    private Transform trashcanCheck;
    [SerializeField]
    private Transform trashcanCheck2;
    [SerializeField]
    private Transform turkeyCheck;
    [SerializeField]
    private Transform turkeyCheck2;
    [SerializeField]
    private Transform turkeyCheck3;
    [SerializeField]
    private Transform turkeyCheck4;
    [SerializeField]
    private Transform coffeeCheck;
    [SerializeField]
    private Transform pieCheck;
    [SerializeField]
    private Transform pieCheck2;
    [SerializeField]
    private Transform pieCheck3;
    [SerializeField]
    private Transform pieCheck4;
    [SerializeField]
    private Transform pieCheck5;
    [SerializeField]
    private Transform pieCheck6;
    [SerializeField]
    private Transform pieCheck7;
    [SerializeField]
    private LayerMask whatIsPlayer;
    private bool inRangeOfCustomer;
    private GameObject currentCustomer;

    // Objects to hold
    [SerializeField]
    private GameObject turkey;
    [SerializeField]
    private GameObject pie;
    [SerializeField]
    private GameObject coffee;

    [SerializeField]
    private GameObject dirtyPlate;

    // Variables for picking up dirty plates
    private bool inRangeOfPlate;
    private GameObject currentPlate;

    // Information for other scripts
    private string currentlyHolding;
    private string currentlyHoldingInRight;

    // PickUp/Drop Sound Effects
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // On left click
    public void LeftHand()
    {
        if (inLeftHand == null)
        {
            PickUpLeft();
        }
        else
        {
            DropLeft();
        }
    }

    // On right click
    public void RightHand()
    {
        if (inRightHand == null)
        {
            PickUpRight();
        }
        else
        {
            DropRight();
        }
    }


    private void PickUpLeft()
    {
        if (Physics2D.OverlapCircle(turkeyCheck.position, checkRadius, whatIsPlayer) || Physics2D.OverlapCircle(turkeyCheck2.position, checkRadius, whatIsPlayer)
            || Physics2D.OverlapCircle(turkeyCheck3.position, checkRadius, whatIsPlayer) || Physics2D.OverlapCircle(turkeyCheck4.position, checkRadius, whatIsPlayer))
        {
            Debug.Log("pick up turkey");
            inLeftHand = Instantiate(turkey, leftHand.transform.position, Quaternion.identity, leftHand.transform);
            currentlyHolding = "Turkey";
            source.Play();
        }

        else if (Physics2D.OverlapCircle(coffeeCheck.position, checkRadius, whatIsPlayer))
        {
            Debug.Log("pick up coffee");
            inLeftHand = Instantiate(coffee, leftHand.transform.position, Quaternion.identity, leftHand.transform);
            currentlyHolding = "Coffee";
            source.Play();
        }

        else if (Physics2D.OverlapCircle(pieCheck.position, checkRadius, whatIsPlayer) || Physics2D.OverlapCircle(pieCheck2.position, checkRadius, whatIsPlayer) || Physics2D.OverlapCircle(pieCheck3.position, checkRadius, whatIsPlayer) || Physics2D.OverlapCircle(pieCheck4.position, checkRadius, whatIsPlayer) || Physics2D.OverlapCircle(pieCheck5.position, checkRadius, whatIsPlayer) || Physics2D.OverlapCircle(pieCheck6.position, checkRadius, whatIsPlayer) || Physics2D.OverlapCircle(pieCheck7.position, checkRadius, whatIsPlayer))
        {
            Debug.Log("pick up pie");
            inLeftHand = Instantiate(pie, leftHand.transform.position, Quaternion.identity, leftHand.transform);
            currentlyHolding = "Pie";
            source.Play();
        }

        else if (inRangeOfPlate)
        {
            Debug.Log("pick up trash");
            inLeftHand = Instantiate(dirtyPlate, leftHand.transform.position, Quaternion.identity, leftHand.transform);
            Destroy(currentPlate);
            currentlyHolding = "Trash";
            source.Play();
        }
    }

    private void DropLeft()
    {
        if (Physics2D.OverlapCircle(trashcanCheck.position, checkRadius * 2.6f, whatIsPlayer) || Physics2D.OverlapCircle(trashcanCheck2.position, checkRadius * 2.6f, whatIsPlayer))
        {
            Debug.Log("drop left");
            Destroy(inLeftHand);
            currentlyHolding = "Nothing";
            source.Play();
        }

        if (inRangeOfCustomer == true)
        {
            if (currentCustomer.GetComponent<CustomerFood>().customerFoodRequest == currentlyHolding && currentCustomer.GetComponent<CustomerFood>().isWaiting)
            {
                currentCustomer.GetComponent<CustomerFood>().setGotFood(true, currentlyHolding);
                Debug.Log("drop left");
                Destroy(inLeftHand);
                currentlyHolding = "Nothing";
                source.Play();
            }
            
        }
    }



    private void PickUpRight()
    {
        if (Physics2D.OverlapCircle(turkeyCheck.position, checkRadius, whatIsPlayer) || Physics2D.OverlapCircle(turkeyCheck2.position, checkRadius, whatIsPlayer)
            || Physics2D.OverlapCircle(turkeyCheck3.position, checkRadius, whatIsPlayer) || Physics2D.OverlapCircle(turkeyCheck4.position, checkRadius, whatIsPlayer))
        {
            Debug.Log("pick up turkey");
            inRightHand = Instantiate(turkey, rightHand.transform.position, Quaternion.identity, rightHand.transform);
            currentlyHoldingInRight = "Turkey";
            source.Play();
        }

        else if (Physics2D.OverlapCircle(coffeeCheck.position, checkRadius, whatIsPlayer))
        {
            Debug.Log("pick up coffee");
            inRightHand = Instantiate(coffee, rightHand.transform.position, Quaternion.identity, rightHand.transform);
            currentlyHoldingInRight = "Coffee";
            source.Play();
        }

        else if (Physics2D.OverlapCircle(pieCheck.position, checkRadius, whatIsPlayer) || Physics2D.OverlapCircle(pieCheck2.position, checkRadius, whatIsPlayer) || Physics2D.OverlapCircle(pieCheck3.position, checkRadius, whatIsPlayer) || Physics2D.OverlapCircle(pieCheck4.position, checkRadius, whatIsPlayer) || Physics2D.OverlapCircle(pieCheck5.position, checkRadius, whatIsPlayer) || Physics2D.OverlapCircle(pieCheck6.position, checkRadius, whatIsPlayer) || Physics2D.OverlapCircle(pieCheck7.position, checkRadius, whatIsPlayer))
        {
            Debug.Log("pick up pie");
            inRightHand = Instantiate(pie, rightHand.transform.position, Quaternion.identity, rightHand.transform);
            currentlyHoldingInRight = "Pie";
            source.Play();
        }

        else if (inRangeOfPlate)
        {
            Debug.Log("pick up trash");
            inRightHand = Instantiate(dirtyPlate, rightHand.transform.position, Quaternion.identity, rightHand.transform);
            Destroy(currentPlate);
            currentlyHoldingInRight = "Trash";
            source.Play();
        }
    }


    private void DropRight()
    {
        if (Physics2D.OverlapCircle(trashcanCheck.position, checkRadius * 2.6f, whatIsPlayer) || Physics2D.OverlapCircle(trashcanCheck2.position, checkRadius * 2.6f, whatIsPlayer))
        {
            Debug.Log("drop right");
            Destroy(inRightHand);
            currentlyHoldingInRight = "Nothing";
            source.Play();
        }

        if (inRangeOfCustomer == true)
        {
            if (currentCustomer.GetComponent<CustomerFood>().customerFoodRequest == currentlyHoldingInRight &&
                currentCustomer.GetComponent<CustomerFood>().hasFood == false)
            {
                currentCustomer.GetComponent<CustomerFood>().setGotFood(true, currentlyHoldingInRight);
                Debug.Log("drop right");
                Destroy(inRightHand);
                currentlyHoldingInRight = "Nothing";
                source.Play();
            }
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DirtyPlate")
        {
            inRangeOfPlate = true;
            currentPlate = collision.gameObject;
        }

        if (collision.gameObject.tag == "Customer")
        {
            Debug.Log("In range of customer");
            inRangeOfCustomer = true;
            currentCustomer = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DirtyPlate")
        {
            inRangeOfPlate = false;
        }

        if (collision.gameObject.tag == "Customer")
        {
            inRangeOfCustomer = false;
        }
    }
}
