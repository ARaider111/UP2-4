using System;
using System.Collections.Generic;

class RomanNumber
{
  public char Roman {get; set;}
  public int Arabic {get; set;}

  public static List<RomanNumber> Alphabet = new List<RomanNumber>()
  {
      new RomanNumber {Roman = 'I', Arabic = 1},
      new RomanNumber {Roman = 'V', Arabic = 5},
      new RomanNumber {Roman = 'X', Arabic = 10},
      new RomanNumber {Roman = 'L', Arabic = 50},
      new RomanNumber {Roman = 'C', Arabic = 100},
      new RomanNumber {Roman = 'D', Arabic = 500},
      new RomanNumber {Roman = 'M', Arabic = 1000}
  };
  
  public static int ConvertRomanToArabic(string roman,  int countRoman)
  {
    int arabic = 0;
    int previousValue = 0;
    int currentValue = 1001;
    for (int i = 0; i < countRoman; ++i)
    {
      foreach (var romanNumber in Alphabet)
      {
        if (romanNumber.Roman == roman[i])
        {
          previousValue = romanNumber.Arabic;
          break;
        }
      }

      if (previousValue <= currentValue)
      {
        arabic += previousValue;
      }
      else if ((previousValue == 5 && currentValue == 1) || (previousValue == 10 && currentValue == 1) || (previousValue == 50 && currentValue == 10) || (previousValue == 100 && currentValue == 10) || (previousValue == 500 && currentValue == 100) || (previousValue == 1000 && currentValue == 100))
      {
        arabic = Math.Abs(arabic - previousValue);
      }
      else
      {
        return 0;
      }
      
      currentValue= previousValue;
    }
    return arabic;
  }
}

class Program
{
  public const int maxRomanLength = 7;
  
  public static bool CheckRomanNumbers(string roman, List<RomanNumber> Alphabet)
  {
    if (roman.Contains("IIII") || roman.Contains("VV") || roman.Contains("XXXX") || roman.Contains("LL") || roman.Contains("CCCC") || roman.Contains("DD"))
    {
      return false;
    }
    
    for (int i = 0; i < roman.Length; ++i)
    {
      bool isRealRoman = false;
      for (int j = 0; j < maxRomanLength; ++j)
      {
        if (roman[i] == Alphabet[j].Roman)
        {
          isRealRoman = true;
          break;
        }
      }
      if (!isRealRoman)
      {
        return false;
      }
    }
    return true;
  }
  
  public static void Main(string[] args)
  {
    bool isRoman = false;
    string line = "";
    do
    {
      Console.WriteLine("Введите римское число (все буквы английские заглавные): ");
      line = Console.ReadLine();
      isRoman = CheckRomanNumbers(line, RomanNumber.Alphabet);

    } while (!isRoman);

    int maxRomanLength = line.Length;
    int arabicNumbers = RomanNumber.ConvertRomanToArabic(line, maxRomanLength);
    if (arabicNumbers != 0)
    {
      Console.WriteLine(arabicNumbers);
    }
    else
    {
      Console.WriteLine("Неккоректный ввод!");
    }
  }
}