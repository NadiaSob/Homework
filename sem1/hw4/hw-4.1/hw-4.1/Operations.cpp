#include <stdio.h>
#include "Operations.h"

bool *decToBin(int decNumber)
{
	int bit = 0b01000000000000000000000000000000;
	bool *binNumber = new bool[32]{};
	binNumber[0] = (decNumber < 0);
	for (int i = 1; i < 32; ++i)
	{
		binNumber[i] = (decNumber & bit);
		bit = bit >> 1;
	}
	return binNumber;
}

int binToDec(bool *binNumber)
{
	int decNumber = 0;
	int powerOfTwo = 1;
	for (int i = 31; i >= 0; --i)
	{
		decNumber += binNumber[i] * powerOfTwo;
		powerOfTwo *= 2;
	}
	return decNumber;
}

int lengthOfBinNumber(bool *binNumber)
{
	for (int i = 0; i < 32; ++i)
	{
		if (binNumber[i] == 1)
		{
			const int length = 32 - i;
			return length;
		}
	}
	return 1;
}

void printBinNumber(bool *binNumber)
{
	for (int i = 32 - lengthOfBinNumber(binNumber); i < 32; ++i)
	{
		printf("%d", binNumber[i]);
	}
	printf("\n");
}

bool *sumOfBinNumbers(bool *firstBinNum, bool *secondBinNum)
{
	bool *sum = new bool[32]{};
	bool temp = 0;
	for (int i = 31; i >= 0; --i)
	{
		if ((firstBinNum[i] | secondBinNum[i]) && !(firstBinNum[i] & secondBinNum[i]))
		{
			sum[i] = !temp & 1;
		}
		else if (firstBinNum[i] & secondBinNum[i])
		{
			sum[i] = temp | 0;
			temp = 1;
		}
		else if (!(firstBinNum[i] & secondBinNum[i]))
		{
			sum[i] = temp | 0;
			temp = 0;
		}
	}
	return sum;
}

bool test()
{
	int number1 = 15;
	int number2 = -10;

	bool *binNum1 = decToBin(number1);
	if ((binNum1[31] != 1) || (binNum1[30] != 1) || (binNum1[29] != 1) || (binNum1[28] != 1) || (binNum1[0] != 0))
	{
		return false;
	}

	bool *binNum2 = decToBin(number2);
	if ((binNum2[31] != 0) || (binNum2[30] != 1) || (binNum2[29] != 1) || (binNum2[28] != 0) || (binNum2[0] != 1))
	{
		return false;
	}

	if ((lengthOfBinNumber(binNum1) != 4) || (lengthOfBinNumber(binNum2) != 32))
	{
		return false;
	}

	bool *sum = sumOfBinNumbers(binNum1, binNum2);
	if ((sum[31] != 1) || (sum[30] != 0) || (sum[29] != 1) || (sum[28] != 0) || (sum[0] != 0))
	{
		return false;
	}

	int decSum = binToDec(sum);

	delete[] binNum1;
	delete[] binNum2;
	delete[] sum;

	return decSum == 5;
}