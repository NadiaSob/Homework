#pragma once

//Converts a number from decimal to binary
bool *decToBin(int decNumber);

//Converts a number from binary to decimal
int binToDec(bool *binNumber);

//Calculates the length of binary number
int lengthOfBinNumber(bool *binNumber);

//Prints a binary number
void printBinNumber(bool *binNumber);

//Calculates the sum of numbers in binary notation
bool *sumOfBinNumbers(bool *firstBinNum, bool *secondBinNum);

//Tests the functions of operations
bool test();