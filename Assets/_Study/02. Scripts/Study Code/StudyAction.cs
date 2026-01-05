using UnityEngine;
using System;

public class StudyAction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StudyScore.TriggerScore();

        StudyScore.onScore?.Invoke(10, true);

        StudyScore.onScore?.Invoke(1, false);
    }
}
