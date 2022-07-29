using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int moveSpeed;
    [SerializeField] Rigidbody2D playerRigidBody;
    [SerializeField] Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        playerRigidBody.velocity = new Vector2(horizontalMovement, verticalMovement) * moveSpeed;

        if (Input.GetKey("left shift"))
        {
            moveSpeed = 12;
            playerAnimator.SetFloat("runX", playerRigidBody.velocity.x);
            playerAnimator.SetFloat("runY", playerRigidBody.velocity.y);
        }
        else
        {
            moveSpeed = 5;
            playerAnimator.SetFloat("runX", 0);
            playerAnimator.SetFloat("runY", 0);
        }

        playerAnimator.SetFloat("movementX", playerRigidBody.velocity.x);
        playerAnimator.SetFloat("movementY", playerRigidBody.velocity.y);

        if (horizontalMovement == 1 || horizontalMovement == -1 || verticalMovement == 1 || verticalMovement == -1)
        {
            playerAnimator.SetFloat("lastX", horizontalMovement);
            playerAnimator.SetFloat("lastY", verticalMovement);
        }
    }
}
