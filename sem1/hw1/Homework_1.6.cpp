#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int main()
{
	int lengthOfS = 0, lengthOfS1 = 0;
	bool check = true;
	printf("Enter the length of the string\n");
	scanf("%d", &lengthOfS);
	printf("Enter the length of the substring\n");
	scanf("%d", &lengthOfS1);
	char *s = new char[lengthOfS+1] {};
	char *s1 = new char[lengthOfS1+1] {};
	printf("Enter the string\n");
	scanf("%s", s);
	printf("Enter the substring\n");
	scanf("%s", s1);
	int res = 0;
	for (int i = 0; i <= lengthOfS - lengthOfS1; ++i) {
		if (s[i] == s1[0]) {
			for (int j = 1; j < lengthOfS1; ++j) {
				if (s[i + j] != s1[j]) {
					check = false;
					break;
				}
			}
			if (check) {
				res++;
			}
		}
	}
	printf("%d", res);
	delete[]s;
	delete[]s1;
	return 0;
}