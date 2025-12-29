using System;
using UnityEngine;

public class Node : IComparable<Node>
{
    public Node parent;
    public Vector3 pos;

    public float nodeTotalCost; // G (시작점 ~ 현재지점까지 거리)
    public float estimateCost; // H (현재 ~ 목표지점까지의 거리)

    public bool isObstacle;

    public Node(Vector3 pos)
    {
        this.pos = pos;
        parent = null;
        nodeTotalCost = 0f;
        estimateCost = 0f;
        isObstacle = false;
    }

    public void SetObstacle()
    {
        isObstacle = true;
    }

    public float GetFCost()
    {
        return nodeTotalCost + estimateCost;
    }

    public int CompareTo(Node other) // 새로운 경로로
    {
        float myF = GetFCost();
        float otherF = other.GetFCost();

        if (myF < otherF)
            return -1;
        if (myF > otherF)   // 새로운 경로가 더 짧은 경로라면면
            return 1;

        if (estimateCost < other.estimateCost)
            return -1;
        if (estimateCost > other.estimateCost)
            return 1;

        return 0;
    }
}
