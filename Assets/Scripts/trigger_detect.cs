using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_detect : MonoBehaviour
{
    bool shouldRotate = true;
    public GameObject cube;
    public GameObject number;
    public Vector3 rotationSpeed = new Vector3(0, 100, 0);
    public int coinIndex;   //��ǰ��ҵ�����
    private CoinManager coinManager;

    private void Start()
    {
        coinManager = FindObjectOfType<CoinManager>();
    }

    private void Update()
    {
        // �����Ҫ��ת���Ž�����ת
        if (shouldRotate)
        {
            cube.transform.Rotate(rotationSpeed * Time.deltaTime);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cube.SetActive(false);
            number.SetActive(true);
            shouldRotate=false;
            
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
