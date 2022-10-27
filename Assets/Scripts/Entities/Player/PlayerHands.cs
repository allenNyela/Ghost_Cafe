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
    private Transform turkeyCheck;
    [SerializeField]
    private Transform coffeeCheck;
    [SerializeField]
    private Transform pieCheck;
    [SerializeField]
    private LayerMask whatIsPlayer;

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

    void Start()
    {
        
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
        if (Physics2D.OverlapCircle(turkeyCheck.position, checkRadius, whatIsPlayer))
        {
            Debug.Log("pick up turkey");
            inLeftHand = Instantiate(turkey, leftHand.transform.position, Quaternion.identity, leftHand.transform);
        }

        else if (Physics2D.OverlapCircle(coffeeCheck.position, checkRadius, whatIsPlayer))
        {
            Debug.Log("pick up coffee");
            inLeftHand = Instantiate(coffee, leftHand.transform.position, Quaternion.identity, leftHand.transform);
        }

        else if (Physics2D.OverlapCircle(pieCheck.position, checkRadius, whatIsPlayer))
        {
            Debug.Log("pick up pie");
            inLeftHand = Instantiate(pie, leftHand.transform.position, Quaternion.identity, leftHand.transform);
        }

        else if (inRangeOfPlate)
        {
            Debug.Log("pick up trash");
            inLeftHand = Instantiate(dirtyPlate, leftHand.transform.position, Quaternion.identity, leftHand.transform);
            Destroy(currentPlate);
        }
    }

    private void DropLeft()
    {
        if (Physics2D.OverlapCircle(trashcanCheck.position, checkRadius * 2.6f, whatIsPlayer))
        {
            Debug.Log("drop left");
            Destroy(inLeftHand);
        }
    }



    private void PickUpRight()
    {
        if (Physics2D.OverlapCircle(turkeyCheck.position, checkRadius, whatIsPlayer))
        {
            Debug.Log("pick up turkey");
            inRightHand = Instantiate(turkey, rightHand.transform.position, Quaternion.identity, rightHand.transform);
        }

        else if (Physics2D.OverlapCircle(coffeeCheck.position, checkRadius, whatIsPlayer))
        {
            Debug.Log("pick up coffee");
            inRightHand = Instantiate(coffee, rightHand.transform.position, Quaternion.identity, rightHand.transform);
        }

        else if (Physics2D.OverlapCircle(pieCheck.position, checkRadius, whatIsPlayer))
        {
            Debug.Log("pick up pie");
            inRightHand = Instantiate(pie, rightHand.transform.position, Quaternion.identity, rightHand.transform);
        }

        else if (inRangeOfPlate)
        {
            Debug.Log("pick up trash");
            inRightHand = Instantiate(dirtyPlate, rightHand.transform.position, Quaternion.identity, rightHand.transform);
            Destroy(currentPlate);
        }
    }


    private void DropRight()
    {
        if (Physics2D.OverlapCircle(trashcanCheck.position, checkRadius * 2.6f, whatIsPlayer))
        {
            Debug.Log("drop right");
            Destroy(inRightHand);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DirtyPlate")
        {
            inRangeOfPlate = true;
            currentPlate = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DirtyPlate")
        {
            inRangeOfPlate = false;
        }
    }
}
