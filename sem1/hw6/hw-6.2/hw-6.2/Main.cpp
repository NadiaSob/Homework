#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "CheckingBracketBalance.h"

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
	char *string = new char[100]{};
	scanf("%s", string);

	if (checkingBracketBalance(string))
	{
		printf("Bracket balance is correct\n");
	}
	else
	{
		printf("Bracket balance is incorrect\n");
	}

	delete[] string;
	return 0;
}