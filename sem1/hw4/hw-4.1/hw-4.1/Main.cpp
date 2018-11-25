#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <locale.h>
#include "Operations.h"

int main()
{
	setlocale(LC_ALL, "Russian");

	if (test())
	{
		printf("Тесты пройдены успешно\n");
	}
	else
	{
		printf("Тесты не пройдены\n");
		return 1;
	}

	int firstNum = 0;
	int secondNum = 0;

	printf("Введите первое число\n");
	scanf("%d", &firstNum);
	printf("Введите второе число\n");
	scanf("%d", &secondNum);

	bool *firstBinNum = decToBin(firstNum);
	bool *secondBinNum = decToBin(secondNum);

	printf("Первое число в дополнительном коде: ");
	printBinNumber(firstBinNum);
	printf("Второе число в дополнительном коде: ");
	printBinNumber(secondBinNum);

	bool *sum = sumOfBinNumbers(firstBinNum, secondBinNum);

	printf("Сумма чисел в двоичном представлении: ");
	printBinNumber(sum);

	printf("Сумма чисел в десятичном представлении: %d", binToDec(sum));

	delete[] firstBinNum;
	delete[] secondBinNum;
	delete[] sum;
	return 0;
}