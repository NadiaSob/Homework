all: Task-6.3

Task-6.3: Main.o Stack.o ShuntingYardAlgorithm.o

Main.o: Main.cpp ShuntingYardAlgorithm.h
	g++ -c Main.cpp

Stack.o: Stack.cpp Stack.h
	g++ -c Stack.cpp

ShuntingYardAlgorithm.o: ShuntingYardAlgorithm.cpp ShuntingYardAlgorithm.h Stack.h
	g++ -c ShuntingYardAlgorithm.cpp

clean: 
	rm -rf *.o Task-6.3