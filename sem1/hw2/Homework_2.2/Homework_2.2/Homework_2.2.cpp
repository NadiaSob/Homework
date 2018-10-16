#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <math.h>

int linPol(int number, int exponent)
{
	if (exponent == 0)
	{
		return 1;
	}
	if (exponent < 0)
	{
		return 0;
	}
	int result = number;
	for (int i = 1; i < abs(exponent); ++i)
	{
		result *= number;
	}
	return result;
}

int binPol(int number, int exponent)
{
	if (exponent == 0)
	{
		return 1;
	}
	if (exponent < 0)
	{
		return 0;
	}
	if (exponent % 2 == 1)
	{
		return binPol(number, exponent - 1) * number;
	}
	else
	{
		const int tempNumber = binPol(number, exponent / 2);
		return tempNumber * tempNumber;
	}
}

bool testLinPol()
{
	return (linPol(2, 10) == 1024) && (linPol(5, 0) == 1) && (linPol(-2, 3) == -8) && (linPol(3, -2) == 0);
}

bool testBinPol()
{
	return (binPol(2, 10) == 1024) && (binPol(5, 0) == 1) && (binPol(-2, 3) == -8) && (binPol(3, -2) == 0);
}

int main()
{
	if (testLinPol())
	{
		printf("test of linPol passed\n");
	}
	else
	{
		printf("test of linPol failed\n");
		return 0;
	}
	if (testBinPol())
	{
		printf("test of binPol passed\n");
	}
	else
	{
		printf("test of binPol failed\n");
		return 0;
	}
	int number = 0;
	printf("Enter the number\n");
	scanf("%d", &number);
	int exponent = 0;
	printf("Enter the exponent of the number\n");
	scanf("%d", &exponent);
	int result1 = linPol(number, exponent);
	printf("Using linPol: %d to the power of %d is %d\n", number, exponent, result1);
	int result2 = binPol(number, exponent);
	printf("Using binPol: %d to the power of %d is %d\n", number, exponent, result1);
	return 0;
}