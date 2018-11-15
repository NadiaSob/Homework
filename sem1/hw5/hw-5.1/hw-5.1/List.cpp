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
	for (int i = 0; i < list->length; ++i)
	{
		Node *nodeToDelete = list->head;
		list->head = nodeToDelete->next;
		delete nodeToDelete;
	}
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

bool test()
{
	List *testList = createList();
	addNode(testList, 4);
	addNode(testList, -5);
	addNode(testList, 8);
	addNode(testList, 0);
	addNode(testList, 1);
	deleteNode(testList, 4);
	Node *nodeForTest = testList->head;
	Node *nodeForTestNext = nodeForTest->next;
	for (int i = 0; i < testList->length - 1; ++i)
	{
		if (nodeForTest->data > nodeForTestNext->data || nodeForTest->data == 4)
		{
			deleteList(testList);
			return false;
		}
		nodeForTest = nodeForTest->next;
		nodeForTestNext = nodeForTestNext->next;
	}
	deleteList(testList);
	return true;
}