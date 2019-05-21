#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "List.h"

void readFromFile(FILE *file, List *lessThanA, List *inInterval, List *greaterThanB, int a, int b)
{
	while (!feof(file))
	{
		int number = 0;
		const int readBytes = fscanf(file, "%d", &number);
		if (readBytes < 0)
		{
			break;
		}

		if (number < a)
		{
			addNode(lessThanA, number);
		}
		else if (number <= b)
		{
			addNode(inInterval, number);
		}
		else
		{
			addNode(greaterThanB, number);
		}
	}
}

bool test()
{
	FILE * testFile = fopen("TestFile.txt", "r");

	List *list1 = createList();
	List *list2 = createList();
	List *list3 = createList();

	readFromFile(testFile, list1, list2, list3, 20, 50);

	fclose(testFile);
	deleteList(list1);
	deleteList(list2);
	deleteList(list3);
}

int main()
{
	printf("Enter number a\n");
	int a = 0;
	scanf("%d", &a);
	printf("Enter number b\n");
	int b = 0;
	scanf("%d", &b);

	List *lessThanA = createList();
	List *inInterval = createList();
	List *greaterThanB = createList();

	FILE * file = fopen("f.txt", "r");
	readFromFile(file, lessThanA, inInterval, greaterThanB, a, b);
	fclose(file);

	printInOriginalOrder(lessThanA);
	printInOriginalOrder(inInterval);
	printInOriginalOrder(greaterThanB);

	deleteList(lessThanA);
	deleteList(inInterval);
	deleteList(greaterThanB);
	return 0;
}