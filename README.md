Memoization Library in C#

This repository provides a simple yet powerful implementation of memoization in C#. 
Memoization is a technique used to improve the performance of your programs by caching the results of expensive function calls and reusing those results when the same inputs occur again.

Features
   Single Input Memoization: Cache function results based on a single input value.

   Multiple Inputs Memoization: Cache function results for functions with two input parameters.

   No Input Memoization: Useful for caching the result of a costly computation that doesn't take any input.

Code Overview

Program Class

The Program class includes an example of how to use the memoization library with a single-input function:

public Func<string, string> WithOneInput = Memoizer.Memoize((string x) =>
{
    return String.Format("Hello, {0}", x);
});

Memoizer Class

The Memoizer class contains three static methods for memoization:

  1. Single Input Memoization
  public static Func<TSource, TReturn> Memoize<TSource, TReturn>(Func<TSource, TReturn> func)
  Caches the result based on a single input value.
  Uses a dictionary to store the computed values.

2. Multiple Inputs Memoization
   public static Func<TSource1, TSource2, TReturn> Memoize<TSource1, TSource2, TReturn>(Func<TSource1, TSource2, TReturn> func) 
   Caches the result based on two input values.
   Combines the hash codes of the inputs to create a unique key.

3. No Input Memoization
   public static Func<TReturn> Memoize<TReturn>(Func<TReturn> func)

Benefits

Performance Optimization: Reduces redundant computations.
Flexibility: Supports functions with zero, one, or two inputs.
Ease of Use: Simple to integrate into existing projects.
