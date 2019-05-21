#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "List.h"

struct Node
{
	int data = 0;
	Node *next = nullptr;
};

struct List
{
	Node *head = nullptr;
	int length = 0;
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
	auto newNode = new Node{ data, nullptr };
	if (isEmpty(list))
	{
		list->head = newNode;
	}
	else
	{
		newNode->next = list->head;
		list->head = newNode;
	}
	++list->length;
}

void deleteHead(List *list)
{
	Node *nodeToDelete = list->head;
	list->head = nodeToDelete->next;
	delete nodeToDelete;
	--list->length;
}

void deleteList(List *list)
{
	while (!isEmpty(list))
	{
		deleteHead(list);
	}
	delete list;
}

void printInOriginalOrder(List *list)
{
	const int length = list->length;
	int *array = new int[length]{};
	Node *nodeToPrint = list->head;
	
	for (int i = length - 1; i >= 0; --i)
	{
		array[i] = nodeToPrint->data;
		nodeToPrint = nodeToPrint->next;
	}

	FILE * file = fopen("g.txt", "a");
	for (int j = 0; j < length; ++j)
	{
		fprintf(file, "%d ", array[j]);
	}

	delete[] array;
	fclose(file);
}