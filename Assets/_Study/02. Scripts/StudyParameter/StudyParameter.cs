using UnityEngine;

public class StudyParameter : MonoBehaviour
{
    void Start()
    {
        NormalParameter(number);
        RefParameter(ref number);
        OutParameter(out number);
    }
    
    public int number = 10;

    private void NormalParameter(int num)
    {
        Debug.Log("NormalParameter: " + num);
        num += 100;

        Debug.Log("NormalParameter: " + number);
    }

    private void RefParameter(ref int num)
    {
        Debug.Log("RefParameter: " + num);
        num += 100;

        Debug.Log("RefParameter: " + number);
    }

    private void OutParameter(out int num)
    {
        num = 200;

        Debug.Log("OutParameter: " + number);
    }
}
