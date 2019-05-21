#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <ctime>

void quickSort(int *array, int first, int last)
{
	int left = first;
	int right = last;
	const int pivot = array[first];
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
			int temp = array[left];
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

bool binarySearch(int *array, int key, int left, int right)
{
	if (left >= right)
	{
		return array[left] == key;
	}
	const int mid = (right + left) / 2;
	if (key == array[mid])
	{
		return true;
	}
	else
	{
		if (key < array[mid])
		{
			return binarySearch(array, key, left, mid - 1);
		}
		else
		{
			return binarySearch(array, key, mid + 1, right);
		}
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

bool binTest()
{
	int array[5] = { 1, 2, 3, 4, 5 };
	return binarySearch(array, 2, 0, 4) && !binarySearch(array, 6, 0, 4);
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
		return 1;
	}
	if (binTest())
	{
		printf("Tests of binary search passed\n");
	}
	else
	{
		printf("Tests of binary search failed\n");
		return 1;
	}
	srand(time(nullptr));
	int n = 0;
	printf("Enter n\n");
	scanf("%d", &n);
	int *array = new int[n] {};
	for (int i = 0; i < n; ++i)
	{
		array[i] = (rand() % 1000 + 1) * (rand() % 1000 + 1) * (rand() % 1000 + 1);
	}
	printf("The array:\n");
	for (int i = 0; i < n; ++i)
	{
		printf("%d ", array[i]);
	}
	quickSort(array, 0, n - 1);
	int k = 0;
	printf("\nEnter k\n");
	scanf("%d", &k);
	printf("Numbers we're looking for in the array:\n");
	bool check = false;
	for (int j = 0; j < k; ++j)
	{
		int temp = (rand() % 1000 + 1) * (rand() % 1000 + 1) * (rand() % 1000 + 1);
		printf("%d", temp);
		if (binarySearch(array, temp, 0, n - 1))
		{
			printf(" - was found in the array\n");
			check = true;
		}
		else
		{
			printf("\n");
		}
	}
	if (!check)
	{
		printf("No numbers were found\n");
	}
	delete[] array;
	return 0;
}