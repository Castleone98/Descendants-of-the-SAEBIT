using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public Transform target;   // ���� ��� (ĳ������ Transform)

    public Vector3 offset = new Vector3(0.0f, 1.0f, 0.0f); // ī�޶�� ĳ���� ������ �Ÿ� ����

    public float smoothSpeed = 0.125f;  // ī�޶��� �ε巯�� �̵��� ���� ����

    private void LateUpdate()
    {
        // ����� ��ġ�� �������� ���� ��ġ ���
        Vector3 desiredPosition = target.position + offset;

        // �ε巯�� �̵��� ���� Lerp �Լ� ���
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // ī�޶��� ��ġ�� �ε巯�� �̵��� ��ġ�� ������Ʈ
        transform.position = smoothedPosition;

        // ī�޶� ����� �ٶ󺸵��� ȸ��
        transform.LookAt(target);
    }
}
