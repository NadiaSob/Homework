#include "KMP.h"

using namespace std;

int *prefixFunction(string const &str)
{
	int length = str.size();
	int *pi = new int[length]{};
	pi[0] = 0;
	for (int i = 1; i < length; ++i)
	{
		int count = pi[i - 1];
		while (count > 0 && str[i] != str[count])
		{
			count = pi[count - 1];
		}
		if (str[i] == str[count])
		{
			++count;
		}
		pi[i] = count;
	}
	return pi;
}

int knuthMorrisPrattAlgorithm(ifstream &text, string const &pattern)
{
	int patternLength = pattern.size();
	int *pi = prefixFunction(pattern);

	int count = 0;
	int index = 0;
	char symbol = ' ';
	text.get(symbol);

	while (!text.eof())
	{

		while (symbol != pattern[count] && count > 0)
		{
			count = pi[count - 1];
		}
		if (symbol == pattern[count])
		{
			++count;
		}
		text.get(symbol);
		++index;

		if (count == patternLength)
		{
			delete[] pi;
			return  index - patternLength + 1;
		}
	}
	delete[] pi;
	return -1;
}

bool test()
{
	ifstream testText1("TestFile.txt");

	string pattern1 = "have";
	string pattern2 = "your";
	string pattern3 = "happy";

	if (knuthMorrisPrattAlgorithm(testText1, pattern1) != 1) 
	{
		testText1.close();
		return false;
	}
	testText1.close();

	ifstream testText2("TestFile.txt");
	if (knuthMorrisPrattAlgorithm(testText2, pattern2) != 6)
	{
		testText2.close();
		return false;
	}
	testText2.close();
	
	ifstream testText3("TestFile.txt");
	if (knuthMorrisPrattAlgorithm(testText3, pattern3) != -1)
	{
		testText3.close();
		return false;
	}
	testText3.close();
	return true;
}