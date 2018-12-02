#pragma once

struct Node;

struct Set;

//Creates new set
Set *createSet();

//Creates parse tree of arithmetic expression
void createParseTree(Set *set, char *expression);

//Adds new node in set
void addNode(Set *set, Node *&current, char *expression, int &index);

//Deletes set
void deleteSet(Set *set);

//Used in function deleteSet
void deleteSetRecursion(Node *nodeToDelete);

//Returns set in form of string
char *printSet(Set *set);

//Used in printSet
void printNode(Set *set, Node *nodeToPrint, char *string, int &index);

//Convert an expression to a suitable form
char *convertString(char *string);

//Calculates the result of an arithmetic expression
int calculation(Set *set);

//Used in calculation
int recursiveCalculation(Set *set, Node *current);

//Tests set and calculation functions
bool test();