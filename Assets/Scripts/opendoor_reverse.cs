using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class opendoor_reverse : MonoBehaviour
{
    public GameObject cube;                   // �ŵĶ���

    public Animator openandclose;
    public bool open;


    void Start()
    {

        open = false;
    }
private void OnTriggerEnter(Collider collision)
{
    Debug.Log("��������ײ");
    if (open == false)
    {
        StartCoroutine(closing());
    }
}

private void OnTriggerExit(Collider collision)
{
    Debug.Log("��ײ�뿪");
    if (open == true)
    {
        StartCoroutine(opening());
    }

}
IEnumerator opening()
{
    print("you are opening the door");
    openandclose.Play("open_reverse");
    open = true;
    yield return new WaitForSeconds(.5f);
}

IEnumerator closing()
{
    print("you are closing the door");
    openandclose.Play("close_reverse");
    open = false;
    yield return new WaitForSeconds(.5f);
}

}
