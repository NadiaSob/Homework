#include <iostream>
#include <fstream>
#include <string>
#include "List.h"
#include "MergeSort.h"

using namespace std;

void openFile(List *list)
{
	ifstream input("Input.txt");
	string str = "";
	while (!input.eof())
	{
		getline(input, str);
		addNode(list, str);
	}
	input.close();
}

int main()
{
	List *list = createList();
	openFile(list);

	mergeSort(list);

	putListInFile(list);
	
	deleteList(list);
	return 0;
}
