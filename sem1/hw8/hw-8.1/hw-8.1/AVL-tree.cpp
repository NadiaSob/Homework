#include <string>
#include "AVL-tree.h"

using namespace std;

struct Node;

struct Tree
{
	Node *head = nullptr;
};

struct Node
{
	int key = 0;
	string string = " ";
	int height = 0;
	Node *leftChild = nullptr;
	Node *rightChild = nullptr;
};

Tree *createTree()
{
	return new Tree;
}

bool isEmpty(Tree *tree)
{
	return tree->head == nullptr;
}

int height(Node *node)
{
	return node ? node->height : 0;
}

int balanceFactor(Node *node)
{
	return height(node->rightChild) - height(node->leftChild);
}

void updateHeight(Node *node)
{
	int heightLeft = height(node->leftChild);
	int heightRight = height(node->rightChild);
	node->height = ((heightLeft > heightRight) ? heightLeft : heightRight) + 1;
}

Node *rotateRight(Node *root)
{
	Node *pivot = root->leftChild;
	root->leftChild = pivot->rightChild;
	pivot->rightChild = root;
	updateHeight(root);
	updateHeight(pivot);
	return pivot;
}

Node *rotateLeft(Node *root)
{
	Node *pivot = root->rightChild;
	root->rightChild = pivot->leftChild;
	pivot->leftChild = root;
	updateHeight(root);
	updateHeight(pivot);
	return pivot;
}

Node *balance(Node *node)
{
	updateHeight(node);

	if (balanceFactor(node) == 2)
	{
		if (balanceFactor(node->rightChild) < 0)
		{
			node->rightChild = rotateRight(node->rightChild);
		}
		return rotateLeft(node);
	}

	if (balanceFactor(node) == -2)
	{
		if (balanceFactor(node->leftChild) > 0)
		{
			node->leftChild = rotateLeft(node->leftChild);
		}
		return rotateRight(node);
	}

	return node;
}

void add(Tree *tree, int const key, string string)
{
	if (isEmpty(tree))
	{
		tree->head = new Node{ key, string, 0, nullptr, nullptr };
	}
	else
	{
		tree->head = addNode(tree->head, key, string);
	}
}

Node *addNode(Node *node, int const key, string string)
{
	if (node->key > key && node->leftChild != nullptr)
	{
		addNode(node->leftChild, key, string);
	}
	else if (node->key < key && node->rightChild != nullptr)
	{
		addNode(node->rightChild, key, string);
	}
	else if (node->key == key)
	{
		node->string = string;
	}
	else
	{
		if (node->key > key)
		{
			node->leftChild = new Node{ key, string, 0, nullptr, nullptr };
		}
		else
		{
			node->rightChild = new Node{ key, string, 0, nullptr, nullptr };
		}
	}
	return balance(node);
}

string findNode(Tree *tree, int const key)
{
	if (isEmpty(tree))
	{
		return "";
	}
	Node *temp = tree->head;
	while (true)
	{
		if (temp->key > key)
		{
			if (temp->leftChild != nullptr)
			{
				temp = temp->leftChild;
			}
			else
			{
				return "";
			}
		}
		else if (temp->key < key)
		{
			if (temp->rightChild != nullptr)
			{
				temp = temp->rightChild;
			}
			else
			{
				return "";
			}
		}
		else
		{
			return temp->string;
		}
	}
}

bool deleteNode(Tree *tree, int const key)
{
	if (!exists(tree, key))
	{
		return false;
	}
	deleteNodeRecursion(tree->head, key);
	return true;
}

void deleteNodeRecursion(Node *&current, int key)
{
	if (current->key > key)
	{
		deleteNodeRecursion(current->leftChild, key);
	}
	else if (current->key < key)
	{
		deleteNodeRecursion(current->rightChild, key);
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
			current->key = maximum(current)->key;
			current->string = maximum(current)->string;
			deleteNodeRecursion(current->leftChild, current->key);
		}
	}
	balance(current);
}

Node *maximum(Node *current)
{
	auto *temp = current->leftChild;
	while (temp->rightChild != nullptr)
	{
		temp = temp->rightChild;
	}
	return temp;
}

bool exists(Tree *tree, int const key)
{
	if (isEmpty(tree))
	{
		return false;
	}
	Node *temp = tree->head;
	while (true)
	{
		if (temp->key > key)
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
		else if (temp->key < key)
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

void deleteTree(Tree *tree)
{
	deleteTreeRecursion(tree->head);
	delete tree;
}

void deleteTreeRecursion(Node *nodeToDelete)
{
	if (nodeToDelete != nullptr)
	{
		deleteTreeRecursion(nodeToDelete->leftChild);
		deleteTreeRecursion(nodeToDelete->rightChild);
		delete nodeToDelete;
	}
}