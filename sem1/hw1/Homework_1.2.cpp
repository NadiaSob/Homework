#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <math.h>

int main()
{
	int a = 0, b = 0, res = 0;
	scanf("%d", &a);
	scanf("%d", &b);
	int b1 = abs(b);
	if (b == 0) {
		printf("The denominator is 0");
	}
	else {
		while (b1 <= abs(a)) {
		res++;
		b1 += abs(b);
		}
	}
	if ((a >= 0 && b > 0) || (a <= 0 && b < 0)) {
		printf("%d", res);
	}
	if ((a > 0 && b < 0) || (a < 0 && b > 0)) {
		printf("%d", -res);
	}
	return 0;
}