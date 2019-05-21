#pragma once

struct Node
{
	std::string str = "";
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
void addNode(List *list, std::string const &str);

//Deletes head of the list
void deleteHead(List *list);

//Deletes list
void deleteList(List *list);

//Puts list in the file
void putListInFile(List *list);