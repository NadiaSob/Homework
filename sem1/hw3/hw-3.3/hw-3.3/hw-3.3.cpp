#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int choiceOfPivot(int *array, int first, int last)
{
	const int mid = (first + last) / 2;
	if ((array[first] <= array[last] && array[first] >= array[mid]) || (array[first] >= array[last] && array[first] <= array[mid]))
	{
		return array[first];
	}
	if ((array[last] <= array[first] && array[last] >= array[mid]) || (array[last] >= array[first] && array[last] <= array[mid]))
	{
		return array[last];
	}
	if ((array[mid] <= array[first] && array[mid] >= array[last]) || (array[mid] >= array[first] && array[mid] <= array[last]))
	{
		return array[mid];
	}
}

void quickSort(int *array, int first, int last)
{
	int left = first, right = last;
	int pivot = choiceOfPivot(array, first, last);
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
			if (temp != size - 1)
			{
				++temp;
			}
			else
			{
				break;
			}
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
		return 1;
	}
	if (test())
	{
		printf("Tests of finding the most common element passed\n");
	}
	else
	{
		printf("Tests of finding the most common element failed\n");
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
	printf("The most common element in array is %d\n", theMostCommonElement(array, size));
	delete[] array;
	return 0;
}