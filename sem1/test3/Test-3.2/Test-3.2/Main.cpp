#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

bool isMinInColumn(int **array, int length,  int i, int j) //i and j are indexes of the element in the array
{
	int element = array[i][j];
	for (i = 0; i < length; ++i)
	{
		if (array[i][j] < element)
		{
			return false;
		}
	}
	return true;
}

bool isMaxInLine(int **array, int width, int i, int j)
{
	int element = array[i][j];
	for (j = 0; j < width; ++j)
	{
		if (array[i][j] > element)
		{
			return false;
		}
	}
	return true;
}

bool isSaddlePoint(int **array, int length, int width, int i, int j)
{
	return isMaxInLine(array, width, i, j) && isMinInColumn(array, length, i, j);
}

int main()
{
	int length = 0;
	int width = 0;
	
	printf("Enter the length of the array\n");
	scanf("%d", &length);

	printf("Enter the width of the array\n");
	scanf("%d", &width);

	int **array = new int*[length];
	for (int i = 0; i < length; ++i)
	{
		array[i] = new int[width];

	}

	printf("Enter the array\n");

	for (int i = 0; i < length; ++i)
	{
		for (int j = 0; j < width; ++j)
		{
			scanf("%d", &array[i][j]);
		}
	}

	bool ifSaddleIsFound = false;
	for (int i = 0; i < length; ++i)
	{
		for (int j = 0; j < width; ++j)
		{
			if (isSaddlePoint(array, length, width, i, j))
			{
				printf("%d", array[i][j]);
				ifSaddleIsFound = true;
			}
		}
	}
	if (!ifSaddleIsFound)
	{
		printf("No saddle points are found\n");
	}

	for (int i = 0; i < length; ++i)
	{
		delete[] array[i];
	}
	delete[] array;
	return 0;
}