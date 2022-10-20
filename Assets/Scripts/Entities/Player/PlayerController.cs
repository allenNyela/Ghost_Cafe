using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    /* Other Scripts */
    private PlayerMovement playerMovement;
    private PlayerAnimator playerAnimator;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void ProcessInputs()
    {
        /* Directional Input */
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;

        /* Walking */
        playerMovement.Walk(moveDirection);

        /* Play the necessary animation */
        if (moveX == 0 && moveY == 0)
        {
            playerAnimator.IdleAnimation();
        }
        else
        {
            playerAnimator.WalkAnimation();
        }
    }
}
