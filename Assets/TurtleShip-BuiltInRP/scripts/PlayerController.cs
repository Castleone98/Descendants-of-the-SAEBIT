using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform targetPosition; // �̵��� ��ġ
    public GameObject target;
    public move move_script;
    public Camera mainCamera; // ���� ��� ���� ī�޶�
    public Camera otherCamera; // ��ȯ�� ī�޶�

    private bool isOtherCameraActive = false;
    private bool main_character = false;

    private void Awake()
    {
        target.GetComponent<move>();
    }

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

        if (isOtherCameraActive)
        {
            target.GetComponent<move>().enabled = true;
            this.GetComponent<move>().enabled = false;
        }
        else
        {
            this.GetComponent<move>().enabled = true;
            target.GetComponent<move>().enabled = false;

        }

        // ĳ���� ��ġ �̵�
        //if (isOtherCameraActive)
        //{
        //    // ���ϴ� ��ġ�� �̵�
        //    transform.position = targetPosition.position;
        //    transform.rotation = targetPosition.rotation;
        //}
    }
}
