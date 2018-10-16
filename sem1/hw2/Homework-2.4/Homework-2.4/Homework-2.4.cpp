#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>

void conversion(int *array, int size)
{
	int pivot = array[0];
	int first = 0, last = size - 1;
	while (first <= last)
	{
		while (array[first] < pivot)
		{
			++first;
		}
		while (array[last] > pivot)
		{
			--last;
		}
		if (first <= last)
		{
			int temp = array[first];
			array[first] = array[last];
			array[last] = temp;
		}
		++first;
		--last;
	}
}

bool testForArray(int array[], int size)
{
	int temp = 0;
	while (array[temp] < array[0])
	{
		++temp;
	}
	for (int i = temp + 1; i < size; ++i)
	{
		if (array[i] < temp)
		{
			return false;
		}
	}
	return true;
}

bool test()
{
	int array1[5] = { 10, 5, 3, 19, 4 };
	int array2[5] = { 1, 0, 0, 1, 0 };
	int array3[5] = { 5, 4, 3, 2, 1 };
	return testForArray(array1, 5) && testForArray(array2, 5) && testForArray(array3, 5);
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
	int size = 0;
	printf("Enter the size of the array\n");
	scanf("%d", &size);
	int *array = new int[size] {};
	printf("The array is ");
	for (int i = 0; i < size; ++i)
	{
		array[i] = rand();
		printf("%d ", array[i]);
	}
	conversion(array, size);
	printf("\nThe converted array is ");
	for (int i = 0; i < size; ++i)
	{
		printf("%d ", array[i]);
	}
	delete[]array;
	return 0;
}