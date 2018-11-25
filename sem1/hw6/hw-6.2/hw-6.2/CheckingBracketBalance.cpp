#include <stdio.h>
#include "Stack.h"
#include "CheckingBracketBalance.h"

char findSuitableOpeningBracket(char bracket)
{
	switch (bracket)
	{
	case ')':
		return '(';
	case ']':
		return '[';
	case '}':
		return '{';
	}
}

bool checkingBracketBalance(char *string)
{
	Stack *stack = createStack();

	for (int i = 0; string[i] != '\0'; ++i)
	{
		if ((string[i] == '(') || (string[i] == '[') || (string[i] == '{'))
		{
			push(stack, string[i]);
		}
		if ((string[i] == ')') || (string[i] == ']') || (string[i] == '}'))
		{
			if (isEmpty(stack))
			{
				deleteStack(stack);
				return false;
			}
			else
			{
				char temp = findSuitableOpeningBracket(string[i]);
				if (temp != pop(stack))
				{
					deleteStack(stack);
					return false;
				}
			}
		}
	}

	bool checkIfEmpty = isEmpty(stack);
	deleteStack(stack);
	return checkIfEmpty;
}

bool test()
{
	char string1[7] = "ab(cd)";
	char string2[7] = "({ab})";
	char string3[7] = "abcdef";
	char string4[7] = "{{ab(c";
	char string5[7] = "[(])ab";
	return checkingBracketBalance(string1) && checkingBracketBalance(string2) && checkingBracketBalance(string3) &&
		!checkingBracketBalance(string4) && !checkingBracketBalance(string5);
}