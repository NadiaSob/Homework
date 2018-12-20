#pragma once

struct Node;

struct Set;

//Creates new set
Set *createSet();

//Creates parse tree of arithmetic expression
void createParseTree(Set *set, char *expression);

//Deletes set
void deleteSet(Set *set);

//Returns set in form of string
char *printSet(Set *set);

//Convert an expression to a suitable form
char *convertString(char *string);

//Calculates the result of an arithmetic expression
int calculation(Set *set);

//Tests set and calculation functions
bool test();