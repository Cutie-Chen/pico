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
        // 如果触发器内停留，旋转物体
        if (shouldRotate)
        {
            cube.transform.Rotate(rotationSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("进入了碰撞");
        cube.SetActive(true);
    }

    private void OnTriggerStay(Collider collision)
    {
        Debug.Log("碰撞停留");
        shouldRotate = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("碰撞离开");
        cube.SetActive(false);
        shouldRotate = false;
    }
}
