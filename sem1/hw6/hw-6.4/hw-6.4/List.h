#pragma once

struct Record
{
	char name[50]{};
	int number = 0;
};

struct List;

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

//Compares two records, returns true if first record should go before the second one
bool comparison(Record record1, Record record2, bool byName);

//Sorts list
void mergeSort(List *list, bool byName);

//Merges two sorted lists into one
void mergeLists(List *list, List *list1, List *list2, bool byName);

//Tests mergeSort function
bool test();