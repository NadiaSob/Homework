#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "List.h"

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
	printf("Commands:\n0 - exit\n1 - add value in the sorted list\n2 - delete value from the list\n3 - print the list\n");
	int command = -1;
	while (command != 0)
	{
		printf("Enter the command\n");
		int value = 0;
		scanf("%d", &command);
		switch (command)
		{
		case 1:
			printf("Enter the value you'd like to add\n");
			scanf("%d", &value);
			addNode(list, value);
			break;
		case 2:
			if (isEmpty(list))
			{
				printf("The list is empty\n");
				break;
			}
			else
			{
				printf("Enter the value you'd like to delete\n");
				scanf("%d", &value);
				deleteNode(list, value);
				break;
			}
		case 3:
			printList(list);
			break;
		}
	}
	return 0;
}