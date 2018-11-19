#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "ShuntingYardAlgorithm.h"

int main()
{
	if (!test())
	{
		return 1;
	}
	printf("Enter the expression\n");
	char *infix = new char[100]{};
	scanf("%[^\n]s", infix);

	char *postfix = shuntingYardAlgorithm(infix);

	int temp = 0;
	printf("Expression in Postfix: ");
	while (postfix[temp] != '\0')
	{
		printf("%c ", postfix[temp]);
		++temp;
	}

	delete[] infix;
	delete[] postfix;
	return 0;
}