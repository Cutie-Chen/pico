using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.0f; // �����ƶ��ٶ�
    private XROrigin xrOrigin; // ����XR Origin

    void Start()
    {
        xrOrigin = GetComponent<XROrigin>(); // ��ȡXROrigin���
    }

    void Update()
    {
        // ��ȡ�ֱ�����
        Vector2 input = Vector2.zero;
        var leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (leftHand.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 leftInput))
        {
            input = leftInput;
        }

        // �������룺WASD�����
        if (Input.GetKey(KeyCode.W)) input.y += 1;
        if (Input.GetKey(KeyCode.S)) input.y -= 1;
        if (Input.GetKey(KeyCode.A)) input.x -= 1;
        if (Input.GetKey(KeyCode.D)) input.x += 1;

        // �������뷽������ƶ�����
        Vector3 move = xrOrigin.Camera.transform.forward * input.y + xrOrigin.Camera.transform.right * input.x;
        move.y = 0; // ȷ��ֻ��ˮƽ�����ƶ�

        // ���ݼ�����ƶ��������ٶȸ������λ��
        transform.position += move * speed * Time.deltaTime;
    }
}
