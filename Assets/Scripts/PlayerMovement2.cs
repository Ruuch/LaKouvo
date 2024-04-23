using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    //VARIABLES
    [SerializeField] private float moveSpeed;
    [SerializeField] private float runSpeed;

    private Vector3 moveDirection;
    


    //REFERENCES
    private CharacterController controller;



    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection *= runSpeed;

        controller.Move(moveDirection * Time.deltaTime);
        
    }
}