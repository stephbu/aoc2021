# Day 1
As with other AOC events, Day 1 is about getting oriented again.  
Created some scaffolding for future use - utility classes, project and solution files.

- Puzzle 1 was mainly constructing simple reuseable pieces for loading data from files, and refamiliarizing myself with enumerables, lambda syntax etc.  Comparison was hard-coded against an array for speed.
- Puzzle 2, I took a slightly more LINQ-like approach.  I adapted the data loader a little to make it cleaner for reading directly into LINQ. Created a sliding window generator, where the result is an enumerable of window-sized sets of data. e.g. from the sample A, AA, AAA, AAB, ABB, BBB etc.  A LINQ Where operator made it easy to skip any window smaller than the target size.  Sum operator enabled quick math, then a custom accumulator structure with the aggregate function finished the job.