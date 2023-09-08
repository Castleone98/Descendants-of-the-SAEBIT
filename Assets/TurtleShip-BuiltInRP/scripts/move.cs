using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
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

        if (planarSpeed > 0)
        {
            // 현재 카메라의 방향을 고려하여 움직임 벡터를 변환
            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0; // y 축은 고려하지 않음
            cameraForward = cameraForward.normalized;
            moveVec = Quaternion.FromToRotation(Vector3.forward, cameraForward) * moveVec;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveVec), 0.3f);
        }

        moveVec.y -= gravity * Time.deltaTime;

        mouseX += Input.GetAxis("Mouse X") * 4;
        //mouseX = Mathf.Clamp(mouseX, -100, 100);
        transform.eulerAngles = new Vector3(0, mouseX, 0);

        controller.Move(moveVec * speed * Time.deltaTime);





        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            if (!IsJumping)
            {
                Debug.Log("Jump2");
                
                moveVec.y = jumpForce;
                Debug.Log(moveVec.y);
                //rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                controller.Move(moveVec * speed * Time.deltaTime);
                moveVec.y = 0;
            }

            else
            {
                return;
            }
        }

    }
}
  