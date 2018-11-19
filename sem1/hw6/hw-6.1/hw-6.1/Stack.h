#pragma once

struct Stack;

//Creates new stack
Stack *createStack();

//Adds new element in the stack
void push(Stack *stack, int data);

//Deletes head of the stack
int pop(Stack *stack);

//Checkes if stack is empty
bool isEmpty(Stack *stack);

//Deletes the stack
void deleteStack(Stack *stack);