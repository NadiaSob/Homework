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
	HashTable *hashTable = createHashTable();
	openFile(hashTable);

	printHashTable(hashTable);

	deleteHashTable(hashTable);
	return 0;
}