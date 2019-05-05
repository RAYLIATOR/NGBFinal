﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;

    private CharacterController charController;

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;

    bool grounded;

    public static bool isGrounded;

    private bool isJumping;

    public static bool freezeMove;

    private void Awake()
    {
        isGrounded = true;
        //freezeMove = true;
        charController = GetComponent<CharacterController>();
        grounded = true;
    }

    private void Update()
    {
        if(charController.isGrounded)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        //print(isGrounded);
        PlayerMovement();
    }
    
    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        //if (!charController.isGrounded && Mathf.Abs(horizInput) > 0.01f) return;
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        if (!freezeMove)
        {
            charController.Move((forwardMovement + rightMovement + (Vector3.down * 10)) * Time.deltaTime);
        }

        JumpInput();

    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(jumpKey) && !isJumping && grounded && !freezeMove)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }

}