﻿using System;

class EscapeQuotedStrings
{
    static void Main()
    {
        string stringOne = @"The ""use"" of quotations causes difficulties.";
        string stringTwo = "The \"use\" of quotations causes difficulties.";
        Console.WriteLine(stringOne);
        Console.WriteLine(stringTwo);
    }
}
