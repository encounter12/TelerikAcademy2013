using System;
using System.Text.RegularExpressions;

class ReplaceAnchorsWithPseudoTags
{
    /**
    * Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…[/URL].
    */
    static void Main()
    {

        string text = "<p>Please visit <a href=\"http://academy.telerik.com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

        string processedText = Regex.Replace(text, "<a href=\"(.*?)\">(.*?)</a>", "[URL=$1]$2[/URL]");
        Console.WriteLine(processedText);
    }
}

