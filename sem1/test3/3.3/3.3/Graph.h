#pragma once

struct Graph;

//Creates new graph
Graph *createGraph(const int numberOfNodes, const int numberOfEdges);

//Adds new element in matrix
void add(Graph *graph, const int node, const int edge, const int value);

//Prints graph
void printGraph(Graph *graph);

//Deletes graph
void deleteGraph(Graph *graph);

//Prints all the nodes that are reachable by every other node in graph
void printReachableNodes(Graph *graph);