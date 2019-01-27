﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    CharacterController controller;
    public Vector3 directionMove;

    public float gravScale;
    SpriteRenderer rend;

    public Animator animator;
    Vector3 foward, right;

    //public bool movable;

    public bool faceRight;
    // Use this for initialization
    void Start()
    {

        foward = Camera.main.transform.forward;
        foward.y = 0;
        foward = Vector3.Normalize(foward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * foward;
        controller = GetComponent<CharacterController>();
        //  rend = GetComponent<SpriteRenderer>();
        //   DontDestroyOnLoad(this);



    }



    // Update is called once per frame
    void Update()
    {
        /*
        if (movable == false)
        {
            return;
        }
        */

        Vector3 rightMovement = right * speed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = foward * speed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        //transform.forward = heading;
        directionMove = new Vector3(0, directionMove.y, 0);
        directionMove += upMovement;
        directionMove += rightMovement;


        //Instead of keeping player, make a gameobject decide players position
        if (Input.GetAxis("Horizontal") < 0 && faceRight)
        {
            //  rend.flipX = true;
            //  faceRight = false;
        }
        if (Input.GetAxis("Horizontal") > 0 && !faceRight)
        {
            //  rend.flipX = false;
            //   faceRight =true;
        }



        if (controller.isGrounded)
        {

            if (Input.GetButtonDown("Jump"))
            {
                directionMove.y = jumpForce;

            }
        }
        if (!controller.isGrounded)
        {
            directionMove.y = directionMove.y + (Physics.gravity.y * gravScale * Time.deltaTime);

        }

        controller.Move(directionMove * Time.deltaTime);




        //animation checks
        //    animator.SetFloat("Speed", Mathf.Abs(directionMove.x) + Mathf.Abs(directionMove.z));
        //   animator.SetBool("Grounded", controller.isGrounded);
        //  animator.SetFloat("Fall", directionMove.y);



    }
}
