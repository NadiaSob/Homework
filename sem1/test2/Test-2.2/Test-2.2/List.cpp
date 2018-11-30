#include "List.h"

struct Node
{
	int data = 0;
	Node *next = nullptr;
};

struct List
{
	Node *head = nullptr;
	int length = 0;
};

List *createList()
{
	return new List;
}

bool isEmpty(List *list)
{
	return list->head == nullptr;
}

void addNode(List *list, int data)
{
	auto newNode = new Node{ data, nullptr };
	if (isEmpty(list))
	{
		list->head = newNode;
	}
	else
	{
		newNode->next = list->head;
		list->head = newNode;
	}
	++list->length;
}

void deleteHead(List *list)
{
	Node *nodeToDelete = list->head;
	list->head = nodeToDelete->next;
	delete nodeToDelete;
	--list->length;
}

void deleteList(List *list)
{
	while (!isEmpty(list))
	{
		deleteHead(list);
	}
	delete list;
}

bool checkSymmetry(List *list)
{
	const int middle = list->length / 2;

	int *array = new int[middle] {};

	Node *current = list->head;

	for (int i = 0; i < middle; ++i)
	{
		array[i] = current->data;
		current = current->next;
	}
	
	if (list->length % 2 != 0)
	{
		current = current->next;
	}

	int temp = middle - 1;
	while (current != nullptr)
	{
		if (current->data != array[temp])
		{
			delete[] array;
			return false;
		}
		current = current->next;
		--temp;
	}
	delete[] array;
	return true;
}

void addArrayInList(List *list, int *array, const int length)
{
	for (int i = 0; i < length; ++i)
	{
		addNode(list, array[i]);
	}
}

bool test()
{
	int array1[8] = { 4, 5, 7, 6, 6, 7, 4, 4 };
	int array2[6] = { 7, 36, 12, 12, 36, 7 };
	int array3[5] = { 1, 7, 8, 7, 1 };

	List *testList1 = createList();
	List *testList2 = createList();
	List *testList3 = createList();

	addArrayInList(testList1, array1, 8);
	addArrayInList(testList2, array2, 6);
	addArrayInList(testList3, array3, 5);
	
	bool check = !checkSymmetry(testList1) && checkSymmetry(testList2) && checkSymmetry(testList3);

	deleteList(testList1);
	deleteList(testList2);
	deleteList(testList3);
	return check;
}