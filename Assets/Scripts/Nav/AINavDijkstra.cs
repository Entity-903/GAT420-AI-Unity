using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Priority_Queue;

public class AINavDijkstra {
	public static bool Generate(AINavNode startNode, AINavNode endNode, ref List<AINavNode> path) {
		SimplePriorityQueue<AINavNode> nodes = new SimplePriorityQueue<AINavNode>();

		startNode.Cost = 0.0f;
		nodes.EnqueueWithoutDuplicates(startNode, startNode.Cost);

		bool found = false;
		while(!found && nodes.Count > 0) {
			AINavNode node = nodes.Dequeue();

			if(node == endNode) {
				found = true;
				break;
			}

			foreach(AINavNode neighbor in node.neighbors) {
				float cost = neighbor.Cost + Vector3.Distance(node.transform.position, neighbor.transform.position);
				if(cost < neighbor.Cost) {
					neighbor.Cost = cost;
					neighbor.Parent = node;

					nodes.EnqueueWithoutDuplicates(neighbor, neighbor.Cost);
				}
			}
		}

		path.Clear();
		if(found) {
			CreatePathFromParents(endNode, ref path);
		}

		return found;
	}

	public static void CreatePathFromParents(AINavNode node, ref List<AINavNode> path) {
		// while node not null
		while(node != null) {
			// add node to list path
			path.Add(node);
			// set node to node parent
			node = node.Parent;
		}

		// reverse path
		path.Reverse();
	}
}
