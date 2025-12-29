using System.Collections.Generic;
using UnityEngine;

public class AStar
{
    private float HeuristicEstimateCost(Node curNode, Node endNode)
    {
        return (curNode.pos - endNode.pos).magnitude; // 유클리드 거리 계산법을 휴리스틱 함수로 채택
    }

    public List<Node> FindPath(Node startNode, Node endNode, GridManager gridManager)
    {
        ///////////////////////////// Node Initialization Step ///////////////////////////
        gridManager.ResetNodes();

        var openList = new PriorityQueue();     // 미방문 노드 리스트 (방문 예정 노드 리스트)
        var closedList = new PriorityQueue();   // 방문하여 더 이상 살펴볼 필요 없는 노드 리스트

        startNode.nodeTotalCost = 0;
        startNode.estimateCost = HeuristicEstimateCost(startNode, endNode);
        startNode.parent = null;

        openList.Push(startNode);

        Node node = null;
        /////////////////////////////////////////////////////////////////////////////////////
        
        
        while (openList.Length != 0)
        {
            node = openList.First();
            openList.Remove(node);
            closedList.Push(node);

            if (node == endNode) // 도착했다면
                return CalculatePath(node);

            
            List<Node> neighbors = new List<Node>();
            gridManager.GetNeighbors(node, neighbors);

            for (int i = 0; i < neighbors.Count; i++)
            {
                Node neighborNode = neighbors[i];

                if (closedList.Contains(neighborNode))  // 이미 방문한 노드라면 Skip
                    continue;

                float constToMove = (node.pos - neighborNode.pos).magnitude; // 이웃 노드까지의 최단 거리
                float tentativeG = node.nodeTotalCost + constToMove; // 아직 결정하지 않은 추정 거리

                bool isInOpenList = openList.Contains(neighborNode);

                if (!isInOpenList || tentativeG < neighborNode.nodeTotalCost)
                {
                    neighborNode.nodeTotalCost = tentativeG;
                    neighborNode.estimateCost = HeuristicEstimateCost(neighborNode, endNode);
                    neighborNode.parent = node;

                    if (!isInOpenList)
                        openList.Push(neighborNode);
                }
            }
        }
        
        Debug.LogError("No path found");
        return null;
    }

    // 인자로 주어진 노드를 시작으로 parent를 계속 추적하여 경로를 재설정하여 반환하는 함수
    private List<Node> CalculatePath(Node node)
    {
        List<Node> path = new List<Node>();

        Node curNode = node;
        path.Add(node);

        while (curNode.parent != null)
        {
            path.Add(curNode.parent);
            curNode = curNode.parent;
        }

        path.Reverse();

        return path;
    }
}
