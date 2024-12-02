using UnityEngine;

public class ModelManager : MonoBehaviour
{
    public GameObject[] cubes;    // ���н��
    public GameObject[] numbers;  // ��Ӧ������
    private int currentIndex = 0; // ��ǰ��ʾ�Ľ������

    void Start()
    {
        // ��ʼ��ʱ�����н�Һ����ֶ�����
        foreach (GameObject cube in cubes)
        {
            cube.SetActive(false);
        }
        foreach (GameObject number in numbers)
        {
            number.SetActive(false);
        }
        cubes[currentIndex].SetActive(true);
    }

    // ������ʾ��һ�����
    public void ShowNextCoin(int coinIndex)
    {
        if (coinIndex == currentIndex)
        {
            // ��ʾ��ǰ��Ҳ���������
            cubes[coinIndex].SetActive(true);
            numbers[coinIndex].SetActive(false);

            // ����������׼����ʾ��һ�����
            currentIndex++;

            // ������и���Ľ�ң���ʾ��һ�����
            if (currentIndex < cubes.Length)
            {
                cubes[currentIndex].SetActive(true);
            }
        }
    }
}
