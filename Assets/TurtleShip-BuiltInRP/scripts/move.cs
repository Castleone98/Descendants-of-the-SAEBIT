using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class move : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private void Update()
    {
        // Ű���� �Է��� �޾� ĳ���� ������ ���
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        moveDirection.Normalize();

        // ĳ������ ��ġ�� ������ ����� �ӵ��� ���� ������ ������Ʈ
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        //ĳ������ ������ ������ �ٶ󺸵��� ȸ��
        //if (moveDirection != Vector3.zero)
        //{
        //    Quaternion newRotation = Quaternion.LookRotation(moveDirection);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10.0f);
        //}

        //// ���� ĳ������ ȸ������ ������
        //Quaternion currentRotation = transform.rotation;

        //// ������ ��Ÿ���� ȸ������ ���
        //Quaternion targetRotation = Quaternion.Euler(0, 0, 0); // (x, y, z) ������ ����

        //// ȸ������ �ε巴�� �����Ͽ� ������Ʈ
        //transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * 5.0f);
    }
}