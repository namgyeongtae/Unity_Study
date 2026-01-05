using System;
using UnityEngine;

public class StudyPredicate : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Predicate<float> myPredicate;

    void Start()
    {
        myPredicate = (h) => h < 0;
    }

    // A키 왼쪽 보기
    // D키 눌렀을 때 오른쪽 보기
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        spriteRenderer.flipX = myPredicate(h);
    }
}
