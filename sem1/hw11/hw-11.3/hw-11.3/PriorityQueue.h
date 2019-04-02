#pragma once

struct QueueElement;

struct PriorityQueue;

//Creates new priority queue
PriorityQueue *createPriorityQueue();

//Checks if queue is empty
bool isEmpty(PriorityQueue *queue);

//Adds new element in the right place in queue
void enqueue(PriorityQueue *queue, const int node, const int adjacentNode, const int key);

//Returns head and deletes it from the queue
//Head is the minimal element of the queue
int dequeue(PriorityQueue *queue, int &node);

//Deletes queue
void deleteQueue(PriorityQueue *queue);