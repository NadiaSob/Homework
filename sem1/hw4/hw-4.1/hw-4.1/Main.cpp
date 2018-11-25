#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <locale.h>
#include "Operations.h"

int main()
{
	setlocale(LC_ALL, "Russian");

	if (test())
	{
		printf("����� �������� �������\n");
	}
	else
	{
		printf("����� �� ��������\n");
		return 1;
	}

	int firstNum = 0;
	int secondNum = 0;

	printf("������� ������ �����\n");
	scanf("%d", &firstNum);
	printf("������� ������ �����\n");
	scanf("%d", &secondNum);

	bool *firstBinNum = decToBin(firstNum);
	bool *secondBinNum = decToBin(secondNum);

	printf("������ ����� � �������������� ����: ");
	printBinNumber(firstBinNum);
	printf("������ ����� � �������������� ����: ");
	printBinNumber(secondBinNum);

	bool *sum = sumOfBinNumbers(firstBinNum, secondBinNum);

	printf("����� ����� � �������� �������������: ");
	printBinNumber(sum);

	printf("����� ����� � ���������� �������������: %d", binToDec(sum));

	delete[] firstBinNum;
	delete[] secondBinNum;
	delete[] sum;
	return 0;
}