using System;
using System.Collections.Generic;

class Sheets
{
    static void Main()
    {
        List<string> sheets = new List<string>()
        {
            "A10", "A9", "A8", "A7", "A6", "A5", "A4", "A3", "A2", "A1", "A0"
        };
        
        int nPiecesofSizeA10 = int.Parse(Console.ReadLine());
        int powerOf2 = 0;
        string usedSheetSize = "";
        int index;
        for (int position = 0; position < 11; position++)
        {
            int bitOnPosition = GetBitOnPosition(nPiecesofSizeA10, position);
            index = 10 - powerOf2;

            if (bitOnPosition == 1)
            {
                usedSheetSize = "A" + index.ToString();
                sheets.Remove(usedSheetSize);
            }
            powerOf2++;

        }
        foreach (var sheet in sheets)
        {
            Console.WriteLine(sheet);
        }
    }
    public static int GetBitOnPosition(int number, int position)
    {
        int bitOnPosition = (number & (1 << position)) >> position;
        return bitOnPosition;
    }
}