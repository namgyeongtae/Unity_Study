using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarMover : MonoBehaviour
{
    public GridManager gridManager;
    public GameObject startCube, endCube;
    public List<Node> pathList = new List<Node>();

    private AStar aStarCalculator;
    
    void Awake()
    {
        aStarCalculator = new AStar();
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            GetPath();
            yield return new WaitForSeconds(1f);
        }
    }

    private void GetPath()
    {
        int startIndex = gridManager.GetGridIndex(startCube.transform.position);
        int endIndex = gridManager.GetGridIndex(endCube.transform.position);

        if (startIndex == -1 || endIndex == -1) // OUT OF BOUNDS
            return;

        Node startNode = gridManager.nodes[gridManager.GetRow(startIndex), gridManager.GetColumn(startIndex)];  // 시작 위치의 인덱스
        Node endNode = gridManager.nodes[gridManager.GetRow(endIndex), gridManager.GetColumn(endIndex)];        // 도착 지점 위치의 인덱스

        pathList = aStarCalculator.FindPath(startNode, endNode, gridManager);   // A* 알고리즘을 통한 경로 계산
    }

    void OnDrawGizmos()
    {
        if (pathList == null || pathList.Count < 2)
            return;

        Gizmos.color = Color.green;
        for (int i = 0; i < pathList.Count - 1; i++)
        {
            Gizmos.DrawLine(pathList[i].pos, pathList[i + 1].pos);
        }
    }
}
