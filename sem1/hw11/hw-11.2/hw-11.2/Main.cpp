#include <iostream>
#include <string>
#include <fstream>
#include "KMP.h"

using namespace std;

string openFile()
{
	ifstream file;
	file.open("Text.txt");
	string str = "";
	getline(file, str);
	file.close();
	return str;
}

int main()
{
	//tests

	string str = openFile();
	cout << "Enter the pattern" << endl;
	string pattern = "";
	cin >> pattern;

	int firstOccurrence = KnuthMorrisPrattAlgorithm(str, pattern);
	if (firstOccurrence != -1)
	{
		cout << "The first occurrence of pattern in the string: " << firstOccurrence << endl;
	}
	else
	{
		cout << "The pattern was not found in the string" << endl;
	}

	return 0;
}