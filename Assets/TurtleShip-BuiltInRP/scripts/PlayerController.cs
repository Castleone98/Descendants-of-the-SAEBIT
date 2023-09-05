using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform targetPosition; // 이동할 위치
    public Camera mainCamera; // 현재 사용 중인 카메라
    public Camera otherCamera; // 전환할 카메라

    private bool isOtherCameraActive = false;

    void Update()
    {
        // F 키를 눌렀을 때 카메라 전환
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchCamera();
        }
    }

    void SwitchCamera()
    {
        isOtherCameraActive = !isOtherCameraActive;

        // 다른 카메라를 활성화 또는 비활성화
        mainCamera.enabled = !isOtherCameraActive;
        otherCamera.enabled = isOtherCameraActive;

        // 캐릭터 위치 이동
        if (isOtherCameraActive)
        {
            // 원하는 위치로 이동
            transform.position = targetPosition.position;
            transform.rotation = targetPosition.rotation;
        }
    }
}
