#pragma once
#include <string>

struct Node
{
	std::string word = "";
	int count = 0;
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
void addNewNode(List *list, std::string string);

//Finds node with given string in the list and increases count if string is found
//Otherwise, adds the string in the list
void findString(List *list, std::string string);

//Deletes head of the list
void deleteHead(List *list);

//Deletes list
void deleteList(List *list);

//Prints list
void printList(List *list);