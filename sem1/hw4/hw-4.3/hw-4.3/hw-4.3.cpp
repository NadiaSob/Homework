#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>
#include <locale.h>

struct Record
{
	char name[50]{};
	int number = 0;
};

void openFile(Record *data, int &numberOfRecords)
{
	FILE * file = fopen("phonebook.txt", "a+");
	numberOfRecords = 0;
	while (!feof(file))
	{
		const int readBytes = fscanf(file, "%s%d", &data[numberOfRecords].name, &data[numberOfRecords].number);
		if (readBytes < 0)
		{
			break;
		}
		++numberOfRecords;
	}
	fclose(file);
}

void addRecord(Record *data, int &numberOfRecords, char *name, int number)
{
	strcpy(data[numberOfRecords].name, name);
	data[numberOfRecords].number = number;
	++numberOfRecords;
}

void deleteRecord(Record *data, int &numberOfRecords, int positionOfRecord)
{
	strcpy(data[positionOfRecord].name, "\0");
	data[positionOfRecord].number = 0;
	--numberOfRecords;
}

void printAllRecords(Record *data, int numberOfRecords)
{
	if (numberOfRecords == 0)
	{
		printf("� ����� ��� �������\n");
	}
	else
	{
		for (int i = 0; i < numberOfRecords; ++i)
		{
			printf("%s %d\n", data[i].name, data[i].number);
		}
	}
}

int findNumber(Record *data, int numberOfRecords, char *name)
{
	for (int i = 0; i < numberOfRecords; ++i)
	{
		if (strcmp(data[i].name, name) == 0)
		{
			return data[i].number;
		}
	}
	return -1;
}

char *findName(Record *data, int numberOfRecords, int number)
{
	bool check = false;
	for (int i = 0; i < numberOfRecords; ++i)
	{
		if (data[i].number == number)
		{
			return data[i].name;
		}
	}
	char notFound[2] = "\0";
	return notFound;
}

void saveData(Record *data, int numberOfRecords)
{
	FILE * file = fopen("phonebook.txt", "w");
	for (int i = 0; i < numberOfRecords; ++i)
	{
		fprintf(file, "%s %d\n", data[i].name, data[i].number);
	}
	fclose(file);
}

bool test()
{
	char testName[9] = "Testname";
	int testNumber = 111;
	Record testPhonebook[101]{};
	int numberOfRecords = 0;
	openFile(testPhonebook, numberOfRecords);
	int initialNumberOfRecords = numberOfRecords;
	addRecord(testPhonebook, numberOfRecords, testName, testNumber);
	saveData(testPhonebook, numberOfRecords);
	if (strcmp(findName(testPhonebook, numberOfRecords, testNumber), testName) != 0)
	{
		return false;
	}
	if (findNumber(testPhonebook, numberOfRecords, testName) != testNumber)
	{
		return false;
	}
	deleteRecord(testPhonebook, numberOfRecords, numberOfRecords - 1);
	saveData(testPhonebook, numberOfRecords);
	return numberOfRecords == initialNumberOfRecords;
}

int main()
{
	setlocale(LC_ALL, "Russian");
	if (test())
	{
		printf("����� �������� �������\n");
	}
	else
	{
		printf("����� �� ��������\n");
		return 1;
	}
	Record phonebook[100]{};
	int numberOfRecords = 0;
	openFile(phonebook, numberOfRecords);
	printf("�������:\n");
	printf("0 � �����\n");
	printf("1 - �������� ��� � �������\n");
	printf("2 � ����������� ��� ��������� ������\n");
	printf("3 � ����� ������� �� �����\n");
	printf("4 - ����� ��� �� ��������\n");
	printf("5 - ��������� ������� ������ � ����\n");
	int command = -1;
	while (command != 0)
	{
		printf("������� �������\n");
		scanf("%d", &command);
		char name[50]{};
		int number = 0;
		switch (command)
		{
		case 1:
			printf("������� ���\n");
			scanf("%s", &name);
			printf("������� �������\n");
			scanf("%d", &number);
			addRecord(phonebook, numberOfRecords, name, number);
			break;
		case 2:
			printAllRecords(phonebook, numberOfRecords);
			break;
		case 3:
			printf("������� ���\n");
			scanf("%s", &name);
			number = findNumber(phonebook, numberOfRecords, name);
			if (number != -1)
			{
				printf("�������: %d\n", number);
				break;
			}
			else
			{
				printf("��� �� �������\n");
				break;
			}
		case 4:
			printf("������� �������\n");
			scanf("%d", &number);
			strcpy(name, findName(phonebook, numberOfRecords, number));
			if (strcmp(name, "\0") != 0)
			{
				printf("���: %s\n", name);
				break;
			}
			else
			{
				printf("������� �� ������\n");
				break;
			}
		case 5:
			saveData(phonebook, numberOfRecords);
			break;
		}
	}
	return 0;
}