# IntelligentSystems

## Description

This repository contains several projects related to intelligent systems algorithms. Namely, the capabilities of the following algorithms are demonstrated:

- expert system;
- ID3 algorithm;
- clustering based on the k-means method;
- clustering based on vector analysis;
- the use of the evaluation function for decision-making.

## Expert system

Realization of an expert system, with the following main functions:

- formation of a knowledge base (classes and their characteristics);
- formation of expected answers based on the characteristics selected by the user and the generated knowledge base;
- saving the knowledge base to a file;
- opening a knowledge base from a file;

<img src="./_documentation/es.png?raw=true" width=600px height="auto" style="border: 1px solid gray"/>

## ID3 algorithm

Classification using the decision tree algorithm implements the following main functions:

- formation of a table of correspondence of attributes and their possible values (attribute {key: value});
- filling in the table of initial data;
- coding of source data, output of a table of encoded data;
- building a decision tree based on initial data;
- saving the correspondence table and initial data to a file;
- loading the correspondence table and source data from the file.

<img src="./_documentation/id3.png?raw=true" width=600px height="auto" style="border: 1px solid gray"/>

## K-means

Solving the clustering problem using the K-means algorithm. Key features:

- formation of a table of objects and their attributes (0 - absence of a feature, 1 - presence of a feature);
- selection of the number of formed classes;
- performing clustering by the k-means algorithm based on the data entered by the user;
- displaying the stages of clustering;
- saving the table of initial objects and their attributes to a file;
- loading a table of initial objects and their attributes from a file;

<img src="./_documentation/km.png?raw=true" width=600px height="auto" style="border: 1px solid gray"/>

<img src="./_documentation/km-s1.png?raw=true" width=600px height="auto" style="border: 1px solid gray"/>

<img src="./_documentation/km-g1.png?raw=true" width=600px height="auto" style="border: 1px solid gray"/>

## Vector analysis

Solving the clustering problem using the K-means algorithm. A measure of the similarity-difference of two objects can be the cosine of the angle between the vectors directed to these points from the origin. By measuring the angle, we can assess the similarity of objects. It is most convenient to calculate the angle in geometry using the cosine formula. Key features:

- formation of a table of objects and their attributes (0 - absence of a feature, 1 - presence of a feature);
- selection of the number of formed classes;
- performing clustering by the vector analysis algorithm based on the data entered by the user;
- displaying the stages of clustering;
- saving the table of initial objects and their attributes to a file;
- loading a table of initial objects and their attributes from a file;

<img src="./_documentation/km-s2.png?raw=true" width=600px height="auto" style="border: 1px solid gray"/>

## Evaluation function for decision-making

Using the scoring function to make decisions on the example of game in 15 (in our case, only 9 cells are used). The main functions of the program:

- formation by the user of the initial data matrix (numbers from 0 to 8);
- formation by the user of the target data matrix (numbers from 0 to 8);
- selection of objective function coefficients;
- making decisions based on the evaluation function, input data and expected result;
- displaying the stages of decision-making in the form of a tree;
- saving the decision tree to a separate file.

<img src="./_documentation/15_1.png?raw=true" width=600px height="auto" style="border: 1px solid gray"/>

<img src="./_documentation/15_2.png?raw=true" width=600px height="auto" style="border: 1px solid gray"/>
