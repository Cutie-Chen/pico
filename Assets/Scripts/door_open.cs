using UnityEngine;
using System.Collections;
using SojaExiles;

public class door_open : MonoBehaviour
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
            StartCoroutine(opening());
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("��ײ�뿪");
        if (open == true)
        {
            StartCoroutine(closing());
        }

    }
    IEnumerator opening()
    {
        print("you are opening the door");
        openandclose.Play("Opening");
        open = true;
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator closing()
    {
        print("you are closing the door");
        openandclose.Play("Closing");
        open = false;
        yield return new WaitForSeconds(.5f);
    }


}
