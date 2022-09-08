using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core;

[TestClass]
public class AlpabethicalComparerTest
{
    [TestMethod]
    public void AlpabethicalSorting()
    {
        var testCases = new List<TestCase> {
            new TestCase(new List<string>{ null }, new string[]{ null }),
            new TestCase(
                new List<string>{ "", "abc", "123", "_123", "_abc", "abc10", "abc9" },
                new string[]{ "", "_123", "_abc", "123", "abc", "abc9", "abc10" }),
            new TestCase(
                new List<string>{ "#1", "$1", "1", "_1" },
                new string[]{ "_1", "#1", "$1", "1" }),
        };

        foreach (var testCase in testCases)
        {
            var result = testCase.Input.OrderBy(s => s, new AlpabethicalComparer())
                .ToArray();
            var result2 = testCase.Input.OrderBy(s => s)
                .ToArray();

            Assert.IsTrue(result.Count() == testCase.Expected.Count());

            for (var i = 0; i < result.Count(); i++)
            {
                Assert.IsTrue(string.Equals(result[i], testCase.Expected[i]));
            }
        }
    }

    private record TestCase(IEnumerable<string> Input, string[] Expected);
}


