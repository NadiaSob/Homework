#include <stdio.h>
#include "Operations.h"

const int length = 32;

bool *decToBin(int decNumber)
{
	int bit = 0b01000000000000000000000000000000;
	bool *binNumber = new bool[length]{};
	binNumber[0] = (decNumber < 0);
	for (int i = 1; i < length; ++i)
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
	for (int i = length - 1; i >= 0; --i)
	{
		decNumber += binNumber[i] * powerOfTwo;
		powerOfTwo *= 2;
	}
	return decNumber;
}

int lengthOfBinNumber(bool *binNumber)
{
	for (int i = 0; i < length; ++i)
	{
		if (binNumber[i])
		{
			const int lengthOfBinNum = length - i;
			return lengthOfBinNum;
		}
	}
	return 1;
}

void printBinNumber(bool *binNumber)
{
	for (int i = length - lengthOfBinNumber(binNumber); i < length; ++i)
	{
		printf("%d", binNumber[i]);
	}
	printf("\n");
}

bool *sumOfBinNumbers(bool *firstBinNum, bool *secondBinNum)
{
	bool *sum = new bool[length]{};
	bool temp = 0;
	for (int i = length - 1; i >= 0; --i)
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
	if (!binNum1[31] || !binNum1[30] || !binNum1[29] || !binNum1[28] || binNum1[0])
	{
		delete[] binNum1;
		return false;
	}

	bool *binNum2 = decToBin(number2);
	if (binNum2[31] || !binNum2[30] || !binNum2[29] || binNum2[28] || !binNum2[0])
	{
		delete[] binNum1;
		delete[] binNum2;
		return false;
	}

	if ((lengthOfBinNumber(binNum1) != 4) || (lengthOfBinNumber(binNum2) != 32))
	{
		delete[] binNum1;
		delete[] binNum2;
		return false;
	}

	bool *sum = sumOfBinNumbers(binNum1, binNum2);
	if (!sum[31] || sum[30] || !sum[29] || sum[28] || sum[0])
	{
		delete[] binNum1;
		delete[] binNum2;
		delete[] sum;
		return false;
	}

	int decSum = binToDec(sum);

	delete[] binNum1;
	delete[] binNum2;
	delete[] sum;

	return decSum == 5;
}