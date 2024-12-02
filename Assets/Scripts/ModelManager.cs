using UnityEngine;

public class ModelManager : MonoBehaviour
{
    public GameObject[] cubes;    // 所有金币
    public GameObject[] numbers;  // 对应的数字
    private int currentIndex = 0; // 当前显示的金币索引

    void Start()
    {
        // 初始化时，所有金币和数字都隐藏
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

    // 控制显示下一个金币
    public void ShowNextCoin(int coinIndex)
    {
        if (coinIndex == currentIndex)
        {
            // 显示当前金币并隐藏数字
            cubes[coinIndex].SetActive(true);
            numbers[coinIndex].SetActive(false);

            // 更新索引，准备显示下一个金币
            currentIndex++;

            // 如果还有更多的金币，显示下一个金币
            if (currentIndex < cubes.Length)
            {
                cubes[currentIndex].SetActive(true);
            }
        }
    }
}
