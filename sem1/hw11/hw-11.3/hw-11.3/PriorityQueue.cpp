#include "PriorityQueue.h"

using namespace std;

struct QueueElement
{
	int key = 0;
	int node = 0;
	int	adjacentNode = 0;
	QueueElement *next;
};

struct PriorityQueue
{
	QueueElement *head = nullptr;
};

PriorityQueue *createPriorityQueue()
{
	return new PriorityQueue;
}

bool isEmpty(PriorityQueue *queue)
{
	return queue->head == nullptr;
}

void enqueue(PriorityQueue *queue, const int node, const int adjacentNode, const int key)
{
	QueueElement *newElement = new QueueElement{ key, node, adjacentNode, nullptr };
	if (isEmpty(queue))
	{
		queue->head = newElement;
		return;
	}

	if (queue->head->key >= newElement->key)
	{
		newElement->next = queue->head;
		queue->head = newElement;
		return;
	}

	QueueElement *previous = queue->head;
	QueueElement *current = queue->head->next;
	while (current != nullptr && current->key < newElement->key)
	{
		previous = current;
		current = current->next;
	}
	newElement->next = current;
	previous->next = newElement;
}

int dequeue(PriorityQueue *queue, int &node)
{
	QueueElement *temp = queue->head;
	queue->head = queue->head->next;
	int adjacentNode = temp->adjacentNode;
	node = temp->node;
	delete temp;
	return adjacentNode;
}

void deleteQueue(PriorityQueue *queue)
{
	while (!isEmpty(queue))
	{
		QueueElement *temp = queue->head;
		queue->head = queue->head->next;
		delete temp;
	}
	delete queue;
}