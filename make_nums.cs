using System;
using System.Text.RegularExpressions;

public class Program
{
    /// <summary>
    /// entry point
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {

        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");

        var nums = ParseNumbers("1-4, 7, 8, 9-40");
        foreach (var n in nums)
        {
            Console.WriteLine(n);
        }
    }

    #region Trim White Space
    /// <summary>
    /// Trim white space
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string TrimAllWithInplaceCharArray(string str)
    {

        var len = str.Length;
        var src = str.ToCharArray();
        int dstIdx = 0;

        for (int i = 0; i < len; i++)
        {
            var ch = src[i];

            switch (ch)
            {
                case '\u0020':
                case '\u00A0':
                case '\u1680':
                case '\u2000':
                case '\u2001':
                case '\u2002':
                case '\u2003':
                case '\u2004':
                case '\u2005':
                case '\u2006':

                case '\u2007':
                case '\u2008':
                case '\u2009':
                case '\u200A':
                case '\u202F':

                case '\u205F':
                case '\u3000':
                case '\u2028':
                case '\u2029':
                case '\u0009':

                case '\u000A':
                case '\u000B':
                case '\u000C':
                case '\u000D':
                case '\u0085':
                    continue;

                default:
                    src[dstIdx++] = ch;
                    break;
            }
        }
        return new string(src, 0, dstIdx);
    }
    #endregion

    #region  ParseNumbers
    public static IEnumerable<int> ParseNumbers(string numbers)
    {
        numbers = TrimAllWithInplaceCharArray(numbers);
        if (string.IsNullOrEmpty(numbers))
            yield break;

        string[] numberStrings = numbers.Split(',');
        foreach (var n in numberStrings)
        {
            if (Regex.IsMatch(n, "^[0-9]{1,}$"))
            {
                yield return int.Parse(n);
            }
            else if (Regex.IsMatch(n, "^[0-9]{1,}-[0-9]{1,}$"))
            {
                var nums = n.Split('-');
                foreach (var nn in Enumerable.Range(int.Parse(nums[0]), int.Parse(nums[1]) - int.Parse(nums[0]) + 1))
                {
                    yield return nn;
                }
            }
        }
    }
    #endregion
}
