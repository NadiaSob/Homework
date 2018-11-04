#include <stdio.h>
#include "List.h"

struct Node;

struct List
{
	Node *tail = nullptr;
	int length = 0;
};

struct Node
{
	int data = 0;
	int position = 0;
	Node *next = nullptr;
};

List *createList()
{
	return new List;
}

bool isEmpty(List *list)
{
	return list->tail == nullptr;
}

void addNode(List *list, int data)
{
	auto newNode = new Node{ data, list->length + 1, nullptr };
	if (isEmpty(list))
	{
		list->tail = newNode;
		return;
	}
	Node *nextNode = list->tail;
	Node *prevNode = nullptr;
	while (nextNode != nullptr && newNode->data > nextNode->data)
	{
		++nextNode->position;
		--newNode->position;
		prevNode = nextNode;
		nextNode = prevNode->next;
	}
	if (nextNode != list->tail)
	{
		newNode->next = nextNode;
		prevNode->next = newNode;
	}
	else
	{
		newNode->next = list->tail;
		list->tail = newNode;
	}
	--list->length;
}

void deleteNode(List *list, int data)
{
	Node *nodeToDelete = list->tail;
	Node *prevNode = nullptr;
	while (nodeToDelete->data != data && nodeToDelete->next != nullptr)
	{
		prevNode = nodeToDelete;
		nodeToDelete = nodeToDelete->next;
	}
	if (nodeToDelete->next == nullptr && nodeToDelete->data != data)
	{
		printf("Value is not found\n");
		return;
	}
	if (nodeToDelete != list->tail)
	{
		prevNode->next = nodeToDelete->next;
	}
	else
	{
		list->tail = nodeToDelete->next;
	}
	delete nodeToDelete;
	--list->length;
	return;
}

void printList(List *list)
{
	if (isEmpty(list))
	{
		printf("The list is empty\n");
		return;
	}
	Node *nodeToPrint = list->tail;
	Node *prevNode = list->tail;
	if (nodeToPrint->next == nullptr)
	{
		printf("%d \n", nodeToPrint->data);
		return;
	}
	while (prevNode->next != nullptr)
	{
		printf("%d ", nodeToPrint->data);
		prevNode = nodeToPrint;
		nodeToPrint = nodeToPrint->next;
	}
	printf("\n");
}

bool test()
{
	List *list = createList();
	addNode(list, 4);
	addNode(list, -5);
	addNode(list, 8);
	addNode(list, 0);
	addNode(list, 1);
	deleteNode(list, 4);
	Node *nodeForTest = list->tail;
	for (int i = 0; i < list->length; ++i)
	{
		if (nodeForTest > nodeForTest->next || nodeForTest->data == 4)
		{
			return false;
		}
		nodeForTest = nodeForTest->next;
	}
	return true;
}