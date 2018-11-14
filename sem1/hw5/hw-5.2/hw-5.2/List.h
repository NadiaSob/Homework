#pragma once

struct List;

struct Node;

//Creates new list
List *createList();

//Checks if list is empty
bool isEmpty(List *list);

//Checks if there is only one node in the list
bool isOnlyOneLeft(List *list);

//Adds new node in the list
void addNode(List *list, int data);

//Moves current node forward
void moveCurrentNode(List *list);

//Deletes current node
void deleteCurrentNode(List *list);

//Returns data of the current node
int dataOfCurrentNode(List *list);