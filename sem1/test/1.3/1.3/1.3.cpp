#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int main()
{
	FILE * fileG = fopen("g.txt", "r");
	if (!fileG)
	{
		printf("File g.txt is not found");
		return 1;
	}
	int x = 0;
	fscanf(fileG, "%d", &x);
	fclose(fileG);
	FILE * fileF = fopen("f.txt", "r");
	if (!fileF)
	{
		printf("File f.txt is not found");
		return 1;
	}
	FILE * fileH = fopen("h.txt", "w");
	int number = 0;
	while (!feof(fileF))
	{
		fscanf(fileF, "%d", &number);
		if (number < x)
		{
			fprintf(fileH, "%d ", number);
		}
	}
	fclose(fileH);
	fclose(fileF);
	printf("New file has been created\n");
	return 0;
}