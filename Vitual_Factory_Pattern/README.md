# Vitual_Factory_Pattern
Data frames
26.04.2019
Task overview
A data frame is a matrix, where every column has different type. We call a row as an observation, and
column as a feature.
There will be given 2 data frames representations. There will be given 3 different algorithms. Your task is to
write code in such a way, these algorithms works independently from the representation. Code should be
extendable in such a way new representation can be add without changing algorithms’ code.
We store information about people. One observation is in a class Record, where name, surname, gender and
age are stored.
Data frames representations
ListDataFrame
This is just a list of Record class.
FileDataFrame
Data is stored in a file. A memory complexity is O(1). It means only one observation can be stored
in RAM at once. Every line of file is one observation. In line columns are separated by comma. Order is:
name, surname, gender, age.
Algorithms
PrintDataFrame
Print a data frame, one observation in line.
Mode
For a given data frame return a tuple: the first element is which gender is more common and the second one
is a ratio of this more common gender.
ConcatenationWithCondition
This algorithm gets two data frames and one predicate (a function which gets a record and returns bool).
The resulting data frame should be a concatenation of observations from two given data frames, for which
predicate returned true.
The algorithm should be written in such a way it is easy to get every possible representation as a returned value.
What is more, algorithm should not be changed in case of adding new forms of data frame representation to
a program.
For FileDataFrame a result is written to a file.
1
What can you do
You can modify vector classes or add any new classess and interfaces. You cannot modify Main() function.
You cannot use yield expression.
