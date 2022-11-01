using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{

    private Vector2 direction;

    [SerializeField]
    private GameObject exit;
    private Collider2D exitCollision;

    [SerializeField]
    private GameObject chair;
    private Collider2D chairCollision;
    [SerializeField]
    private float speed;

    private bool isWalkingIn = false;
    private bool isWalkingOut = false;

    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void setExit(GameObject exit)
    {
        this.exit = exit;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWalkingIn && !isWalkingOut)
        {
            body.velocity = new Vector2(0, 0);
        }

        if (isWalkingIn)
        {
            chairCollision = chair.GetComponent<Collider2D>();
            direction = chair.transform.position - transform.position;
            direction.Normalize();
            body.velocity = direction * speed;

            if (body.velocity.x >= 0) 
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            if (body.velocity.x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

        }

        if (isWalkingOut)
        {
            exitCollision = exit.GetComponent<Collider2D>();
            direction = exit.transform.position - transform.position;
            direction.Normalize();
            body.velocity = direction * speed;

            if (body.velocity.x >= 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            if (body.velocity.x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == chairCollision && isWalkingIn)
        {
            isWalkingIn = false;
        }

        if (collision == exitCollision && isWalkingOut)
        {
            Destroy(this.gameObject);
        }
    }

    public void WalkIn(GameObject chair)
    {
        isWalkingIn = true;
        this.chair = chair;
    }

    public void WalkOut()
    {
        isWalkingOut = true;
    }
}
