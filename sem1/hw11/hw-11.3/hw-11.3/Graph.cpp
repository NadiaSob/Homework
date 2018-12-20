#include "Graph.h"

using namespace std;

Graph *createGraph(const int size)
{
	Graph *newGraph = new Graph;
	newGraph->edges = new int*[size] {};
	for (int i = 0; i < size; ++i)
	{
		newGraph->edges[i] = new int[size] {};
	}
	return newGraph;
}

void add(Graph *graph, const int firstNode, const int secondNode, const int edge)
{
	graph->edges[firstNode][secondNode] = edge;
}

bool exists(Graph *graph, const int node)
{
	for (int i = 0; i < graph->size; ++i)
	{
		if (graph->edges[node][i] != 0)
		{
			return true;
		}
	}
	return false;
}

void printGraph(Graph *graph)
{
	for (int i = 0; i < graph->size; ++i)
	{
		for (int j = 0; j < graph->size; ++j)
		{
			cout << graph->edges[i][j] << " ";
		}
		cout << endl;
	}
}

void deleteGraph(Graph *graph)
{
	for (int i = 0; i < graph->size; ++i)
	{
		delete[] graph->edges[i];
	}
	delete[] graph->edges;
	delete graph;
}