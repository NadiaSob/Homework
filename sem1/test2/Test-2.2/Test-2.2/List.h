#pragma once

struct List;

//Creates new list
List *createList();

//Checks if list is empty
bool isEmpty(List *list);

//Adds new node in list
void addNode(List *list, int data);

//Deletes head of the list
void deleteHead(List *list);

//Deletes list
void deleteList(List *list);

//Checks if list has symmetry
bool checkSymmetry(List *list);

//Tests checkSymmetry function
bool test();