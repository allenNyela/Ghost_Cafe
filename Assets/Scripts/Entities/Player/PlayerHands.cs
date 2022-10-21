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
    private LayerMask whatIsPlayer;

    // Objects to hold
    [SerializeField]
    private GameObject turkey;

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
    }

    private void DropLeft()
    {
        if (Physics2D.OverlapCircle(trashcanCheck.position, checkRadius * 2.6f, whatIsPlayer))
        {
            Debug.Log("drop turkey");
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
    }


    private void DropRight()
    {
        if (Physics2D.OverlapCircle(trashcanCheck.position, checkRadius * 2.6f, whatIsPlayer))
        {
            Debug.Log("drop turkey");
            Destroy(inRightHand);
        }
    }
}
