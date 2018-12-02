#include "Set.h"

struct Node;

struct Set
{
	Node *head = nullptr;
};

struct Node
{
	char data = ' ';
	Node *leftChild = nullptr;
	Node *rightChild = nullptr;
};

Set *createSet()
{
	return new Set;
}

bool isOperator(char symbol)
{
	return (symbol == '+') || (symbol == '-') || (symbol == '*') || (symbol == '/');
}

void createParseTree(Set *set, char *expression)
{
	int index = 0;
	addNode(set, set->head, expression, index);
}

void addNode(Set *set, Node *&current, char *expression, int &index)
{
	if (isOperator(expression[index]))
	{
		current = new Node{ expression[index], nullptr, nullptr };
		++index;
		addNode(set, current->leftChild, expression, index);
		addNode(set, current->rightChild, expression, index);
	}
	else
	{
		current = new Node{ expression[index], nullptr, nullptr };
		++index;
	}
}

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

char *printSet(Set *set)
{
	int index = 0;
	Node *nodeToPrint = set->head;
	char *string = new char[200]{};
	printNode(set, nodeToPrint, string, index);
	return string;
}

void printNode(Set *set, Node *nodeToPrint, char *string, int &index)
{
	if (isOperator(nodeToPrint->data))
	{
		string[index] = '(';
		string[index + 1] = nodeToPrint->data;
		index += 2;
		printNode(set, nodeToPrint->leftChild, string, index);
		printNode(set, nodeToPrint->rightChild, string, index);
		string[index] = ')';
		++index;
	}
	else
	{
		string[index] = nodeToPrint->data;
		++index;
	}
}

char *convertString(char *string)
{
	char *result = new char[100]{};
	int temp = 0;
	for (int i = 0; string[i] != '\0'; ++i)
	{
		if (string[i] != '(' && string[i] != ')' && string[i] != ' ')
		{
			result[temp] = string[i];
			++temp;
		}
	}
	return result;
}

int operation(char sign, int firstNum, int secondNum)
{
	switch (sign)
	{
	case '+':
		return firstNum + secondNum;
	case '-':
		return firstNum - secondNum;
	case '*':
		return firstNum * secondNum;
	case '/':
		if (secondNum != 0)
		{
			return firstNum / secondNum;
		}
		else
		{
			return 1;
		}
	}
}

int charToInt(char digit)
{
	return digit - '0';
}

int calculation(Set *set)
{
	int result = 0;
	return recursiveCalculation(set, set->head);
}

int recursiveCalculation(Set *set, Node *current)
{
	if (isOperator(current->data))
	{
		char sign = current->data;
		int operand1 = recursiveCalculation(set, current->leftChild);
		int operand2 = recursiveCalculation(set, current->rightChild);
		return operation(sign, operand1, operand2);
	}
	else
	{
		return charToInt(current->data);
	}
}

bool test()
{
	Set *testTree1 = createSet();
	Set *testTree2 = createSet();

	char testExpression1[14] = "(* (+ 1 1) 2)";
	char testExpression2[26] = "(/ (- (+ 7 3) (* 2 3)) 2)";

	char *convertedExpression1 = convertString(testExpression1);
	char *convertedExpression2 = convertString(testExpression2);

	createParseTree(testTree1, convertedExpression1);
	createParseTree(testTree2, convertedExpression2);

	bool check = (calculation(testTree1) == 4) && (calculation(testTree2) == 2);

	delete[] convertedExpression1;
	delete[] convertedExpression2;
	deleteSet(testTree1);
	deleteSet(testTree2);
	return check;
}