#include <string>
#include <fstream>
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

bool exists(List *list, string str)
{
	Node *current = list->head;
	while (current != nullptr)
	{
		if (current->str == str)
		{
			return true;
		}
		current = current->next;
	}
	return false;
}

void addNode(List *list, string const &str)
{
	if (exists(list, str))
	{
		return;
	}
	auto newNode = new Node{ str, nullptr };

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

void putListInFile(List *list)
{
	ofstream file("File.txt");
	Node *current = list->head;
	while (current != nullptr)
	{
		file << current->str << endl;
		current = current->next;
	}
	file.close();
}
