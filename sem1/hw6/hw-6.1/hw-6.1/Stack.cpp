#include <stdio.h>
#include "Stack.h"

struct StackElement;

struct Stack
{
	StackElement *head = nullptr;
};

struct StackElement
{
	int data = 0;
	StackElement *next = nullptr;
};

Stack *createStack()
{
	return new Stack;
}

void push(Stack *stack, int data)
{
	auto newElement = new StackElement{ data, stack->head };
	stack->head = newElement;
}

int pop(Stack *stack)
{
	if (stack->head == nullptr)
	{
		return -1;
	}
	StackElement *temp = stack->head;
	stack->head = stack->head->next;
	const int value = temp->data;
	delete temp;
	return value;
}

bool isEmpty(Stack *stack)
{
	return stack->head == nullptr;
}

void deleteStack(Stack *stack)
{
	while (!isEmpty(stack))
	{
		StackElement *temp = stack->head;
		stack->head = temp->next;
		delete temp;
	}
	delete stack;
}