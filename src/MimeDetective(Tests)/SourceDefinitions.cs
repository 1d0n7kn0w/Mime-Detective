﻿using System;

namespace MimeDetective.Tests;

public static class SourceDefinitions {

    public static string DefinitionRoot() {
        var Profile = System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        var Folder = $@"{Profile}\Downloads\defs_xml";

        return Folder;
    }

}