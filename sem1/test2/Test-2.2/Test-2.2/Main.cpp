#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "List.h"

void openFile(List *list)
{
	FILE * file = fopen("file.txt", "r");
	while (!feof(file))
	{
		int number = 0;
		const int readBytes = fscanf(file, "%d", &number);
		if (readBytes < 0)
		{
			break;
		}
		addNode(list, number);
	}
	fclose(file);
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
		return 1;
	}

	List *list = createList();

	openFile(list);

	if (checkSymmetry(list))
	{
		printf("The list is symmetrical\n");
	}
	else
	{
		printf("The list is not symmetrical\n");
	}

	deleteList(list);
	return 0;
}