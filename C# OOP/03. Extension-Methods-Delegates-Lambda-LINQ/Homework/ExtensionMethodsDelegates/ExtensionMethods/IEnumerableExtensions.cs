using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods
{
    public static class IEnumerableExtensions
    {
        //extension method for calculating the sum of elements of collection        
        public static decimal Sum<T>(this IEnumerable<T> collection)
        {
            decimal sum = 0;

            foreach (var item in collection)
            {
                //Since not all data types have predefined operator + the collection elements are first converted to decimal and then added to the sum
                sum += Convert.ToDecimal(item);
            }
        
            return sum;
        }

        //extension method for calculating the product of collection elements       
        public static decimal Product<T>(this IEnumerable<T> collection)
        {
            decimal product = 1;

            foreach (var item in collection)
            {                
                product *= Convert.ToDecimal(item);
            }

            return product;
        }


        //extension method for calculating the element with minumum value in a collection
        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            T min = collection.First();

            foreach (var item in collection)
            {

                if (min.CompareTo(item) > 0)
                {
                    min = item;
                }

            }

            return min;
        }

        //extension method for calculating the element with maximum value in a collection
        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            T max = collection.First();

            foreach (var item in collection)
            {

                if (max.CompareTo(item) < 0)
                {
                    max = item;
                }

            }
            return max;
        }

        

        //extension method for calculating the average of collection        
        public static decimal Average<T>(this IEnumerable<T> collection)
        {
            decimal average = collection.Sum() / collection.Count();            
            return average;
        }

    }
}
