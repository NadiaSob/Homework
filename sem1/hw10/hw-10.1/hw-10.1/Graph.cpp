#include <fstream>
#include "Graph.h"

using namespace std;

World *createWorld(const int size)
{
	World *newWorld = new World;
	newWorld->cities.resize(size);
	for (int i = 0; i < size; ++i)
	{
		newWorld->cities[i] = new City;
		newWorld->cities[i]->neighbours.resize(size);
	}
	return newWorld;
}

void add(World *world, const int firstCity, const int secondCity, const int road)
{
	world->cities[firstCity - 1]->neighbours[secondCity - 1] = road;
	world->cities[secondCity - 1]->neighbours[firstCity - 1] = road;
}

void addCapital(World *world, const int capital, const int numberOfCountry)
{
	world->cities[capital - 1]->country = numberOfCountry;
}

void expansionOfCountries(World *world, const int numberOfCities, const int numberOfCapitals)
{
	int countOfAccessions = 0;
	while (countOfAccessions < numberOfCities - numberOfCapitals)
	{
		for (int i = 1; i <= numberOfCapitals; ++i)
		{
			if (countOfAccessions < numberOfCities - numberOfCapitals)
			{
				addNewCityToCountry(world, i, countOfAccessions);
			}
		}
	}
}

void addNewCityToCountry(World *world, const int numberOfCountry, int &countOfAccessions)
{
	int minRoad = 10000000;
	int newCity = -1;
	for (int i = 0; i < world->cities.size(); ++i)
	{
		if (world->cities[i]->country == numberOfCountry)
		{
			City *city = world->cities[i];
			for (int j = 0; j < city->neighbours.size(); ++j)
			{
				if (city->neighbours[j] != 0 && city->neighbours[j] < minRoad && world->cities[j]->country == 0)
				{
					minRoad = city->neighbours[j];
					newCity = j;
				}
			}
		}
	}
	if (newCity != -1)
	{
		world->cities[newCity]->country = numberOfCountry;
		++countOfAccessions;
	}
}

void deleteGraph(World *graph)
{
	for (int i = 0; i < graph->cities.size(); ++i)
	{
		delete graph->cities[i];
	}
	delete graph;
}

bool test()
{
	ifstream file;
	file.open("TestFile.txt");

	int numberOfCities = 0;
	file >> numberOfCities;
	World *testWorld = createWorld(numberOfCities);

	int numberOfRoads = 0;
	file >> numberOfRoads;

	for (int i = 0; i < numberOfRoads; ++i)
	{
		int firstCity = 0;
		int secondCity = 0;
		int road = 0;
		file >> firstCity >> secondCity >> road;
		add(testWorld, firstCity, secondCity, road);
	}

	int numberOfCapitals = 0;
	file >> numberOfCapitals;

	for (int i = 1; i <= numberOfCapitals; ++i)
	{
		int capital = 0;
		file >> capital;
		addCapital(testWorld, capital, i);
	}
	file.close();

	expansionOfCountries(testWorld, numberOfCities, numberOfCapitals);

	int resCountry1 = 2;
	int resCountry2[5] = { 1, 3, 7, 8, 9 };
	int resCountry3[3] = { 4, 5, 6 };

	vector<int> country1;
	vector<int> country2;
	vector<int> country3;

	for (int i = 0; i < testWorld->cities.size(); ++i)
	{
		if (testWorld->cities[i]->country == 1)
		{
			country1.push_back(i + 1);
		}
		if (testWorld->cities[i]->country == 2)
		{
			country2.push_back(i + 1);
		}
		if (testWorld->cities[i]->country == 3)
		{
			country3.push_back(i + 1);
		}
	}

	for (int i = 0; i < country1.size(); ++i)
	{
		if (country1[i] != resCountry1)
		{
			deleteGraph(testWorld);
			return false;
		}
	}

	for (int i = 0; i < country2.size(); ++i)
	{
		if (country2[i] != resCountry2[i])
		{
			deleteGraph(testWorld);
			return false;
		}
	}
	for (int i = 0; i < country3.size(); ++i)
	{
		if (country3[i] != resCountry3[i])
		{
			deleteGraph(testWorld);
			return false;
		}
	}
	deleteGraph(testWorld);
	return true;
}