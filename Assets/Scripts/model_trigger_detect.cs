using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class model_trigger_detect : MonoBehaviour
{
    public GameObject cube;
    public GameObject number;
    public Vector3 rotationSpeed = new Vector3(0, 100, 0);
    public int coinIndex;   //��ǰ��ҵ�����
    private CoinManager coinManager;
    InputDevice deviceLeft;//���ֱ�
    InputDevice deviceRight;//���ֱ�
    bool L_Value;
    bool R_Value;
    private void Start()
    {
        deviceLeft = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        deviceRight = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        coinManager = FindObjectOfType<CoinManager>();
    }

    /// <summary>
    /// �����
    /// </summary>
    /// <param name="inputDevice">�ֱ�</param>
    /// <param name="action">����ί��</param>
    /// <param name="Value">��������</param>
    void triggerButton(InputDevice inputDevice, ref bool Value)
    {
        if (inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out Value) && Value)
        {
            
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("��������ײ");
        //cube.SetActive(true);
    }

    private void OnTriggerStay(Collider collision)
    {
        Debug.Log("��ײͣ��");
        //�û������󣬽�ұ�����֣�Ŀǰ��д�˼����¼�
        if ((deviceLeft.TryGetFeatureValue(CommonUsages.gripButton, out L_Value) && L_Value)|| (deviceRight.TryGetFeatureValue(CommonUsages.gripButton, out R_Value) && R_Value) || (Input.GetKeyDown(KeyCode.Space)))
        {
            //cube.SetActive(false);
            number.SetActive(true);
            
            coinManager.ShowNextCoin(coinIndex);    //��ʾ��һ�����
        }
    }

    /*private void OnTriggerExit(Collider collision)
    {
        Debug.Log("��ײ�뿪");
        cube.SetActive(false);
        shouldRotate = false;
    }
    */
}
