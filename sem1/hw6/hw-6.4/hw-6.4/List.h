#pragma once

struct Record
{
	char name[50]{};
	int number = 0;
};

struct Node
{
	Record record;
	Node *next = nullptr;
};

struct List
{
	Node *head = nullptr;
	int length = 0;
};

//Creates new list
List *createList();

//Checks if list is empty
bool isEmpty(List *list);

//Adds new node in list
void addNode(List *list, Record newRecord);

//Deletes head of the list
void deleteHead(List *list);

//Deletes list
void deleteList(List *list);

//Prints list
void printList(List *list);