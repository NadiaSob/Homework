#include <string>
#include <iostream>
#include "List.h"

using namespace std;

List *createList()
{
	return new List;
}

bool isEmpty(List *list)
{
	return list->head == nullptr;
}

void addNewNode(List *list, string string)
{
	Node *newNode = new Node{ string, 1, nullptr };
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

bool findString(List *list, string string)
{
	Node *current = list->head;
	while (current != nullptr)
	{
		if (current->word == string)
		{
			++current->count;
			return true;
		}
		current = current->next;
	}
	addNewNode(list, string);
	return false;
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
	Node *nodeToPrint = list->head;
	while (nodeToPrint != nullptr)
	{
		cout << nodeToPrint->word << " - " << nodeToPrint->count << endl;
		nodeToPrint = nodeToPrint->next;
	}
}

int countOfWord(List *list, string word)
{
	Node *current = list->head;
	while (current != nullptr)
	{
		if (current->word == word)
		{
			return current->count;
		}
		current = current->next;
	}
}