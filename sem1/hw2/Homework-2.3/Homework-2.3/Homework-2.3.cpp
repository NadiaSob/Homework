#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

void bubbleSort(int *array, int size)
{
	for (int j = 0; j < size - 1; ++j)
	{
		for (int l = 0; l < size - 1; ++l)
		{
			if (array[l] > array[l + 1])
			{
				int temp = array[l];
				array[l] = array[l + 1];
				array[l + 1] = temp;
			}
		}
	}
}

void countingSort(int *array, int size)
{
	int maximum = 0;
	for (int i = 0; i < size; ++i)
	{
		if (maximum < array[i])
		{
			maximum = array[i];
		}
	}
	int *tempArray = new int[maximum] {};
	for (int j = 0; j < size; ++j)
	{
		++tempArray[array[j]];
	}
	int temp = 0;
	for (int i = 0; i < maximum; ++i)
	{
		for (int j = 0; j < tempArray[i]; ++j)
		{
			array[temp] = i;
			++temp;
		}
	}
}

bool bubbleTest()
{
	int array1[5] = { 5, 3, 2, 1, 4 };
	int array2[5] = { 0, 0, 1, 0, 1 };
	bubbleSort(array1, 5);
	bubbleSort(array2, 5);
	for (int i = 0; i < 4; ++i)
	{
		if (array1[i] > array1[i + 1] || array2[i] > array2[i + 1])
		{
			return false;
		}
	}
	return true;
}

bool countTest()
{
	int array1[5] = { 5, 3, 2, 1, 4 };
	int array2[5] = { 0, 0, 1, 0, 1 };
	countingSort(array1, 5);
	countingSort(array2, 5);
	for (int i = 0; i < 4; ++i)
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
	if (bubbleTest())
	{
		printf("Tests of bubble sort passed\n");
	}
	else
	{
		printf("Tests of bubble sort failed\n");
		return 0;
	}
	if (countTest())
	{
		printf("Tests of counting sort passed\n");
	}
	else
	{
		printf("Tests of counting sort failed\n");
		return 0;
	}
	int size = 0;
	printf("Enter the size of the array\n");
	scanf("%d", &size);
	if (size <= 0)
	{
		printf("There is nothing to sort\n");
		return 0;
	}
	int *array = new int[size] {};
	int *array2 = new int[size] {};
	printf("Enter the array\n");
	for (int i = 0; i < size; ++i)
	{
		scanf("%d", &array[i]);
		array2[i] = array[i];
	}
	bubbleSort(array, size);
	printf("Bubble sort: ");
	for (int i = 0; i < size; ++i)
	{
		printf("%d ", array[i]);
	}
	countingSort(array2, size);
	printf("\nCounting sort: ");
	for (int i = 0; i < size; ++i)
	{
		printf("%d ", array2[i]);
	}
	delete[] array;
	delete[] array2;
	return 0;
}