﻿using System;
using System.Collections.Immutable;
using System.Text;

namespace MimeDetective.Storage;

/// <summary>
/// The base class representing <see cref="Pattern"/> that exists in the target file.
/// </summary>
public abstract class PatternSegment : Segment {
    /// <summary>
    /// The <see cref="Pattern"/> that must exist in the target file.
    /// </summary>
    public ImmutableArray<byte> Pattern { get; init; } = [];

    protected static ImmutableArray<byte> BytesFromHex(string hexString) {
        const string validCharacters = "0123456789ABCDEF";
        var trimmed = new StringBuilder(hexString.Length);

        hexString = hexString
                .ToUpperInvariant()
                .Replace("0X", "")
            ;

        for (var i = 0; i < hexString.Length; i++) {
            var @char = hexString[i..(i + 1)];

            if (validCharacters.Contains(@char)) {
                trimmed.Append(@char);
            }
        }

        var ret = Convert
                .FromHexString(trimmed.ToString())
                .ToImmutableArray()
            ;

        return ret;
    }

    protected static ImmutableArray<byte> BytesFromText(string text, bool apostropheIsNull = true) {
        if (apostropheIsNull) {
            text = text.Replace("'", "\0");
        }
        var ret = System.Text.Encoding.UTF8
                .GetBytes(text)
                .ToImmutableArray()
            ;

        return ret;
    }

    public override string? GetDebuggerDisplay() {
        var hex = System.Convert.ToHexString([.. Pattern]);
        var @string = System.Text.Encoding.UTF8.GetString([.. Pattern]);
        @string = @string.Replace("\0", "'");

        return $@"{@string} /// {hex}";
    }

    private int? _getHashCodeValue;
    public override sealed int GetHashCode() {

        if (this._getHashCodeValue is not { } v1) {
            v1 = GetHashCodeInternal();
            this._getHashCodeValue = v1;
        }

        return v1;
    }

    protected virtual int GetHashCodeInternal() {
        return EnumerableComparer<byte>.Instance.GetHashCode(Pattern);
    }

}