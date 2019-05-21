#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "List.h"

int main()
{
	List *list = createList();
	int number = 1;
	while (number != 0)
	{
		scanf("%d", &number);
		if (number != 0)
		{
			addNode(list, number);
		}
	}

	printList(list);
	deleteList(list);
	return 0;
}