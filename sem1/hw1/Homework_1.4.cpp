#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int main()
{
	int res = 0, sum = 0, n = 0;
	int x[28]{};
	while (n < 1000) {
		sum = n % 10 + (n / 10) % 10 + n / 100;
		x[sum]++;
		n++;
	}
	for (int i = 0; i < 28; ++i) {
		res += x[i] * x[i];
	}
	printf("%d", res);
	return 0;
}