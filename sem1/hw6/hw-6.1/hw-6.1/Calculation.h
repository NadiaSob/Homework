#pragma once

//Do some operation with two numbers
int operation(char sign, int firstNum, int secondNum);

//Checks if symbol is digit
bool isDigit(char symbol);

//Converts a variable of type char to int
int charToInt(char digit);

//Calculates value of an expression given in Postfix form
int calculation(char *expression);

//Tests calculation functions
bool test();