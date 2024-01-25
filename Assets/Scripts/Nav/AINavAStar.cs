using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Priority_Queue;

public class AINavAStar
{
	public static bool Generate(AINavNode startNode, AINavNode endNode, ref List<AINavNode> path)
	{
		SimplePriorityQueue<AINavNode> nodes = new SimplePriorityQueue<AINavNode>();

		startNode.Cost = 0.0f;
		float heuristic = Vector3.Distance(startNode.transform.position, endNode.transform.position);
		nodes.EnqueueWithoutDuplicates(startNode, startNode.Cost + heuristic);

		bool found = false;
		while (!found && nodes.Count > 0)
		{
			AINavNode node = nodes.Dequeue();

			if (node == endNode)
			{
				found = true;
				break;
			}

			foreach (AINavNode neighbor in node.neighbors)
			{
				float cost = neighbor.Cost + Vector3.Distance(node.transform.position, neighbor.transform.position);
				if (cost < neighbor.Cost)
				{
					neighbor.Cost = cost;
					neighbor.Parent = node;
					heuristic = Vector3.Distance(neighbor.transform.position, endNode.transform.position);
					nodes.EnqueueWithoutDuplicates(neighbor, neighbor.Cost + heuristic);
				}
			}
		}

		path.Clear();
		if (found)
		{
			CreatePathFromParents(endNode, ref path);
		}

		return found;
	}

	public static void CreatePathFromParents(AINavNode node, ref List<AINavNode> path)
	{
		// while node not null
		while (node != null)
		{
			// add node to list path
			path.Add(node);
			// set node to node parent
			node = node.Parent;
		}

		// reverse path
		path.Reverse();
	}
}
