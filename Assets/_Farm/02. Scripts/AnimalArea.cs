using UnityEngine;

public class AnimalArea : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 동물 카메라 우선순위 증가
            CameraManager.ChangeCamera(3, 11);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 동물 카메라 우선순위 감소
            CameraManager.ChangeCamera(3, 0);
        }
    }
}
