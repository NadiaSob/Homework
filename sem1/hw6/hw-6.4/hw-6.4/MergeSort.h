#pragma once

//Sorts list
void mergeSort(List *list, bool byName);

//Merges two sorted lists into one
void mergeLists(List *list, List *list1, List *list2, bool byName);

//Tests mergeSort function
bool test();