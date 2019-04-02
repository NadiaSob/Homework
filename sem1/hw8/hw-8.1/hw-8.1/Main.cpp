#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <string>
#include "AVL-tree.h"

using namespace std;

int main()
{
	if (test())
	{
		cout << "Tests passed" << endl;
	}
	else
	{
		cout << "Tests failed" << endl;
		return 1;
	}

	Tree *avlTree = createTree();

	cout << "Commands:" << endl;
	cout << "0 - exit" << endl;
	cout << "1 - add string in the tree" << endl;
	cout << "2 - find string in the tree by its key" << endl;
	cout << "3 - check if the key exists" << endl;
	cout << "4 - delete string from the tree" << endl;

	int command = -1;

	while (command != 0)
	{
		cout << "Enter the command" << endl;
		cin >> command;
		string string = "";
		int key = 0;
		switch (command)
		{
		case 1:
			cout << "Enter the string you'd like to add" << endl;
			cin >> string;
			cout << "Enter the key" << endl;
			cin >> key;
			add(avlTree, key, string);
			break;

		case 2:
			cout << "Enter the key" << endl;
			cin >> key;
			cout << "The string: " << findNode(avlTree, key) << endl;
			break;

		case 3:
			cout << "Enter the key" << endl;
			cin >> key;
			if (exists(avlTree, key))
			{
				cout << "The key is found" << endl;
			}
			else
			{
				cout << "The key is not found" << endl;
			}
			break;

		case 4:
			cout << "Enter the key" << endl;
			cin >> key;
			if (deleteNode(avlTree, key))
			{
				cout << "The node is deleted successfully" << endl;
			}
			else
			{
				cout << "The key is not found" << endl;
			}
			break;
		}
	}
	deleteTree(avlTree);
	return 0;
}