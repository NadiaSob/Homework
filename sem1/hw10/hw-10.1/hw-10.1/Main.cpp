#include <iostream>
#include <fstream>
#include "Graph.h"

using namespace std;

void printWorld(World *world, int numberOfCapitals)
{
	for (int i = 1; i <= numberOfCapitals; ++i)
	{
		cout << "Cities of country " << i << ": ";
		for (int j = 0; j < world->cities.size(); ++j)
		{
			if (world->cities[j]->country == i)
			{
				cout << j + 1 << " ";
			}
		}
		cout << endl;
	}
}

int main()
{
	ifstream file;
	file.open("Input.txt");

	int numberOfCities = 0;
	file >> numberOfCities;
	cout << "Number of cities(n): " << numberOfCities << endl;
	World *world = createWorld(numberOfCities);

	int numberOfRoads = 0;
	file >> numberOfRoads;
	cout << "Number of roads(m): " << numberOfRoads << endl;

	cout << "Connected cities and lengthes of roads between them(i j len):" << endl;
	for (int i = 0; i < numberOfRoads; ++i)
	{
		int firstCity = 0;
		int secondCity = 0;
		int road = 0;
		file >> firstCity >> secondCity >> road;
		cout << firstCity << " " << secondCity << " " << road << endl;
		add(world, firstCity, secondCity, road);
	}

	int numberOfCapitals = 0;
	file >> numberOfCapitals;
	cout << "Number of capitals(k): " << numberOfCapitals << endl;

	cout << "Capitals: ";
	for (int i = 1; i <= numberOfCapitals; ++i)
	{
		int capital = 0;
		file >> capital;
		cout << capital << " ";
		addCapital(world, capital, i);
	}
	cout << endl;
	file.close();

	expansionOfCountries(world, numberOfCities, numberOfCapitals);

	printWorld(world, numberOfCapitals);

	deleteGraph(world);
	return 0;
}