#pragma once

struct Node;

struct Set;

//Creates new set
Set *createSet();

//Checks if set is empty
bool isEmpty(Set *set);

//Adds new node in set
bool add(Set *set, const int data);

//Used in function add
void addNode(Node *node, const int data);

//Deletes node with given data
bool deleteNode(Set *set, const int data);

//Used in function deleteNode
void deleteNodeRecursion(Node *&current, const int data);

//Finds maximum of the left subtree
int maximum(Node *current);

//Checkes if node with given data exists
bool exists(Set *set, const int data);

//Deletes set
void deleteSet(Set *set);

//Used in function deleteSet
void deleteSetRecursion(Node *nodeToDelete);

//Adds set elements in array
void printSet(Set *set, int *array, bool InAscendingOrder);

//Adds set elements in array in ascending order
void printInAscendingOrder(Node *nodeToPrint, int *array, int &count);

//Adds set elements in array in descending order
void printInDescendingOrder(Node *nodeToPrint, int *array, int &count);

//Tests set functions
bool test();