#include "Set.h"

struct Node;

struct Set
{
	Node *head = nullptr;
};

struct Node
{
	int data = 0;
	Node *leftChild = nullptr;
	Node *rightChild = nullptr;
};

Set *createSet()
{
	return new Set;
}

bool isEmpty(Set *set)
{
	return set->head == nullptr;
}

void addNode(Node *node, const int data);

bool add(Set *set, const int data)
{
	if (isEmpty(set))
	{
		set->head = new Node{ data, nullptr, nullptr };
	}
	else
	{
		if (!exists(set, data))
		{
			addNode(set->head, data);
		}
		else
		{
			return false;
		}
	}
	return true;
}

void addNode(Node *node, const int data)
{
	if (node->data > data && node->leftChild != nullptr)
	{
		addNode(node->leftChild, data);
	}
	else if (node->data < data && node->rightChild != nullptr)
	{
		addNode(node->rightChild, data);
	}
	else
	{
		if (node->data > data)
		{
			node->leftChild = new Node{ data, nullptr, nullptr };
		}
		else
		{
			node->rightChild = new Node{ data, nullptr, nullptr };
		}
	}
}

void deleteNodeRecursion(Node *&current, const int data);

bool deleteNode(Set *set, const int data)
{
	if (!exists(set, data))
	{
		return false;
	}
	deleteNodeRecursion(set->head, data);
	return true;
}

int maximum(Node *current)
{
	auto *temp = current->leftChild;
	while (temp->rightChild != nullptr)
	{
		temp = temp->rightChild;
	}
	return temp->data;
}

void deleteNodeRecursion(Node *&current, const int data)
{
	if (current->data > data)
	{
		deleteNodeRecursion(current->leftChild, data);
	}
	else if (current->data < data)
	{
		deleteNodeRecursion(current->rightChild, data);
	}
	else
	{
		if (current->leftChild == nullptr && current->rightChild == nullptr)
		{
			auto *temp = current;
			current = nullptr;
			delete temp;
			return;
		}
		else if (current->leftChild == nullptr && current->rightChild != nullptr)
		{
			auto *temp = current;
			current = current->rightChild;
			delete temp;
			return;
		}
		else if (current->leftChild != nullptr && current->rightChild == nullptr)
		{
			auto *temp = current;
			current = current->leftChild;
			delete temp;
			return;
		}
		else
		{
			current->data = maximum(current);
			deleteNodeRecursion(current->leftChild, current->data);
		}
	}
}

bool exists(Set *set, const int data)
{
	if (isEmpty(set))
	{
		return false;
	}
	auto *temp = set->head;
	while (true)
	{
		if (temp->data > data)
		{
			if (temp->leftChild != nullptr)
			{
				temp = temp->leftChild;
			}
			else
			{
				return false;
			}
		}
		else if (temp->data < data)
		{
			if (temp->rightChild != nullptr)
			{
				temp = temp->rightChild;
			}
			else
			{
				return false;
			}
		}
		else
		{
			return true;
		}
	}
}

void deleteSetRecursion(Node *nodeToDelete);

void deleteSet(Set *set)
{
	deleteSetRecursion(set->head);
	delete set;
}

void deleteSetRecursion(Node *nodeToDelete)
{
	if (nodeToDelete != nullptr)
	{
		deleteSetRecursion(nodeToDelete->leftChild);
		deleteSetRecursion(nodeToDelete->rightChild);
		delete nodeToDelete;
	}
}

void printInAscendingOrder(Node *nodeToPrint, int *array, int &count);

void printInDescendingOrder(Node *nodeToPrint, int *array, int &count);

void printSet(Set *set, int *array, bool inAscendingOrder)
{
	if (isEmpty(set))
	{
		return;
	}
	int count = 0;
	if (inAscendingOrder)
	{
		printInAscendingOrder(set->head, array, count);
	}
	else
	{
		printInDescendingOrder(set->head, array, count);
	}
}

void printInAscendingOrder(Node *nodeToPrint, int *array, int &count)
{
	if (nodeToPrint->leftChild != nullptr)
	{
		printInAscendingOrder(nodeToPrint->leftChild, array, count);
	}
	array[count] = nodeToPrint->data;
	++count;

	if (nodeToPrint->rightChild != nullptr)
	{
		printInAscendingOrder(nodeToPrint->rightChild, array, count);
	}
}

void printInDescendingOrder(Node *nodeToPrint, int *array, int &count)
{
	if (nodeToPrint->rightChild != nullptr)
	{
		printInDescendingOrder(nodeToPrint->rightChild, array, count);
	}
	array[count] = nodeToPrint->data;
	++count;

	if (nodeToPrint->leftChild != nullptr)
	{
		printInDescendingOrder(nodeToPrint->leftChild, array, count);
	}
}

bool test()
{
	Set *testSet = createSet();

	add(testSet, 3);
	add(testSet, 1);
	add(testSet, 4);
	add(testSet, 5);
	add(testSet, 2);
	add(testSet, 6);

	deleteNode(testSet, 4);

	if (!exists(testSet, 1) || !exists(testSet, 3) || exists(testSet, 4))
	{
		deleteSet(testSet);
		return false;
	}

	int testArray[5]{};

	printSet(testSet, testArray, 1);

	for (int i = 0; i < 4; ++i)
	{
		if (testArray[i] > testArray[i + 1])
		{
			deleteSet(testSet);
			return false;
		}
	}

	printSet(testSet, testArray, 0);

	for (int i = 0; i < 4; ++i)
	{
		if (testArray[i] < testArray[i + 1])
		{
			deleteSet(testSet);
			return false;
		}
	}

	deleteSet(testSet);
	return true;
}