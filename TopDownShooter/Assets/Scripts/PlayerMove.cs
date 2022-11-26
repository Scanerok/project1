using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public float rotationSpeed;

    private Animator anim;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        originalStepOffset = characterController.stepOffset;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            inputMagnitude *= 2;
        }
        anim.SetFloat("Input Magnitude", inputMagnitude, 0.05f, Time.deltaTime);

        
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        

        if (movementDirection != Vector3.zero)
        {

            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
                
    }

    private void OnAnimatorMove()
    {
        Vector3 velocity = anim.deltaPosition;
        velocity.y = ySpeed* Time.deltaTime;

        characterController.Move(velocity);
    }
}
