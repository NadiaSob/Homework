#pragma once
#include <string>
#include <vector>
#include "List.h"

struct HashTable;

//Creates new hash table
HashTable *createHashTable();

//Hash function used in hash table
long int hashFunction(HashTable *hashTable, std::string string);

//Adds string in hash table
void add(HashTable *hashTable, std::string string);

//Prints hash table
void printHashTable(HashTable *hashTable);

//Deletes hash table
void deleteHashTable(HashTable *hashTable);