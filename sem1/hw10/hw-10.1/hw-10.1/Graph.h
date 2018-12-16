#pragma once
#include <vector>

using namespace std;

struct City
{
	vector<int> neighbours;
	int country = 0;
};

struct World
{
	vector<City*> cities;
};

World *createWorld(const int size);

void add(World *world, const int firstCity, const int secondCity, const int road);

void addCapital(World *world, const int capital, int numberOfCountry);

void expansionOfCountries(World *world, int numberOfCities, int numberOfCapitals);

void addNewCityToCountry(World *world, int numberOfCountry);

void deleteGraph(World *graph);