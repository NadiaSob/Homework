#include <vector>
#include "Graph.h"
#include "PriorityQueue.h"
#include "PrimAlgorithm.h"

using namespace std;

Graph *primAlgorithm(Graph *graph)
{
	Graph *minSpanningTree = createGraph(graph->size);
	minSpanningTree->size = graph->size;
	PriorityQueue *queue = createPriorityQueue();

	int node = 0;
	int temp = 0;
	while (temp < graph->size - 1)
	{
		for (int j = 0; j < graph->size; ++j)
		{
			if (graph->edges[node][j] != 0 && minSpanningTree->edges[node][j] == 0)
			{
				enqueue(queue, node, j, graph->edges[node][j]);
			}
		}

		int adjacentNode = dequeue(queue, node);
		while (exists(minSpanningTree, node) && exists(minSpanningTree, adjacentNode))
		{
			adjacentNode = dequeue(queue, node);
		}

		add(minSpanningTree, node, adjacentNode, graph->edges[node][adjacentNode]);
		add(minSpanningTree, adjacentNode, node, graph->edges[node][adjacentNode]);
		node = adjacentNode;
		++temp;
	}
	deleteQueue(queue);
	return minSpanningTree;
}