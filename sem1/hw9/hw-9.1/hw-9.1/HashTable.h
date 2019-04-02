#pragma once
#include <string>
#include <vector>
#include "List.h"

struct HashTable;

//Creates new hash table
HashTable *createHashTable();

//Hash function used in hash table
long int hashFunction(HashTable *hashTable, const std::string string);

//Adds string in hash table
void add(HashTable *hashTable, const std::string string);

//Prints hash table
void printHashTable(HashTable *hashTable);

//Deletes hash table
void deleteHashTable(HashTable *hashTable);

//Counts load factor of hash table
float loadFactor(HashTable *hashTable);

//Counts an average length of list in hash table
float averageListLength(HashTable *hashTable);

//Returns maximal length of list in hash table
int maxListLength(HashTable *hashTable);

//Tests some of HashTable functions
bool test();