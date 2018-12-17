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

//Creates new graph
World *createWorld(const int size);

//Adds edge between two nodes of graph
void add(World *world, const int firstCity, const int secondCity, const int road);

//Marks the given city as a capital of the country
void addCapital(World *world, const int capital, const int numberOfCountry);

//Adds nearest unoccupied cities to the countries until all the cities are distributed
void expansionOfCountries(World *world, int numberOfCities, int numberOfCapitals);

//Used in expansionOfCountries function
void addNewCityToCountry(World *world, int numberOfCountry, int &countOfAccessions);

//Deletes graph
void deleteGraph(World *graph);