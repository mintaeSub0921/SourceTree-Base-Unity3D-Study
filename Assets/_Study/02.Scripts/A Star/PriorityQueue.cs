using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue
{
    private List<Node> nodes = new List<Node>();

    public int Length
    {
        get => nodes.Count;
    }

    public bool Contains(Node node)
    {
        return nodes.Contains(node);
    }

    public Node Fisrt() // 우선순위 높은 노드 접근
    {
        if (Length == 0)
            return null;

        return nodes[0];
    }

    public void Push(Node node) // 데이터 추가 및 정렬
    {
        nodes.Add(node);
        nodes.Sort();
    }

    public void Remove(Node node) // 데이터 삭제 및 정렬
    {
        nodes.Remove(node);
        nodes.Sort();
    }
}
