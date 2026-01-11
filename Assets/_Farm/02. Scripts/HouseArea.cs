using UnityEngine;

public class HouseArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 집 카메라 우선순위 증가
            CameraManager.ChangeCamera(2, 11);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 집 카메라 우선순위 감소
            CameraManager.ChangeCamera(2, 0);
        }
    }
}
