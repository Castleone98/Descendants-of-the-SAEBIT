using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform targetPosition; // �̵��� ��ġ
    public Camera mainCamera; // ���� ��� ���� ī�޶�
    public Camera otherCamera; // ��ȯ�� ī�޶�

    private bool isOtherCameraActive = false;

    void Update()
    {
        // F Ű�� ������ �� ī�޶� ��ȯ
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchCamera();
        }
    }

    void SwitchCamera()
    {
        isOtherCameraActive = !isOtherCameraActive;

        // �ٸ� ī�޶� Ȱ��ȭ �Ǵ� ��Ȱ��ȭ
        mainCamera.enabled = !isOtherCameraActive;
        otherCamera.enabled = isOtherCameraActive;

        // ĳ���� ��ġ �̵�
        if (isOtherCameraActive)
        {
            // ���ϴ� ��ġ�� �̵�
            transform.position = targetPosition.position;
            transform.rotation = targetPosition.rotation;
        }
    }
}
