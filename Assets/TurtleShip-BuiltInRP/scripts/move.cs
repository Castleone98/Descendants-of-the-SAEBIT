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
        controller.Move(moveVec * speed * Time.deltaTime);
        //transform.position += moveVec * speed * Time.deltaTime;
        //controller.SimpleMove(moveVec * speed);

        moveVec.y -= gravity * Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            //�ٴڿ� ������ ������ ����
            if (!IsJumping)
            {
                Debug.Log("Jump2");
                //print("���� ���� !");
                //rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                //moveVec.y = jumpForce;
                moveVec.y = jumpForce;
                Debug.Log(moveVec.y);
                transform.position += moveVec * speed * Time.deltaTime;
                //rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                moveVec.y = 0;

            }

            //���߿� ���ִ� �����̸� �������� ���ϵ��� ����
            else
            {
                //print("���� �Ұ��� !");
                return;
            }
        }

    }


    void Jump()
    {
        //�����̽� Ű�� ������ ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            //�ٴڿ� ������ ������ ����
            if (!IsJumping)
            {
                Debug.Log("Jump2");
                //print("���� ���� !");
                //rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                moveVec.y = jumpForce;
            }

            //���߿� ���ִ� �����̸� �������� ���ϵ��� ����
            else
            {
                //print("���� �Ұ��� !");
                return;
            }
        }
    }

  


    //public float moveSpeed = 5.0f;

    //private void Update()
    //{
    //    // Ű���� �Է��� �޾� ĳ���� ������ ���
    //    float horizontalInput = Input.GetAxis("Horizontal");
    //    float verticalInput = Input.GetAxis("Vertical");

    //    Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
    //    moveDirection.Normalize();

    //    // ĳ������ ��ġ�� ������ ����� �ӵ��� ���� ������ ������Ʈ
    //    transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

    //    //ĳ������ ������ ������ �ٶ󺸵��� ȸ��
    //    //if (moveDirection != Vector3.zero)
    //    //{
    //    //    Quaternion newRotation = Quaternion.LookRotation(moveDirection);
    //    //    transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10.0f);
    //    //}

    //    // ���� ĳ������ ȸ������ ������
    //    Quaternion currentRotation = transform.rotation;

    //    // ������ ��Ÿ���� ȸ������ ���
    //    Quaternion targetRotation = Quaternion.Euler(0, 0, 0); // (x, y, z) ������ ����

    //    // ȸ������ �ε巴�� �����Ͽ� ������Ʈ
    //    transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * 5.0f);
    //}
}