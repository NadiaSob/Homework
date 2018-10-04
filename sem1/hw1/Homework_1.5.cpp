#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>

int main()
{
	int counter = 0;
	const int length = 10;
	bool bracketBalance = true;
	printf("Enter the string which length is 10\n");
	char str[length] {};
	for (int i = 0; i < 10; ++i) {
		scanf("%c", &str[i]);
		if (str[i] == '(') {
			counter++;
		}
		if (str[i] == ')') {
			if (counter < 1) {
				bracketBalance = false;
				break;
			}
			counter--;
		}
	}
	if (counter != 0) {
		bracketBalance = false;
	}
	if (!bracketBalance) {
		printf("Bracket balance is incorrect");
	}
	else {
		printf("Bracket balance is correct");
	}
	return 0;
}