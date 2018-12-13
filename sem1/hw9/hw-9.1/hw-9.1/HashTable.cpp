#include "HashTable.h"

using namespace std;

struct HashTable
{
	vector<List*> bucket;
	int numberOfElements = 0;
};

HashTable *createHashTable()
{
	HashTable *hashTable = new HashTable;
	const int size = 100;
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
		findString(hashTable->bucket[hash], string);
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