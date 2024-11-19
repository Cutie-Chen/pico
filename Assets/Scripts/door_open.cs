using UnityEngine;
using System.Collections;
using SojaExiles;

public class door_open : MonoBehaviour
{
    public GameObject cube;                   // 门的对象
    
    public Animator openandclose;
    public bool open;

    void Start()
    {
        open = false;
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("进入了碰撞");
        if (open == false)
        {
            StartCoroutine(opening());
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("碰撞离开");
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
