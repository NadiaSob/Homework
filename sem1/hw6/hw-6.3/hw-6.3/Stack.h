#pragma once

struct Stack;

//Creates new stack
Stack *createStack();

//Adds new element in the stack
void push(Stack *stack, char data);

//Returns data of the head
int returnHead(Stack *stack);

//Deletes head of the stack
char pop(Stack *stack);

//Checkes if stack is empty
bool isEmpty(Stack *stack);

//Deletes the stack
void deleteStack(Stack *stack);