using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Farm
{
    public class SelectCharacter : MonoBehaviour
    {
        private const int CHARACTER_COUNT = 4;

        [SerializeField] private Transform centerPivot;
        [SerializeField] private Animator[] characterAnims;
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;
        [SerializeField] private Button selectButton;

        private int characterIndex = 0;

        private bool isTurn;

        void Start()
        {
            leftButton.onClick.AddListener(TurnLeft);
            rightButton.onClick.AddListener(TurnRight);
            selectButton.onClick.AddListener(Select);
        }

        private void TurnLeft() // 왼쪽으로 회전하는 기능
        {
            characterIndex--;

            if (characterIndex < 0)
                characterIndex = CHARACTER_COUNT - 1;

           /*  Vector3 targetEulerAngles = centerPivot.rotation.eulerAngles + new Vector3(0, -90, 0);
            Debug.Log(targetEulerAngles);
            Quaternion targetRot = Quaternion.Euler(targetEulerAngles); */

            var targetRot = centerPivot.rotation * Quaternion.Euler(0, -90, 0);
            
            StartCoroutine(Turn(targetRot));

            Debug.Log(characterIndex);
        }

        private void TurnRight() // 오른쪽으로 회전하는 기능
        {
            characterIndex++;

            if (characterIndex > CHARACTER_COUNT - 1)
                characterIndex = 0;

            // 90도 회전
            /* Vector3 targetEulerAngles = centerPivot.rotation.eulerAngles + new Vector3(0, 90, 0);
            Debug.Log(targetEulerAngles);
            Quaternion targetRot = Quaternion.Euler(targetEulerAngles); */

            var targetRot = centerPivot.rotation * Quaternion.Euler(0, 90, 0);
            
            StartCoroutine(Turn(targetRot));

            Debug.Log(characterIndex);
        }

        private void Select()   // 현재 캐릭터를 선택하는 기능
        {
            DataManager.Instance.SelectCharacterIndex = characterIndex;
        }

        private IEnumerator Turn(Quaternion targetRot)
        {
            float rotateTime = 1f;
            float currentRotateTime = 0f;

            leftButton.interactable = false;
            rightButton.interactable = false;

            while (!Mathf.Approximately(Quaternion.Angle(centerPivot.rotation, targetRot), 0))
            {
                currentRotateTime += Time.deltaTime;

                float t = currentRotateTime / rotateTime;

                centerPivot.rotation = Quaternion.Slerp(centerPivot.rotation, targetRot, t);

                yield return null;
            }

            centerPivot.rotation = targetRot; // 쌓이는 오차 제거

            leftButton.interactable = true;
            rightButton.interactable = true;
        }
    }
}

