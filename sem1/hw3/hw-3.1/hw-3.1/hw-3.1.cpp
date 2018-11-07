#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

void insertSort(int *array, int first, int last)
{
	for (int i = first; i < last; ++i)
	{
		int temp = array[i];
		int j = i;
		while (j > first && temp < array[j - 1])
		{
			array[j] = array[j - 1];
			--j;
		}
		array[j] = temp;
	}
}

void quickSort(int *array, int first, int last)
{
	if (last - first + 1 < 10)
	{
		insertSort(array, first, last + 1);
		return;
	}
	int left = first;
	int right = last;
	int pivot = array[first];
	while (left <= right)
	{
		while (array[left] < pivot)
		{
			++left;
		}
		while (array[right] > pivot)
		{
			--right;
		}
		if (left <= right)
		{
			int const temp = array[left];
			array[left] = array[right];
			array[right] = temp;
			++left;
			--right;
		}
	}
	if (first < right)
	{
		quickSort(array, first, right);
	}
	if (last > left)
	{
		quickSort(array, left, last);
	}
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

bool insertTest()
{
	int array1[15] = { 1, 5, 15, 1, 7, 6, 9, 10, 15, 8, 4, 3, 13, 12, 11 };
	int array2[15] = { 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 3, 2, 1, 1, 1 };
	insertSort(array1, 0, 15);
	insertSort(array2, 0, 15);
	for (int i = 0; i < 14; ++i)
	{
		if (array1[i] > array1[i + 1] || array2[i] > array2[i + 1])
		{
			return false;
		}
	}
	return true;
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
	if (insertTest())
	{
		printf("Tests of Insertion Sort passed\n");
	}
	else
	{
		printf("Tests of Insertion Sort failed\n");
		return 0;
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
	quickSort(array, 0, size - 1);
	for (int j = 0; j < size; ++j)
	{
		printf("%d ", array[j]);
	}
	delete[] array;
	return 0;
}