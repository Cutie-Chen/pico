using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_detect : MonoBehaviour
{
    bool shouldRotate = true;
    public GameObject cube;
    public GameObject number;
    public Vector3 rotationSpeed = new Vector3(0, 100, 0);
    public int coinIndex;   //当前金币的索引
    private CoinManager coinManager;

    private void Start()
    {
        coinManager = FindObjectOfType<CoinManager>();
    }

    private void Update()
    {
        // 如果需要旋转，才进行旋转
        if (shouldRotate)
        {
            cube.transform.Rotate(rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("进入了碰撞");
        //cube.SetActive(true);
    }

    private void OnTriggerStay(Collider collision)
    {
        Debug.Log("碰撞停留");
        //用户按键后，金币变成数字，目前仅写了键盘事件
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cube.SetActive(false);
            number.SetActive(true);
            shouldRotate=false;
            
            coinManager.ShowNextCoin(coinIndex);    //显示下一个金币
        }
    }

    /*private void OnTriggerExit(Collider collision)
    {
        Debug.Log("碰撞离开");
        cube.SetActive(false);
        shouldRotate = false;
    }
    */
}
