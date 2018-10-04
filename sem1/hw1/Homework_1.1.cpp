#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int main()
{
	int x = 0;
	scanf("%d", &x);
	int squareOfX = x * x;
	printf("%d\n", (squareOfX + 1) * (squareOfX + x) + 1);
	return 0;
}
