#include <stdio.h>
#include "Stack.h"
#include "Calculation.h"

int operation(char sign, int firstNum, int secondNum)
{
	switch (sign)
	{
	case '+':
		return firstNum + secondNum;
	case '-':
		return firstNum - secondNum;
	case '*':
		return firstNum * secondNum;
	case '/':
		if (secondNum != 0)
		{
			return firstNum / secondNum;
		}
		else
		{
			printf("There is a division by 0\n");
			return 1;
		}
	}
}

bool isDigit(char symbol)
{
	return (symbol <= '9') && (symbol >= '0');
}

int charToInt(char digit)
{
	return digit - '0';
}

int calculation(char *expression)
{
	Stack *stack = createStack();

	for (int i = 0; expression[i - 1] != '\0'; i += 2)
	{
		if (isDigit(expression[i]))
		{
			push(stack, charToInt(expression[i]));
		}
		else
		{
			int secondNumber = pop(stack);
			int firstNumber = pop(stack);
			int newNumber = operation(expression[i], firstNumber, secondNumber);
			push(stack, newNumber);
		}
	}
	const int result = pop(stack);
	deleteStack(stack);
	return result;
}

bool test()
{
	if (!isDigit('9') || !isDigit('5') || !isDigit('0'))
	{
		return false;
	}
	if ((charToInt('9') != 9) || (charToInt('5') != 5) || (charToInt('0') != 0))
	{
		return false;
	}
	char expression1[14] = "9 6 - 1 2 + *";
	char expression2[14] = "8 2 + 8 * 5 -";
	char expression3[14] = "4 8 + 9 5 - /";
	return (calculation(expression1) == 9) && (calculation(expression2) == 75) && (calculation(expression3) == 3);
}