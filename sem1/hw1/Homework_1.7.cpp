#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <math.h>

int main()
{
	int n = 0, p = 1;
	bool pr = true;
	scanf("%d", &n);
	while (p <= n) {
		for (int i = 2; i <= sqrt(p); ++i) {
			if (p%i == 0) {
				pr = false;
				break;
			}
		}
		if (pr == true) {
			printf("%d ", p);
		}
		else { pr = true; }
		p++;
	}
	return 0;
}