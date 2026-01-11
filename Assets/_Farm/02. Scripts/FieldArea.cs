using UnityEngine;

public class FieldArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 필드 카메라 우선순위 증가
            CameraManager.ChangeCamera(1, 11);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 필드 카메라 우선순위 감소
            CameraManager.ChangeCamera(1, 0);
        }
    }
}
