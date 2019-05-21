#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "Calculation.h"

int main()
{
	if (test())
	{
		printf("Tests passed\n");
	}
	else
	{
		printf("Tests failed\n");
		return 1;
	}
	printf("Enter the expression\n");
	char *expression = new char[100]{};
	scanf("%[^\n]s", expression);

	printf("The result of calculation is %d", calculation(expression));

	delete[] expression;
	return 0;
}