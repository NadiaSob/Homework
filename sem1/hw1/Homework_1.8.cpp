#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int main()
{
	int size = 0, k = 0;
	printf("Enter the size of the array\n");
	scanf("%d", &size);
	int *x = new int[size] {};
	for (int i = 0; i < size; ++i) {
		scanf("%d", &x[i]);
		if (x[i] == 0) {
			k++;
		}
	}
	printf("%d", k);
	delete[]x;
	return 0;
}