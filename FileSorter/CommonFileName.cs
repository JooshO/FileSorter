using System;
using System.Collections.Generic;
using System.Linq;

namespace FileSorter
{
    public class CommonFileName
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="word">The string to find all substrings from</param>
        /// <returns></returns>
        public static IEnumerable<string> GetAllSubstrings(string word)
        {
            return from charIndex1 in Enumerable.Range(0, word.Length)
                   from charIndex2 in Enumerable.Range(0, word.Length - charIndex1 + 1)
                   where charIndex2 > 0
                   select word.Substring(charIndex1, charIndex2);
        }

        /// <summary>
        /// Returns the longest substring of at least length l present in at least k strings
        /// TODO: This works but it will lead to slowdown later on large lists
        /// </summary>
        /// <param name="list">The list of strings to find the substring in</param>
        /// <param name="k"> The minimum number of strings it must be present in</param>
        /// <param name="l"> The minimum length of the longest substring </param>
        /// <returns></returns>
        public static string LongestSubstring(List<string> list, int k, int l)
        {
            // if k is greater than the number of elements in the list, set k equal to the count
            // this way we don't overshoot the list
            k = k > list.Count() ? list.Count : k;
         
            // get all substrings of all elements
            // yes it's ineffecient
            // yes it can get very slow
            // no I don't know a better way
            IEnumerable<string> substrings = GetAllSubstrings(list.First());
            foreach (string s in list.Skip(1))
            {
                substrings = substrings.Concat(GetAllSubstrings(s));
            }

            substrings = substrings.OrderByDescending(s => s.Length).Where(s => s.Length >= l);

            string longestCommonIntersection = string.Empty;

            // for each substr in descending order of lenght
            foreach (string subStr in substrings)
            {
                var allContains = list.Where(s => s.Contains(subStr));

                // return the substr if at least k elements contain it
                if (allContains.Count() >= k)
                {
                    longestCommonIntersection = subStr;
                    break;
                }
            }

            return longestCommonIntersection;
        }

    }
}
