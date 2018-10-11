#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int recursiveFibonacci(int value)
{
	if (value == 0 || value == 1)
	{
		return value;
	}
	else
	{
		return recursiveFibonacci(value - 1) + recursiveFibonacci(value - 2);
	}
}

void iterativeFibonacci(int value)
{
	if (value < 2)
	{
		printf("%d", 0);
	}
	else
	{
		int firstNum = 0;
		int secondNum = 1;
		int thirdNum = 1;
		printf("%d %d ", firstNum, secondNum);
		for (int i = 2; i < value; ++i)
		{
			printf("%d ", thirdNum);
			firstNum = secondNum;
			secondNum = thirdNum;
			thirdNum = firstNum + secondNum;
		}
	}
}

bool test()
{
	return (recursiveFibonacci(1) == 1) && (recursiveFibonacci(6) == 8);
}

int main()
{
	if (test())
	{
		printf("Tests passed\n");
	}
	else
	{
		printf("Tests failed\n");
		
	}
	int numberOfFibo = 0;
	printf("Enter the number of Fibonacci series element\n");
	scanf("%d", &numberOfFibo);
	if (numberOfFibo <= 0)
	{
		printf("You entered a non-positive number");
		return 0;
	}
	printf("Calculated recursively: ");
	for (int i = 0; i < numberOfFibo; ++i)
	{
		printf("%d ", recursiveFibonacci(i));
	}
	printf("\nCalculeted iteratively: ");
	iterativeFibonacci(numberOfFibo);
	return 0;
}