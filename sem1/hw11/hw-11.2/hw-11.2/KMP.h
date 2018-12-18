#pragma once
#include <string>
#include <vector>
#include <fstream>

//Looks for the first occurrence of the pattern in the string
//If it is not found, returns -1
int knuthMorrisPrattAlgorithm(std::ifstream &text, std::string pattern);

//Tests the Knuth-Morris-Pratt algorithm function
bool test();