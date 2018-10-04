#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

void arrayReverse(int array[], int firstElement, int lastElement) {
	for (int i = 0; i < (lastElement - firstElement) / 2; ++i) {
		int k = array[firstElement + i];
		array[firstElement + i] = array[lastElement - (i + 1)];
		array[lastElement - (i + 1)] = k;
	}
}
int main()
{
	int m = 0, n = 0, k = 0;
	scanf("%d", &m);
	scanf("%d", &n);
	const int size = m + n;
	int *x = new int[size] {};
	for (int i = 0; i < size; ++i) {
		scanf("%d", &x[i]);
	}
	arrayReverse(x, 0, m);
	arrayReverse(x, m, size);
	arrayReverse(x, 0, size);
	for (int j = 0; j < size; ++j) {
		printf("%d ", x[j]);
	}
	delete[]x;
	return 0;
}