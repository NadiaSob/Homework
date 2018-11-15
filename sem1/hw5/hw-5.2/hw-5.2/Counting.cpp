#include <stdio.h>
#include "List.h"
#include "Counting.h"

int counting(int numberOfWarriors, int warriorToKill)
{
	List *list = createList();
	for (int i = 1; i <= numberOfWarriors; ++i)
	{
		addNode(list, i);
	}
	int count = 1;
	while (!isOnlyOneLeft(list))
	{
		if (count % warriorToKill != 0)
		{
			moveCurrentNode(list);
		}
		else
		{
			deleteCurrentNode(list);
		}
		++count;
	}
	int lastWarrior = dataOfCurrentNode(list);
	deleteList(list);
	return lastWarrior;
}

bool test()
{
	return counting(9, 3) == 1 && counting(6, 5) == 1 && counting(10, 2) == 5 && counting(11, 4) == 9;
}