using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /* Walk Variables */
    [SerializeField] // this means that we can edit this value in the unity editor
    private float walkSpeed;

    /* Unity Varialbes */
    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
    }

    public void Walk(Vector2 direction)
    {
        body.velocity = new Vector2(direction.x * walkSpeed, direction.y * walkSpeed);
    }
}
