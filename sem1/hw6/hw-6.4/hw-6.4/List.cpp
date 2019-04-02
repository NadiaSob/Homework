#include "List.h"
#include <stdio.h>

List *createList()
{
	return new List;
}

bool isEmpty(List *list)
{
	return list->head == nullptr;
}

void addNode(List *list, Record newRecord)
{
	auto newNode = new Node{ newRecord, nullptr };

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
		printf("%s - %d\n", nodeToPrint->record.name, nodeToPrint->record.number);
		nodeToPrint = nodeToPrint->next;
	}
}