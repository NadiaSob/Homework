#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>
#include "List.h"
#include "MergeSort.h"

void openFile(List *list)
{
	FILE * file = fopen("phonebook.txt", "r");
	while (!feof(file))
	{
		int number = 0;
		char name[50]{};
		const int readBytes = fscanf(file, "%s - %d", name, &number);
		if (readBytes < 0)
		{
			break;
		}
		Record newRecord;
		strcpy(newRecord.name, name);
		newRecord.number = number;
		addNode(list, newRecord);
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

	printf("Choose how to sort the list of records:\n");
	printf("press 0 to sort by name\n");
	printf("press 1 to sort by phone number\n");

	int command = 0;
	scanf("%d", &command);

	List *list = createList();
	openFile(list);

	if (command == 0)
	{
		mergeSort(list, 1);
		printList(list);
	}
	else if (command == 1)
	{
		mergeSort(list, 0);
		printList(list);
	}
	deleteList(list);
	return 0;
}