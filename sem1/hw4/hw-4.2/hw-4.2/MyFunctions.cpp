#include "MyFunctions.h"
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