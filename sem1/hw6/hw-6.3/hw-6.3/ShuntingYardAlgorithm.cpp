#include <stdio.h>
#include <string.h>
#include "ShuntingYardAlgorithm.h"
#include "Stack.h"

bool isDigit(char symbol)
{
	return (symbol <= '9') && (symbol >= '0');
}

bool isOperator(char symbol)
{
	return (symbol == '+') || (symbol == '-') || (symbol == '*') || (symbol == '/');
}

bool ifHasPriority(char symbol)
{
	return (symbol == '*') || (symbol == '/');
}

char *shuntingYardAlgorithm(char *infix)
{
	Stack *stack = createStack();
	char *postfix = new char[100]{};
	int temp = 0;
	for (int i = 0; infix[i] != '\0'; ++i)
	{
		if (infix[i] != ' ')
		{
			if (isDigit(infix[i]))
			{
				postfix[temp] = infix[i];
				++temp;
			}
			else if (isOperator(infix[i]))
			{
				if (!isEmpty(stack) && ifHasPriority(returnHead(stack)))
				{
					postfix[temp] = pop(stack);
					++temp;
				}
				push(stack, infix[i]);
			}
			else if (infix[i] == '(')
			{
				push(stack, infix[i]);
			}
			else if (infix[i] == ')')
			{
				while (returnHead(stack) != '(')
				{
					postfix[temp] = pop(stack);
					++temp;
				}
				pop(stack);
			}
		}
	}
	while (!isEmpty(stack))
	{
		postfix[temp] = pop(stack);
		++temp;
	}
	deleteStack(stack);
	return postfix;
}

bool test()
{
	char expression1[12] = "(1 + 1) * 2";
	char expression2[18] = "(9 - 6) * (1 + 2)";
	char expression3[18] = "(8 - (2 + 1)) * 3";
	
	char *result1 = shuntingYardAlgorithm(expression1);
	char *result2 = shuntingYardAlgorithm(expression2);
	char *result3 = shuntingYardAlgorithm(expression3);

	bool check = true;
	if ((strcmp(result1, "11+2*") == 0) && (strcmp(result2, "96-12+*") == 0) && (strcmp(result3, "821+-3*") == 0))
	{
		printf("Tests passed\n");
	}
	else
	{
		printf("Tests failed\n");
		check = false;
	}
	delete[] result1;
	delete[] result2;
	delete[] result3;
	return check;
}