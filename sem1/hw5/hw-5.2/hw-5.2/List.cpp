#include <stdio.h>
#include "List.h"

struct Node;

struct List
{
	Node *currentNode = nullptr;
	Node *lastNode = nullptr;
};

struct Node
{
	int data = 0;
	Node *next = nullptr;
};

List *createList()
{
	return new List;
}

bool isEmpty(List *list)
{
	return list->currentNode == nullptr;
}

bool isOnlyOneLeft(List *list)
{
	return list->currentNode == list->lastNode;
}

void addNode(List *list, int data)
{
	auto newNode = new Node{ data, nullptr };
	if (isEmpty(list))
	{
		list->currentNode = newNode;
		list->lastNode = newNode;
		newNode->next = newNode;
		return;
	}
	if (isOnlyOneLeft(list))
	{
		list->currentNode->next = newNode;
		list->lastNode = newNode;
		newNode->next = list->currentNode;
		return;
	}
	newNode->next = list->currentNode;
	list->lastNode->next = newNode;
	list->lastNode = newNode;
}

void moveCurrentNode(List *list)
{
	list->lastNode = list->currentNode;
	list->currentNode = list->currentNode->next;
}

void deleteCurrentNode(List *list)
{
	if (isOnlyOneLeft(list))
	{
		delete list->currentNode;
		list->currentNode = nullptr;
		list->lastNode = nullptr;
		return;
	}
	Node *temp = list->currentNode;
	list->lastNode->next = list->currentNode->next;
	list->currentNode = list->currentNode->next;
	delete temp;
}

int dataOfCurrentNode(List *list)
{
	return list->currentNode->data;
}