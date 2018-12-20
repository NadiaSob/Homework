#include <iostream>
#include <fstream>
#include "Graph.h"
#include "PrimAlgorithm.h"
#include "Tests.h"

using namespace std;

Graph *openFile()
{
	int size = 0;
	ifstream file("Input.txt");
	file >> size;

	Graph *graph = createGraph(size);
	graph->size = size;
	for (int i = 0; i < size; ++i)
	{
		for (int j = 0; j < size; ++j)
		{
			int edge = 0;
			file >> edge;
			add(graph, i, j, edge);
		}
	}
	return graph;
}

int main()
{
	if (test())
	{
		cout << "Tests passed successfully" << endl;
	}
	else
	{
		cout << "Tests failed!" << endl;
		return 1;
	}

	Graph *graph = openFile();
	Graph *minSpanningTree = primAlgorithm(graph);

	cout << "Graph: " << endl;
	printGraph(graph);

	cout << "Minimum spanning tree: " << endl;
	printGraph(minSpanningTree);

	deleteGraph(graph);
	deleteGraph(minSpanningTree);
	return 0;
}