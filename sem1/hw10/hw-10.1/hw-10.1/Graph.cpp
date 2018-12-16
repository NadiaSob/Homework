#include <vector>
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
	world->cities[firstCity]->neighbours[secondCity] = road;
	world->cities[secondCity]->neighbours[firstCity] = road;
}

void addCapital(World *world, const int capital, int numberOfCountry)
{
	world->cities[capital]->country = numberOfCountry;
}

void expansionOfCountries(World *world, int numberOfCities, int numberOfCapitals)
{
	int temp = 0;
	while (temp < numberOfCities - numberOfCapitals)
	{
		for (int i = 0; i < numberOfCapitals; ++i)
		{
			if (temp < numberOfCities - numberOfCapitals)
			{
				addNewCityToCountry(world, i);
				++temp;
			}
		}
	}
}

void addNewCityToCountry(World *world, int numberOfCountry)
{
	int minRoad = 10000; //
	int newCity = 0;
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
	world->cities[newCity]->country = numberOfCountry;
}

void deleteGraph(World *graph)
{
	delete graph;
}