#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <fstream>
#include <string>
#include "HashTable.h"

using namespace std;

void openFile(HashTable *hashTable)
{
	ifstream file;
	file.open("text.txt");
	string word = "";
	while (!file.eof())
	{
		file >> word;
		add(hashTable, word);
	}
	file.close();
}

int main()
{
	if (test())
	{
		cout << "Tests passed successfully" << endl;
	}
	else
	{
		cout << "Tests failed!" << endl;
		return 1;
	}

	HashTable *hashTable = createHashTable();
	openFile(hashTable);

	cout << "Words that were found in the text and number of times:" << endl;
	printHashTable(hashTable);

	cout << "The load factor: " << loadFactor(hashTable) << endl;

	cout << "Average length of list in the hash table: " << averageListLength(hashTable) << endl;

	cout << "Maximal length of list in the hash table: " << maxListLength(hashTable) << endl;

	deleteHashTable(hashTable);
	return 0;
}