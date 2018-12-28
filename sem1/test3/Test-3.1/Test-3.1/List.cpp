#include <stdio.h>
#include "List.h"

struct Node;

struct List
{
	Node *head = nullptr;
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
	return list->head == nullptr;
}

void addNode(List *list, int data)
{
	auto newNode = new Node{ data, list->length + 1, nullptr };
	if (isEmpty(list))
	{
		list->head = newNode;
		++list->length;
		return;
	}
	Node *nextNode = list->head;
	Node *prevNode = nullptr;
	while (nextNode != nullptr && newNode->data > nextNode->data)
	{
		++nextNode->position;
		--newNode->position;
		prevNode = nextNode;
		nextNode = prevNode->next;
	}
	if (nextNode != list->head)
	{
		newNode->next = nextNode;
		prevNode->next = newNode;
	}
	else
	{
		newNode->next = list->head;
		list->head = newNode;
	}
	++list->length;
}

void deleteNode(List *list, int data)
{
	Node *nodeToDelete = list->head;
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
	if (nodeToDelete != list->head)
	{
		prevNode->next = nodeToDelete->next;
	}
	else
	{
		list->head = nodeToDelete->next;
	}
	delete nodeToDelete;
	--list->length;
}

void deleteList(List *list)
{
	while (!isEmpty(list))
	{
		Node *nodeToDelete = list->head;
		list->head = nodeToDelete->next;
		delete nodeToDelete;
	}
	delete list;
}

void printList(List *list)
{
	if (isEmpty(list))
	{
		printf("The list is empty\n");
		return;
	}
	Node *nodeToPrint = list->head;
	while (nodeToPrint != nullptr)
	{
		printf("%d ", nodeToPrint->data);
		nodeToPrint = nodeToPrint->next;
	}
	printf("\n");
}