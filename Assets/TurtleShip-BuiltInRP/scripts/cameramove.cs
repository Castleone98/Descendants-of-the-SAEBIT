using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public Transform target;   // 따라갈 대상 (캐릭터의 Transform)

    public Vector3 offset = new Vector3(0.0f, 1.0f, 0.0f); // 카메라와 캐릭터 사이의 거리 조절

    public float smoothSpeed = 0.125f;  // 카메라의 부드러운 이동을 위한 변수

    private void LateUpdate()
    {
        // 대상의 위치에 오프셋을 더한 위치 계산
        Vector3 desiredPosition = target.position + offset;

        // 부드러운 이동을 위해 Lerp 함수 사용
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // 카메라의 위치를 부드러운 이동된 위치로 업데이트
        transform.position = smoothedPosition;

        // 카메라가 대상을 바라보도록 회전
        transform.LookAt(target);
    }
}
