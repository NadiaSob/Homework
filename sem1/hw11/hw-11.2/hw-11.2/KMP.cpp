#include "KMP.h"

using namespace std;

vector<int> prefixFunction(string str)
{
	int length = str.size();
	vector<int> pi(length);
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

int KnuthMorrisPrattAlgorithm(string str, string pattern)
{
	int strLength = str.size();
	int patternLength = pattern.size();
	vector<int> pi(patternLength);
	pi = prefixFunction(pattern);

	int count = 0;
	int index = 0;

	while (index < strLength)
	{
		while (str[index] != pattern[count] && count > 0)
		{
			count = pi[count - 1];
		}
		if (str[index] == pattern[count])
		{
			++count;
		}
		++index;

		if (count == patternLength)
		{
			return index - patternLength + 1;
		}
	}
	return -1;
}