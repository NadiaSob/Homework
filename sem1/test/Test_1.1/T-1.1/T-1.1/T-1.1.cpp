#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int sumOfDigits(int number)
{
	int sumOfDigits = 0;
	while (number != 0)
	{
		int digit = number % 10;
		sumOfDigits += digit;
		number /= 10;
	}
	return sumOfDigits;
}

bool test()
{
	int number1 = 123, number2 = 1000, number3 = 567;
	return (sumOfDigits(number1) == 6) && (sumOfDigits(number2) == 1) && (sumOfDigits(number3) == 18);
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
		return 1;
	}
	int size = 0;
	printf("Enter the size of the array\n");
	scanf("%d", &size);
	int *array = new int[size] {};
	printf("Enter the array\n");
	for (int i = 0; i < size; ++i)
	{
		scanf("%d", &array[i]);
	}
	int maxSum = 0;
	for (int j = 0; j < size; ++j)
	{
		if (sumOfDigits(array[j]) > maxSum)
		{
			maxSum = sumOfDigits(array[j]);
		}
	}
	for (int i = 0; i < size; ++i)
	{
		if (sumOfDigits(array[i]) == maxSum)
		{
			printf("%d ", array[i]);
		}
	}
	delete[]array;
	return 0;
}