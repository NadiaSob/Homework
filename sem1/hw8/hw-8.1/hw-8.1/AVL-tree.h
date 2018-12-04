#pragma once

struct Node;

struct Tree;

//Creates new tree
Tree *createTree();

//Checks if tree is empty
bool isEmpty(Tree *tree);

//Adds new node in tree
void add(Tree *tree, int const key, std::string string);

//Used in function add
Node *addNode(Node *node, int data, std::string string);

//Returns string with given key
std::string findNode(Tree *tree, int const key);

//Deletes node with given key
bool deleteNode(Tree *tree, int const key);

//Used in function deleteNode
void deleteNodeRecursion(Node *&current, int data);

//Finds maximum of the left subtree
Node *maximum(Node *current);

//Checkes if node with given data exists
bool exists(Tree *tree, int const key);

//Deletes tree
void deleteTree(Tree *tree);

//Used in function deleteTree
void deleteTreeRecursion(Node *nodeToDelete);