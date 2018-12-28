#include <iostream>
#include <fstream>
#include "Graph.h"

using namespace std;

Graph *openFile()
{
	ifstream file("Graph.txt");

	int numberOfNodes = 0;
	int numberOfEdges = 0;

	file >> numberOfNodes;
	file >> numberOfEdges;

	Graph *graph = createGraph(numberOfNodes, numberOfEdges);
	for (int i = 0; i < numberOfNodes; ++i)
	{
		for (int j = 0; j < numberOfEdges; ++j)
		{
			int value = 0;
			file >> value;
			add(graph, i, j, value);
		}
	}
	return graph;
}

int main()
{
	Graph *graph = openFile();

	cout << "Graph:" << endl;
	printGraph(graph);

	cout << "Reachable nodes: ";
	printReachableNodes(graph);

	deleteGraph(graph);
	return 0;
}