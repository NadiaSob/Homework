#include <iostream>
#include "Graph.h"

using namespace std;

struct Graph
{
	int **matrix;
	int numberOfNodes = 0;
	int numberOfEdges = 0;
};

Graph *createGraph(const int numberOfNodes, const int numberOfEdges)
{
	Graph *newGraph = new Graph;
	newGraph->matrix = new int*[numberOfNodes] {};
	for (int i = 0; i < numberOfNodes; ++i)
	{
		newGraph->matrix[i] = new int[numberOfEdges] {};
	}

	newGraph->numberOfNodes = numberOfNodes;
	newGraph->numberOfEdges = numberOfEdges;

	return newGraph;
}

void add(Graph *graph, const int node, const int edge,  const int value)
{
	graph->matrix[node][edge] = value;
}

void printGraph(Graph *graph)
{
	for (int i = 0; i < graph->numberOfNodes; ++i)
	{
		for (int j = 0; j < graph->numberOfEdges; ++j)
		{
			cout << graph->matrix[i][j] << " ";
		}
		cout << endl;
	}
}

void deleteGraph(Graph *graph)
{
	for (int i = 0; i < graph->numberOfNodes; ++i)
	{
		delete[] graph->matrix[i];
	}
	delete[] graph->matrix;
	delete graph;
}

bool findWay(Graph *graph, const int firstNode, const int secondNode);

int findNodeToEnter(Graph *graph, const int node);

bool isReachable(Graph *graph, const int node)
{
	for (int i = 0; i < graph->numberOfNodes; ++i)
	{
		if (i != node)
		{
			if (!findWay(graph, i, node))
			{
				return false;
			}
		}
	}
	return true;
}

bool findWay(Graph *graph, const int firstNode, const int secondNode)
{
	int node = firstNode;
	for (int i = 0; i < graph->numberOfEdges; ++i)
	{
		int nodeToEnter = findNodeToEnter(graph, node);
		if (nodeToEnter == secondNode)
		{
			return true;
		}
		node = nodeToEnter;
	}
	return false;
}

int findNodeToEnter(Graph *graph, const int node)
{
	for (int i = 0; i < graph->numberOfEdges; ++i)
	{
		if (graph->matrix[node][i] == 1)
		{
			for (int j = 0; j < graph->numberOfNodes; ++j)
			{
				if (graph->matrix[j][i] == -1)
				{
					return j;
				}
			}
		}
	}
}

void printReachableNodes(Graph *graph)
{
	for (int i = 0; i < graph->numberOfNodes; ++i)
	{
		if (isReachable(graph, i))
		{
			cout << i + 1 << " ";
		}
	}
}