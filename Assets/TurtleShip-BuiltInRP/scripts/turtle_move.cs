using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtle_move : MonoBehaviour
{
    private Rigidbody rigid;
    public float hAxis;
    public float vAxis;
    private float speed = 5.0f;
    private float jumpForce = 5.0f;
    private float gravity = 15f;
    public float turnSpeed = 4.0f; // 마우스 회전 속도
    float mouseX = 0;
    Vector3 moveVec;
    Animator anim;
    CharacterController controller;
    private bool IsJumping = false;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        rigid = GetComponent<Rigidbody>();
        IsJumping = false;
    }

    void Update()
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        moveVec = new Vector3(hAxis, 0, vAxis);
        moveVec = moveVec.normalized;


        float planarSpeed = new Vector2(hAxis, vAxis).sqrMagnitude;
        //anim.SetFloat("PlanarSpeed", planarSpeed);

        if (planarSpeed > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveVec), 0.3f);
        }

        moveVec.y -= gravity * Time.deltaTime;



        controller.Move(moveVec * speed * Time.deltaTime);

        mouseX += Input.GetAxis("Mouse X") * 5;
        transform.eulerAngles = new Vector3(0, mouseX, 0);

    }
}
  