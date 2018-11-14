#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include "List.h"
#include "Counting.h"

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
	printf("Enter n - the number of warriors\n");
	int n = 0;
	scanf("%d", &n);
	printf("Enter m - warrior to be killed\n");
	int m = 0;
	scanf("%d", &m);
	printf("Position of the last survived warrior is %d", counting(n, m));
	return 0;
}