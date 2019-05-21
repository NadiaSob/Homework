#include <string>
#include "List.h"
#include "MergeSort.h"

using namespace std;

void mergeLists(List *list, List *list1, List *list2)
{
	while (!isEmpty(list))
	{
		deleteHead(list);
	}
	List *resList = createList();
	Node *current1 = list1->head;
	Node *current2 = list2->head;

	while (current1 != nullptr && current2 != nullptr)
	{
		if (current1->str < current2->str)
		{
			addNode(resList, current1->str);
			current1 = current1->next;
		}
		else
		{
			addNode(resList, current2->str);
			current2 = current2->next;
		}
	}

	while (current1 != nullptr)
	{
		addNode(resList, current1->str);
		current1 = current1->next;
	}
	while (current2 != nullptr)
	{
		addNode(resList, current2->str);
		current2 = current2->next;
	}

	Node *current = resList->head;
	while (current != nullptr)
	{
		addNode(list, current->str);
		current = current->next;
	}
	deleteList(resList);
}

void mergeSort(List *list)
{
	if (list->head->next != nullptr)
	{
		int middle = list->length / 2;

		List *list1 = createList();
		Node *current = list->head;
		for (int i = 1; i <= middle; ++i)
		{
			addNode(list1, current->str);
			current = current->next;
		}

		List *list2 = createList();
		for (int i = middle; i < list->length; ++i)
		{
			addNode(list2, current->str);
			current = current->next;
		}

		mergeSort(list1);
		mergeSort(list2);
		mergeLists(list, list1, list2);

		deleteList(list1);
		deleteList(list2);
	}
}