namespace CDSPractical 
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The list of questions.
    /// </summary>
    public static class Questions 
    {
        /// <summary>
        /// Given an enumerable of strings, attempt to parse each string and if 
        /// it is an integer, add it to the returned enumerable.
        /// </summary>
        /// <param name="source">An enumerable containing words</param>
        /// <returns>The integers inside the input.</returns>
        public static IEnumerable<int> ExtractNumbers(IEnumerable<string> source)
        {
            foreach (var item in source)
            {
                if (int.TryParse(item, out var result))
                {
                    yield return result;
                }
            }
        }

        /// <summary>
        /// Given two enumerables of strings, finds the longest common word. (case sensitive)
        /// </summary>
        /// <param name="first">First list of words</param>
        /// <param name="second">Second list of words</param>
        /// <returns>The longest common word. (case sensitive)</returns>
        public static string LongestCommonWord(IEnumerable<string> first, IEnumerable<string> second)
        {
            var commonElements = first
                .Join(
                    second, 
                    left => left, 
                    right => right, 
                    (left, right) => left)
                .OrderByDescending(s => s.Length);

            if (!commonElements.Any())
            {
                throw new ArgumentException("No common elements!");
            }

            return commonElements.First();
        }

        /// <summary>
        /// Converts a given distance in kilometers to miles.
        /// </summary>
        /// <param name="km">Distance in kilometers</param>
        /// <returns>The distance in miles.</returns>
        public static double ToMiles(this double km) => km / 1.6;

        /// <summary>
        /// Converts a given distance in miles to kilometers.
        /// </summary>
        /// <param name="miles">Distance in miles</param>
        /// <returns>The distance in kilometers.</returns>
        public static double ToKilometers(this double miles) => miles * 1.6;

        /// <summary>
        /// Indicates whether the input is a palindrome.
        /// </summary>
        /// <param name="word">The word to check</param>
        /// <returns>Whether the word is a palindrome.</returns>
        public static bool IsPalindrome(this string word) => word == new string(word.Reverse().ToArray());

        /// <summary>
        /// Returns a new list of objects containing the shuffled objects from the input.
        /// </summary>
        /// <typeparam name="T"> The type of object to shuffle. </typeparam>
        /// <param name="source"> The objects. </param>
        /// <returns> The shuffled list of objects. </returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            var halfLength = source.Count() / 2;

            var firstHalf = source.Take(halfLength);
            var secondHalf = source.TakeLast(halfLength);
            var middleCharacterIfAny = source.Count() % 2 == 0 ? Enumerable.Empty<T>() : new[] { source.Skip(halfLength).First() };

            var intertwinedHalves = firstHalf
                .Zip(secondHalf.Reverse(), (x, y) => new[] { y, x })
                .Aggregate(Enumerable.Empty<T>(), (l, r) => l.Concat(r));
            var result = intertwinedHalves
                .Take(halfLength)
                .Concat(middleCharacterIfAny)
                .Concat(intertwinedHalves.TakeLast(halfLength));

            return result;
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order
        /// </summary>
        /// <param name="source">The input.</param>
        /// <returns>A new object containing the sorted elements.</returns>
        public static int[] Sort(this int[] source)
        {
            var result = (int[])source.Clone();

            for (var i = 0; i < result.Length; i++)
            {
                var currentMinIndex = i;

                for (var j = i + 1; j < source.Length; j++)
                {
                    if (result[currentMinIndex] > result[j])
                    {
                        currentMinIndex = j;
                    }
                }

                var intermediary = result[i];
                result[i] = result[currentMinIndex];
                result[currentMinIndex] = intermediary;
            }

            return result;
        }

        /// <summary>
        /// Sums all even terms in the Fibonacci sequence that are lower than the .
        /// </summary>
        /// <param name="maximumBound">The maximum value of accepted numbers. </param>
        /// <returns>
        /// The sum.
        /// </returns>
        public static int FibonacciSum(int maximumBound) 
        {
            IEnumerable<int> Fib()
            {
                yield return 1;
                yield return 2;

                var previousNumber = 2;
                var currentNumber = 3;
                while (true)
                {
                    yield return currentNumber;

                    var intermediary = previousNumber;
                    previousNumber = currentNumber;
                    currentNumber += intermediary;
                }
            }

            var sum = 0;
            foreach (var number in Fib().TakeWhile(x => x < maximumBound))
            {
                if (number % 2 == 0)
                {
                    sum += number;
                }
            }

            return sum;
        }

        /// <summary>
        /// Generate a list of integers from 1 to 100.
        /// </summary>
        /// <returns>The list of ints.</returns>
        public static IEnumerable<int> GenerateList(int simulatedDelay = 100)
        {
            void NewFunction(IList<int> targetContainer, int inclusiveStart, int inclusiveFinish)
            {
                for (var i = inclusiveStart; i <= inclusiveFinish; i++)
                {
                    Thread.Sleep(simulatedDelay);
                    targetContainer[i] = i + 1;
                }
            }

            var result = new int[100];

            var actions = new List<Action> { () => NewFunction(result, 0, 49), () => NewFunction(result, 50, 99) };
            Parallel.ForEach(actions, new ParallelOptions { MaxDegreeOfParallelism = 2 }, action => action());

            return result;
        }
    }
}
