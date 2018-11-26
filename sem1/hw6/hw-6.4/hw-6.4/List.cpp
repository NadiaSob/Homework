#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>
#include "List.h"

struct Node;

struct List
{
	Node *head = nullptr;
	int length = 0;
};

struct Node
{
	Record record;
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

bool comparison(Record record1, Record record2, bool byName)
{
	if (byName)
	{
		return strcmp(record1.name, record2.name) < 0;
	}
	else
	{
		return record1.number < record2.number;
	}
}

void mergeSort(List *list, bool byName)
{
	if (list->head->next != nullptr)
	{
		int middle = list->length / 2;

		List *list1 = createList();
		Node *current = list->head;
		for (int i = 1; i <= middle; ++i)
		{
			addNode(list1, current->record);
			current = current->next;
		}

		List *list2 = createList();
		for (int i = middle; i < list->length; ++i)
		{
			addNode(list2, current->record);
			current = current->next;
		}

		mergeSort(list1, byName);
		mergeSort(list2, byName);
		mergeLists(list, list1, list2, byName);

		deleteList(list1);
		deleteList(list2);
	}
}

void mergeLists(List *list, List *list1, List *list2, bool byName)
{
	while (!isEmpty(list))
	{
		deleteHead(list);
	}
	List *resList = createList();
	Node *current1 = list1->head;
	Node *current2 = list2->head;

	while (current1 != nullptr && current2 != nullptr)
	{
		if (comparison(current1->record, current2->record, byName))
		{
			addNode(resList, current1->record);
			current1 = current1->next;
		}
		else
		{
			addNode(resList, current2->record);
			current2 = current2->next;
		}
	}

	while (current1 != nullptr)
	{
		addNode(resList, current1->record);
		current1 = current1->next;
	}
	while (current2 != nullptr)
	{
		addNode(resList, current2->record);
		current2 = current2->next;
	}

	Node *current = resList->head;
	while (current != nullptr)
	{
		addNode(list, current->record);
		current = current->next;
	}
	deleteList(resList);
}

bool test()
{
	List *testList = createList();
	
	FILE * file = fopen("test-phonebook.txt", "r");
	while (!feof(file))
	{
		int number = 0;
		char name[50]{};
		const int readBytes = fscanf(file, "%s - %d", name, &number);
		if (readBytes < 0)
		{
			break;
		}
		Record newRecord;
		strcpy(newRecord.name, name);
		newRecord.number = number;
		addNode(testList, newRecord);
	}
	fclose(file);

	mergeSort(testList, 1);

	Node *current = testList->head;
	while (current->next != nullptr)
	{
		if (!comparison(current->record, current->next->record, 1))
		{
			deleteList(testList);
			return false;
		}
		current = current->next;
	}

	mergeSort(testList, 0);
	current = testList->head;
	while (current->next != nullptr)
	{
		if (!comparison(current->record, current->next->record, 0))
		{
			deleteList(testList);
			return false;
		}
		current = current->next;
	}

	deleteList(testList);
	return true;
}