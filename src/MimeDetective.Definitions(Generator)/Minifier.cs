using Microsoft.VisualStudio.TestTools.UnitTesting;
using MimeDetective.Storage;
using System.Collections.Immutable;

namespace MimeDetective.Definitions;

[TestClass]
public class Minifier {


    [TestMethod]
    public void Minify() {
        var A = new PrefixSegment() {
            Start = 1,
            Pattern = new byte[] { 2, 3, 4, 5, 6, 7, 8, 9, 10 }.ToImmutableArray()
        };

        var B = new PrefixSegment() {
            Start = 2,
            Pattern = new byte[] { 3, 4, 0, 0, 7, 8, 9 }.ToImmutableArray()
        };

        var Data = DefinitionExtensions.Intersection(A, B);

        Data.Equals(Data);

    }

}