using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtle_cameramove : MonoBehaviour
{

    public GameObject Target;               // ī�޶� ����ٴ� Ÿ��

    public float offsetX = 1.94f;            // ī�޶��� x��ǥ
    public float offsetY = 63.0f;           // ī�޶��� y��ǥ
    public float offsetZ = 75.0f;          // ī�޶��� z��ǥ

    public float angleX = 0.0f;
    public float angleY = 0.0f;
    public float angleZ = 0.0f;

    public float CameraSpeed = 10.0f;       // ī�޶��� �ӵ�
    Vector3 TargetPos;                      // Ÿ���� ��ġ

    // Update is called once per frame
    void FixedUpdate()
    {
        // Ÿ���� x, y, z ��ǥ�� ī�޶��� ��ǥ�� ���Ͽ� ī�޶��� ��ġ�� ����
        TargetPos = new Vector3(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ
            );

        // ī�޶��� �������� �ε巴�� �ϴ� �Լ�(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);

        transform.rotation = Quaternion.Euler(angleX, angleY, angleZ);
    }
}

