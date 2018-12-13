#include <fstream>
#include "HashTable.h"

using namespace std;

struct HashTable
{
	vector<List*> bucket;
	int numberOfElements = 0;
	int maxListLength = 0;
};

HashTable *createHashTable()
{
	HashTable *hashTable = new HashTable;
	const int size = 200;
	hashTable->bucket.resize(size);
	return hashTable;
}

long int hashFunction(HashTable *hashTable, string string)
{
	const long int prime = 31;
	int hash = 0;
	int power = 1;
	for (int i = 0; i < string.length(); ++i)
	{
		hash += (string[i] - 'a' + 1) * power;
		power *= prime;
	}
	return hash % hashTable->bucket.size();
}

void add(HashTable *hashTable, string string)
{
	int hash = hashFunction(hashTable, string);

	if (hashTable->bucket[hash] == nullptr)
	{
		hashTable->bucket[hash] = createList();
		addNewNode(hashTable->bucket[hash], string);
		++hashTable->numberOfElements;
	}
	else
	{
		if (!findString(hashTable->bucket[hash], string))
		{
			++hashTable->numberOfElements;
		}
	}

	if (hashTable->maxListLength < hashTable->bucket[hash]->length)
	{
		hashTable->maxListLength = hashTable->bucket[hash]->length;
	}
}

void printHashTable(HashTable *hashTable)
{
	for (int i = 0; i < hashTable->bucket.size(); ++i)
	{
		if (hashTable->bucket[i] != nullptr)
		{
			printList(hashTable->bucket[i]);
		}
	}
}

void deleteHashTable(HashTable *hashTable)
{
	for (int i = 0; i < hashTable->bucket.size(); ++i)
	{
		if (hashTable->bucket[i] != nullptr)
		{
			deleteList(hashTable->bucket[i]);
		}
	}
	delete hashTable;
}

float loadFactor(HashTable *hashTable)
{
	return (float)hashTable->numberOfElements / (float)hashTable->bucket.size();
}

float averageListLength(HashTable *hashTable)
{
	int sumOfLengthes = 0;
	for (int i = 0; i < hashTable->bucket.size(); ++i)
	{
		if (hashTable->bucket[i] != nullptr)
		{
			sumOfLengthes += hashTable->bucket[i]->length;
		}
	}
	return (float)sumOfLengthes / (float)hashTable->bucket.size();
}

int maxListLength(HashTable *hashTable)
{
	return hashTable->maxListLength;
}

bool test()
{
	HashTable *testTable = createHashTable();
	ifstream file;
	file.open("testText.txt");
	string word = "";
	while (!file.eof())
	{
		file >> word;
		add(testTable, word);
	}
	file.close();

	int hash1 = hashFunction(testTable, "Peter");
	int hash2 = hashFunction(testTable, "picked");
	int hash3 = hashFunction(testTable, "peppers");
	int hash4 = hashFunction(testTable, "a");
	int hash5 = hashFunction(testTable, "where's");

	if (countOfWord(testTable->bucket[hash1], "Peter") != 4 || countOfWord(testTable->bucket[hash2], "picked") != 4
		|| countOfWord(testTable->bucket[hash3], "peppers") != 4 || countOfWord(testTable->bucket[hash4], "a") != 3
		|| countOfWord(testTable->bucket[hash5], "where's") != 1)
	{
		deleteHashTable(testTable);
		return false;
	}
	deleteHashTable(testTable);
	return true;
}