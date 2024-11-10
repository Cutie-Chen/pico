using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.0f; // 控制移动速度
    private XROrigin xrOrigin; // 引用XR Origin

    void Start()
    {
        xrOrigin = GetComponent<XROrigin>(); // 获取XROrigin组件
    }

    void Update()
    {
        // 获取手柄输入
        Vector2 input = Vector2.zero;
        var leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (leftHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 leftInput))
        {
            input = leftInput;
        }

        // 键盘输入：WASD或方向键
        if (Input.GetKey(KeyCode.W)) input.y += 1;
        if (Input.GetKey(KeyCode.S)) input.y -= 1;
        if (Input.GetKey(KeyCode.A)) input.x -= 1;
        if (Input.GetKey(KeyCode.D)) input.x += 1;

        // 根据输入方向计算移动向量
        Vector3 move = xrOrigin.Camera.transform.forward * input.y + xrOrigin.Camera.transform.right * input.x;
        move.y = 0; // 确保只在水平面上移动

        // 根据计算的移动向量和速度更新玩家位置
        transform.position += move * speed * Time.deltaTime;
    }
}
