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

int iterativeFibonacci(int value)
{
	if (value == 0 || value == 1)
	{
		return value;
	}
	else
	{
		int firstNum = 0;
		int secondNum = 1;
		int thirdNum = 1;
		for (int i = 2; i < value; ++i)
		{
			firstNum = secondNum;
			secondNum = thirdNum;
			thirdNum = firstNum + secondNum;
		}
		return thirdNum;
	}
}

bool recursTest()
{
	return (recursiveFibonacci(1) == 1) && (recursiveFibonacci(6) == 8) && (recursiveFibonacci(0) == 0);
}

bool iterTest()
{
	return (iterativeFibonacci(1) == 1) && (iterativeFibonacci(6) == 8) && (iterativeFibonacci(0) == 0);
}

int main()
{
	if (recursTest())
	{
		printf("Tests of the recursive function passed\n");
	}
	else
	{
		printf("Tests of the recursive function failed\n");
		return 0;
	}
	if (iterTest())
	{
		printf("Tests of the iterative function passed\n");
	}
	else
	{
		printf("Tests of the iterative function failed\n");
		return 0;
	}
	int numberOfFibo = 0;
	printf("Enter the number of Fibonacci series element\n");
	scanf("%d", &numberOfFibo);
	if (numberOfFibo <= 0)
	{
		printf("You entered a non-positive number");
		return 0;
	}
	printf("Calculated recursively: %d\n", recursiveFibonacci(numberOfFibo));
	printf("Calculeted iteratively: %d", iterativeFibonacci(numberOfFibo));
	return 0;
}