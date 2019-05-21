#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>

int main()
{
	FILE * file = fopen("file.txt", "r");
	if (!file)
	{
		printf("File is not found");
		return 1;
	}
	char string[100] = {};
	char *estr = new char[100];
	while (!feof(file))
	{
		estr = fgets(string, 100, file);
		for (int i = 0; string[i] != '\0'; ++i)
		{
			if (string[i] == ';')
			{
				for (int j = i; string[j] != '\0'; ++j)
				{
					printf("%c", string[j]);
				}
			}
		}
	}
	fclose(file);
	return 0;
}