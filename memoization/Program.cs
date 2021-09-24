using System;
using System.Collections.Generic;

namespace memoization
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Hello World!");
        }
        public Func<string, string> WithOneInput = Memoizer.Memoize((string x) =>
        {
            return String.Format("Hello, {0}", x);
        });

    }
    class Memoizer
    {
        static Func<T, R> Memomize<T, R>(Func<T, R> func) where T : IComparable
        {
            Dictionary<T, R> Cashe = new Dictionary<T, R>();
            return arg =>
            {
                if (Cashe.ContainsKey(arg))
                {
                    return Cashe[arg];
                }
                return (Cashe[arg] = func(arg));
            };
        }
        /// <summary>
        /// Memoization with no input is caching only a single value, 
        /// but still worthwhile if the value is costly to compute.
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Func<TReturn> Memoize<TReturn>(Func<TReturn> func)
        {
            object cache = null;
            return () =>
            {
                if (cache == null)
                    cache = func();
                return (TReturn)cache;
            };
        }
        /// <summary>
        /// When we have more than one input value, we have to compute a reasonable key for the dictionary.
        /// I opted to use the concatenation of the object hash codes as that seems like a reasonable approach. 
        /// If there’s a better way I’d like to hear your input.
        /// </summary>
        /// <typeparam name="TSource1"></typeparam>
        /// <typeparam name="TSource2"></typeparam>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Func<TSource1, TSource2, TReturn> Memoize<TSource1, TSource2, TReturn>(Func<TSource1, TSource2, TReturn> func)
        {
            var cache = new Dictionary<string, TReturn>();
            return (s1, s2) =>
            {
                var key = s1.GetHashCode().ToString() + s2.GetHashCode().ToString();
                if (!cache.ContainsKey(key))
                {
                    cache[key] = func(s1, s2);
                }
                return cache[key];
            };
        }
        /// <summary>
        /// When we have only one input value, we can use the input object itself as the key into the dictionary cache.
        /// </summary>
        /// <typeparam name="TSource"> Source</typeparam>
        /// <typeparam name="TReturn">Return</typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Func<TSource, TReturn> Memoize<TSource, TReturn>(Func<TSource, TReturn> func)
        {
            var cache = new Dictionary<TSource, TReturn>();
            return s =>
            {
                if (!cache.ContainsKey(s))
                {
                    cache[s] = func(s);
                }
                return cache[s];
            };
        }
    }
}
