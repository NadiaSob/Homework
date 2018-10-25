#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <string.h>
#include <locale.h>

struct record
{
	char name[50]{};
	int number;
};

void addRecord(record *data, int numberOfRecords)
{
	printf("������� ���\n");
	scanf("%s", &data[numberOfRecords].name);
	printf("������� �������\n");
	scanf("%d", &data[numberOfRecords].number);
}

void printAllRecords(record *data, int numberOfRecords)
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

void findNumber(record *data, int numberOfRecords)
{
	printf("������� ���\n");
	char name[50]{};
	scanf("%s", &name);
	bool check = false;
	for (int i = 0; i < numberOfRecords; ++i)
	{
		if (strcmp(data[i].name, name) == 0)
		{
			printf("�������: %d\n", data[i].number);
			check = true;
			break;
		}
	}
	if (!check)
	{
		printf("��� �� �������\n");
	}
}

void findName(record *data, int numberOfRecords)
{
	printf("������� �������\n");
	int number = 0;
	scanf("%d", &number);
	bool check = false;
	for (int i = 0; i < numberOfRecords; ++i)
	{
		if (data[i].number == number)
		{
			printf("���: %s\n", data[i].name);
			check = true;
			break;
		}
	}
	if (!check)
	{
		printf("������� �� ������\n");
	}
}

void saveData(record *data, int numberOfRecords)
{
	FILE * file = fopen("phonebook.txt", "w");
	for (int i = 0; i < numberOfRecords; ++i)
	{
		fprintf(file, "%s %d\n", data[i].name, data[i].number);
	}
	fclose(file);
}

int main()
{
	setlocale(LC_ALL, "Russian");
	struct record phonebook[100]{};
	FILE * file = fopen("phonebook.txt", "a+");
	int numberOfRecords = 0;
	while (!feof(file))
	{
		const int readBytes = fscanf(file, "%s%d", &phonebook[numberOfRecords].name, &phonebook[numberOfRecords].number);
		if (readBytes < 0)
		{
			break;
		}
		++numberOfRecords;
	}
	fclose(file);
	printf("�������:\n0 � �����\n1 - �������� ��� � �������\n2 � ����������� ��� ��������� ������\n3 � ����� ������� �� �����\n4 - ����� ��� �� ��������\n5 - ��������� ������� ������ � ����\n");
	int command = -1;
	while (command != 0)
	{
		printf("������� �������\n");
		scanf("%d", &command);
		switch (command)
		{
		case 1:
			addRecord(phonebook, numberOfRecords);
			++numberOfRecords;
			break;
		case 2:
			printAllRecords(phonebook, numberOfRecords);
			break;
		case 3:
			findNumber(phonebook, numberOfRecords);
			break;
		case 4:
			findName(phonebook, numberOfRecords);
			break;
		case 5:
			saveData(phonebook, numberOfRecords);
			break;
		}
	}
	return 0;
}