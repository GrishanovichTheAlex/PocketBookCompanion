using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core;

public class AlpabethicalComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        int retVal;

        if (!string.IsNullOrEmpty(x) && !string.IsNullOrEmpty(y) &&
            x.Any(c => c.IsNuber()) && y.Any(c => c.IsNuber()))
        {
            var x_i = 0;
            var y_i = 0;
            char left;
            char right;

            do
            {
                if (x.Length > x_i)
                    left = x[x_i];
                else
                    left = char.MinValue;

                if (y.Length > y_i)
                    right = y[y_i];
                else
                    right = char.MinValue;

                if (left.IsNuber() && right.IsNuber())
                {
                    var leftNumber = new StringBuilder(string.Empty);
                    var rightNumber = new StringBuilder(string.Empty);

                    do
                    {
                        leftNumber.Append(left);
                        x_i++;

                        left = x_i < x.Length ? x[x_i] : '\0';
                    } while (left.IsNuber());

                    do
                    {
                        rightNumber.Append(right);
                        y_i++;

                        right = y_i < y.Length ? y[y_i] : '\0';
                    } while (right.IsNuber());

                    retVal = int.Parse(leftNumber.ToString()) - int.Parse(rightNumber.ToString());
                }
                else
                {
                    retVal = left - right;
                }

                x_i++;
                y_i++;
            } while (retVal == 0 && (left != char.MinValue || right != char.MinValue));
        }
        else
        {
            retVal = StringComparer.CurrentCultureIgnoreCase.Compare(x, y);
        }

        return retVal;
    }
}

public static class CharExtenshion
{
    public static bool IsNuber(this char c)
    {
        return '0' <= c && c <= '9';
    }
}