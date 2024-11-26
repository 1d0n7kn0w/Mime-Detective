﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MimeDetective.Tests;

[TestClass]
public class LookupTests {

    private string _applicationOctetstream = "application/octet-stream";

    [TestMethod]
    public void FileExtension_AllowVariants() {
        var expected = this._applicationOctetstream;

        var v1 = ContentInspectors.Exhaustive.FileExtensionToMimeTypeLookup.TryGetValue("exe");
        var v2 = ContentInspectors.Exhaustive.FileExtensionToMimeTypeLookup.TryGetValue(".exe");
        var v3 = ContentInspectors.Exhaustive.FileExtensionToMimeTypeLookup.TryGetValue("ExE");
        var v4 = ContentInspectors.Exhaustive.FileExtensionToMimeTypeLookup.TryGetValue(".ExE");

        Assert.AreEqual(expected, v1);
        Assert.AreEqual(expected, v2);
        Assert.AreEqual(expected, v3);
        Assert.AreEqual(expected, v4);
    }

    [TestMethod]
    public void MimeType_AllowVariants() {
        var expected = "exe";

        var v1 = ContentInspectors.Exhaustive.MimeTypeToFileExtensionLookup.TryGetValue("application/octet-stream");
        var v2 = ContentInspectors.Exhaustive.MimeTypeToFileExtensionLookup.TryGetValue("application/OCTET-stream");

        Assert.AreEqual(expected, v1);
        Assert.AreEqual(expected, v2);

    }

}