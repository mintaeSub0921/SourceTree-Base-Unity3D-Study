using System.Collections.Generic;
using UnityEngine;

public class AStar
{
    private float HeuristicEstimateCost(Node currNode, Node endNode)
    {
        return (currNode.pos - endNode.pos).magnitude;
    }

    public List<Node> FindPath(Node startNode, Node endNode, GridManager gridManager)
    {
        gridManager.ResetNodes();

        var openList = new PriorityQueue();
        var closedList = new PriorityQueue();

        startNode.nodeTotalCost = 0;
        startNode.estimateCost = HeuristicEstimateCost(startNode, endNode);
        startNode.parent = null;

        openList.Push(startNode);

        Node node = null;

        while (openList.Length != 0)
        {
            node = openList.Fisrt();
            openList.Remove(node);
            closedList.Push(node);

            if (node == endNode)
            {
                return CalculatePath(node);
            }

            List<Node> neighbors = new List<Node>();
            gridManager.GetNeighbors(node, neighbors);

            for (int i = 0; i < neighbors.Count; i++)
            {
                Node neighborNode = neighbors[i];

                if (closedList.Contains(neighborNode))
                    continue;

                float costToMove = (node.pos - neighborNode.pos).magnitude; // 목적지까지의 최단 거리
                float tentativeG = node.nodeTotalCost + costToMove;

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

        Debug.LogError("Destination Path Not Found");
        return null;

    }

    private List<Node> CalculatePath(Node node)
    {
        List<Node> list = new List<Node>();
        while (node != null)
        {
            list.Add(node);
            node = node.parent;

        }

        list.Reverse();
        return list;


    }



}
