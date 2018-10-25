#define _CRT_SECURE_NO_WARNINGS
#include "MyFunctions.h"
#include <stdio.h>

int theMostCommonElement(int *array, int size)
{
	quickSort(array, 0, size - 1);
	int maxAmount = 1;
	int element = array[0];
	for (int i = 0; i < size - 1; ++i)
	{
		int amount = 1;
		int temp = i;
		while (array[temp] == array[temp + 1])
		{
			++amount;
			++temp;
		}
		if (maxAmount < amount)
		{
			maxAmount = amount;
			element = array[i];
		}
	}
	return element;
}

bool quickTest()
{
	int array1[15] = { 1, 5, 15, 1, 7, 6, 9, 10, 15, 8, 4, 3, 13, 12, 11 };
	int array2[15] = { 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 3, 2, 1, 1, 1 };
	quickSort(array1, 0, 14);
	quickSort(array2, 0, 14);
	for (int i = 0; i < 14; ++i)
	{
		if (array1[i] > array1[i + 1] || array2[i] > array2[i + 1])
		{
			return false;
		}
	}
	return true;
}

bool test()
{
	int array1[5] = { 2, 1, 4, 1, 3 };
	int array2[5] = { 1, 0, 0, 1, 0 };
	return (theMostCommonElement(array1, 5) == 1) && (theMostCommonElement(array2, 5) == 0);
}

int main()
{
	if (quickTest())
	{
		printf("Tests of Quick Sort passed\n");
	}
	else
	{
		printf("Tests of Quick Sort failed\n");
		return 0;
	}
	if (test())
	{
		printf("Tests of finding the most common element passed\n");
	}
	else
	{
		printf("Tests of finding the most common element failed\n");
		return 0;
	}
	FILE * file = fopen("file.txt", "r");
	if (!file)
	{
		printf("File is not found");
		return 0;
	}
	int size;
	fscanf(file, "%d", &size);
	printf("The size of the array is recieved\n");
	int *array = new int[size] {};
	for (int i = 0; i < size; ++i)
	{
		fscanf(file, "%d", &array[i]);
	}
	printf("The array is recieved\n");
	printf("The most common element in array is %d\n", theMostCommonElement(array, size));
	delete[]array;
	fclose(file);
	return 0;
}