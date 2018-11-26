#pragma once

//Checks if symbol is digit
bool isDigit(char symbol);

//Checks if symbol is operator
bool isOperator(char symbol);

//Checks if operator has priority
bool ifHasPriority(char symbol);

//Shunting-yard algorithm of conversing expression from Infix to Postfix
char *shuntingYardAlgorithm(char *infix);

//Tests the shuntingYardAlgorithm function
bool test();