using UnityEngine;
using UnityEngine.Events;

public class StudyUnityEvent : MonoBehaviour
{
    public delegate void MyDelegate();
    public UnityEvent uEvent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 사용 불가
        /* uEvent -= MethodA;
        uEvent += MethodA; */

        uEvent.AddListener(MethodA);
        uEvent.RemoveListener(MethodA);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))   
        {
            uEvent?.Invoke();
        }
    }

    public void AddMethod(UnityAction method)
    {
        uEvent.AddListener(method);
    }

    public void MethodA()
    {

    }
}
