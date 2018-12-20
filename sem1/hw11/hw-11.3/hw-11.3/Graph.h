#pragma once
#include <vector>
#include <iostream>

using namespace std;

struct Graph
{
	int **edges;
	int size = 0;
};

//Creates new graph
Graph *createGraph(const int size);

//Adds edge between two nodes in graph
void add(Graph *graph, const int firstNode, const int secondNode, const int edge);

//Checks if node is connected with any other node in graph
bool exists(Graph *graph, const int node);

//Prints graph
void printGraph(Graph *graph);

//Deletes graph
void deleteGraph(Graph *graph);