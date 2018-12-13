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

//Adds new node in list
void addNewNode(List *list, std::string string);

//Finds node with given string in the list and increases count if the string is found
//Otherwise, adds the string in the list
bool findString(List *list, std::string string);

//Deletes list
void deleteList(List *list);

//Prints list
void printList(List *list);

//Returns the number of times the word is found in the text
int countOfWord(List *list, std::string word);