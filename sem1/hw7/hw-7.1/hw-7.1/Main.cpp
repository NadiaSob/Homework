#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "Set.h"

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

	Set *tree = createSet();
	printf("Commands:\n");
	printf("0 - exit\n");
	printf("1 - add value in set\n");
	printf("2 - delete value from the set\n");
	printf("3 - check if value is already in the set\n");
	printf("4 - print set elements in ascending order\n");
	printf("5 - print set elements in descending order\n");

	int command = -1;
	int numberOfElements = 0;

	while (command != 0)
	{
		printf("Enter the command\n");
		scanf("%d", &command);
		int value = 0;
		int *array = new int[numberOfElements + 1] {};
		switch (command)
		{
		case 1:
			printf("Enter the value you'd like to add\n");
			scanf("%d", &value);
			if (!add(tree, value))
			{
				printf("This value is already in the set\n");
			}
			else
			{
				++numberOfElements;
			}
			break;

		case 2:
			printf("Enter the value you'd like to delete\n");
			scanf("%d", &value);
			if (!deleteNode(tree, value))
			{
				printf("Value is not found\n");
			}
			else
			{
				--numberOfElements;
			}
			break;

		case 3:
			printf("Enter the value you'd like to find\n");
			scanf("%d", &value);
			if (exists(tree, value))
			{
				printf("The value has been found\n");
			}
			else
			{
				printf("The value is not found\n");
			}
			break;

		case 4:
			printSet(tree, array, true);
			for (int i = 0; i < numberOfElements; ++i)
			{
				printf("%d ", array[i]);
			}
			printf("\n");
			break;

		case 5:
			printSet(tree, array, false);
			for (int i = 0; i < numberOfElements; ++i)
			{
				printf("%d ", array[i]);
			}
			printf("\n");
			
			break;
		}
		delete[] array;
	}
	
	deleteSet(tree);
	return 0;
}