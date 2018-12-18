#include <iostream>
#include "KMP.h" 

using namespace std;

int main()
{
	if (test())
	{
		cout << "Tests passed successfully" << endl;
	}
	else
	{
		cout << "Tests failed!" << endl;
		return 1;
	}

	ifstream text("Text.txt");

	cout << "Enter the pattern" << endl;
	string pattern = "";
	cin >> pattern;

	int firstOccurrence = knuthMorrisPrattAlgorithm(text, pattern);
	text.close();

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