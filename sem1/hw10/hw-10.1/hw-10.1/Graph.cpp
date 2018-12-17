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

void expansionOfCountries(World *world, int numberOfCities, int numberOfCapitals)
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

void addNewCityToCountry(World *world, int numberOfCountry, int &countOfAccessions)
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