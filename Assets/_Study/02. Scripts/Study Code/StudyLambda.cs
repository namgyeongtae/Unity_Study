using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudyLambda : MonoBehaviour
{
    public delegate void MyDelegate(string s);
    public MyDelegate myDelegate;

    public delegate void MyDelegate2();
    public MyDelegate2 myDelegate2;

    public Button buttonUI;

    public Button[] buttonUIs;

    public List<int> numbers = new List<int>();

    void Start()
    {
        buttonUI.onClick.AddListener(ButtonEvent);
        buttonUI.onClick.AddListener(() => ButtonEvent2(10));

        /* buttonUI.onClick.AddListener(delegate 
        {
            ButtonEvent();
            ButtonEvent2();
            ButtonEvent3();
        }); */

        buttonUI.onClick.AddListener(() => ButtonEvent());

        #region List
        for (int i = 0; i < 10; i++)
            numbers.Add(i);
        
        numbers.Sort();

        numbers.Clear();

        numbers.RemoveAll(n => n % 2 == 0);
        #endregion
    
        // 클로져(Closure) 이슈 주의의
        for (int i = 0; i < buttonUIs.Length; i++)
        {
            int index = i;
            buttonUIs[i].onClick.AddListener(() => ButtonEvent2(index));
        }
    }

    public void ButtonEvent()
    {
        Debug.Log("Button Clicked");
    }

    public void ButtonEvent2(int number)
    {
        Debug.Log("Button Clicked2");
    }

    public void ButtonEvent3()
    {
        Debug.Log("Button Clicked3");
    }
}
