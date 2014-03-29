using System;
using System.Collections.Generic;
using System.Linq;

class QueryExpressions
{
    static void Main()
    {
        // Assume we have an array of strings.
        string[] games = {"Morrowind", "BioShock" ,
            "Half Life 2: Episode 1", "The Darkness",
            "Daxter", "System Shock 2"};
            
        // Build a query expression to represent the items
        // in the array that consist of more than 6 letters
        IEnumerable<string> subset =
            from g in games
            where g.Length > 6
            orderby g
            select g;
            
        // Print out the results
        foreach (string s in subset)
        {
            Console.WriteLine("Item: {0}", s);
        }
    }
}
