#pragma once

struct Node;

struct Set;

//Creates new set
Set *createSet();

//Checks if set is empty
bool isEmpty(Set *set);

//Adds new node in set
bool add(Set *set, const int data);

//Deletes node with given data
bool deleteNode(Set *set, const int data);

//Checkes if node with given data exists
bool exists(Set *set, const int data);

//Deletes set
void deleteSet(Set *set);

//Adds set elements in array
void printSet(Set *set, int *array, bool InAscendingOrder);

//Tests set functions
bool test();