using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ���� ��� (�÷��̾�)
    public float smoothSpeed = 5f; // �ε巯�� �̵� �ӵ�
    public Vector3 offset; // ī�޶� ��ġ ������

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        }
    }
}

