using UnityEngine;

public class ExternalClass : MonoBehaviour
{
    public delegate void AttackDelegate();
    public static event AttackDelegate attackEvent;

    void Start()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            attackEvent?.Invoke();
        }
    }
}