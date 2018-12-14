#include <iostream>
#include <vector>

using namespace std;

void insertSort(vector<int> &numbers, int first, int last)
{
	for (int i = first; i < last; ++i)
	{
		int temp = numbers[i];
		int j = i;
		while (j > first && temp < numbers[j - 1])
		{
			numbers[j] = numbers[j - 1];
			--j;
		}
		numbers[j] = temp;
	}
}

int main()
{
	vector<int> numbers;
	int number = 1;
	while (number != 0)
	{
		cin >> number;
		if (number != 0)
		{
			numbers.push_back(number);
		}
	}
	insertSort(numbers, 0, numbers.size());
	for (int i = 0; i < numbers.size(); ++i)
	{
		cout << numbers[i] << " ";
	}
	return 0;
}