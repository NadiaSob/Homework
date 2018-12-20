#include "Graph.h"
#include "PrimAlgorithm.h"
#include "Tests.h"

bool test()
{
	int size = 0;
	ifstream file("TestInput.txt");
	file >> size;

	Graph *testGraph = createGraph(size);
	testGraph->size = size;
	for (int i = 0; i < size; ++i)
	{
		for (int j = 0; j < size; ++j)
		{
			int edge = 0;
			file >> edge;
			add(testGraph, i, j, edge);
		}
	}
	Graph *result = primAlgorithm(testGraph);

	for (int i = 0; i < size; ++i)
	{
		for (int j = 0; j < size; ++j)
		{
			int temp = 0;
			file >> temp;
			if (temp != result->edges[i][j])
			{
				deleteGraph(testGraph);
				deleteGraph(result);
				return false;
			}
		}
	}
	deleteGraph(testGraph);
	deleteGraph(result);
	return true;
}