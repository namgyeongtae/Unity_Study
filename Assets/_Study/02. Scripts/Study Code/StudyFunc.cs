using System;
using System.Collections.Generic;
using UnityEngine;

public class StudyFunc : MonoBehaviour
{
    public Func<int, int, int> myFunc;
    public Func<string, string, bool> myFunc2;

    public List<Func<int, int, int>> funcList = new();

    public Func<Vector3, Vector3, bool> lookAtPlayer;

    void Start()
    {
        /* myFunc = AddMethod;
        int result = myFunc(10, 20);
        Debug.Log(result);

        myFunc2 = CompareText;
        bool result2 = myFunc2("Hello", "Hello");
        Debug.Log(result2); */
    
        funcList.Add((a, b) => a + b);
        funcList.Add((a, b) => a - b);
        funcList.Add((a, b) => a * b);

        int result = 0;

        foreach (var func in funcList)
        {
            int tempResult = func(10, 20);
            Debug.Log($"TempResult: {tempResult}");
            result += tempResult;
        }
        Debug.Log($"총합: {result}");

        lookAtPlayer = CompareAngle;

        ExternalClass.attackEvent += BackAttack;
    }

    /* public int AddMethod(int a, int b)
    {
        return a + b;
    }

    public int MinusMethod(int a, int b)
    {
        return a - b;
    }

    public int MultiplyMethod(int a, int b)
    {
        return a * b;
    } */

    public bool CompareText(string a, string b)
    {
        if (a == b)
            return true;

        return false;
    }
    
    private void BackAttack()
    {
       lookAtPlayer?.Invoke(Vector3.one, Vector3.zero);
    }

    public bool CompareAngle(Vector3 playerDir, Vector3 lookDir)
    {
        float angle =Vector3.Angle(playerDir, lookDir);

        if (angle <= 45f)
            return true;
        else
            return false;
    }
}
