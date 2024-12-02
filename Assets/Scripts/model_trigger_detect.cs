using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class model_trigger_detect : MonoBehaviour
{
    public GameObject cube;
    public GameObject number;
    public Vector3 rotationSpeed = new Vector3(0, 100, 0);
    public int coinIndex;   //当前金币的索引
    private CoinManager coinManager;
    InputDevice deviceLeft;//左手柄
    InputDevice deviceRight;//右手柄
    bool L_Value;
    bool R_Value;
    private void Start()
    {
        deviceLeft = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        deviceRight = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        coinManager = FindObjectOfType<CoinManager>();
    }

    /// <summary>
    /// 扳机键
    /// </summary>
    /// <param name="inputDevice">手柄</param>
    /// <param name="action">触发委托</param>
    /// <param name="Value">触发参数</param>
    void triggerButton(InputDevice inputDevice, ref bool Value)
    {
        if (inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out Value) && Value)
        {
            
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
        if ((deviceLeft.TryGetFeatureValue(CommonUsages.gripButton, out L_Value) && L_Value)|| (deviceRight.TryGetFeatureValue(CommonUsages.gripButton, out R_Value) && R_Value) || (Input.GetKeyDown(KeyCode.Space)))
        {
            //cube.SetActive(false);
            number.SetActive(true);
            
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
