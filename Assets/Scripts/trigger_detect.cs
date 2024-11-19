using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_detect : MonoBehaviour
{
    bool shouldRotate = false;
    public GameObject cube;
    public Vector3 rotationSpeed = new Vector3(0, 100, 0);
    void Update()
    {
        // �����������ͣ������ת����
        if (shouldRotate)
        {
            cube.transform.Rotate(rotationSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("��������ײ");
        cube.SetActive(true);
    }

    private void OnTriggerStay(Collider collision)
    {
        Debug.Log("��ײͣ��");
        shouldRotate = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("��ײ�뿪");
        cube.SetActive(false);
        shouldRotate = false;
    }
}
