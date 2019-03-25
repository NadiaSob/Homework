#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "Set.h"

char *openFile(FILE *file)
{
	char *string = new char[200]{};
	fgets(string, 200, file);
	char *result = convertString(string);
	delete[] string;
	return result;
}

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

	Set *tree = createSet();

	FILE *file = fopen("file.txt", "r");
	char *expression = openFile(file);
	fclose(file);

	createParseTree(tree, expression);

	char *expressionToPrint = printSet(tree);

	for (int i = 0; expressionToPrint[i] != '\0'; ++i)
	{
		printf("%c ", expressionToPrint[i]);
	}

	printf("\n%d", calculation(tree));

	delete[] expression;
	delete[] expressionToPrint;
	deleteSet(tree);
	return 0;
}