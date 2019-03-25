#pragma once

struct List;

//Creates new list
List *createList();

//Checks if the list is empty
bool isEmpty(List *list);

//Adds the node with the given value
void addNode(List *list, int data);

//Deletes the node with the given value
void deleteNode(List *list, int data);

//Deletes the list
void deleteList(List *list);

//Prints the list
void printList(List *list);