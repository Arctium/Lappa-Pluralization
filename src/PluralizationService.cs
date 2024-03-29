﻿// Copyright (c) Arctium.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Lappa.Pluralization;

// Basic pluralization class. Needs to be extended with more exceptions.
// English nouns supported only.
public class PluralizationService
{
    readonly PluralizationSettings _settings;

    public PluralizationService()
    {
        _settings = new();
    }

    public string Pluralize(string word)
    {
        if (string.IsNullOrEmpty(word))
            return string.Empty;

        if (_settings.Exceptions.Contains(word))
            return word;

        var irregularNoun = _settings.IrregularWords.SingleOrDefault(s => word.AsSpan().EndsWith(s.Key, StringComparison.OrdinalIgnoreCase));

        if (irregularNoun.Key != null)
        {
            var irregularNounIndex = word.Length - irregularNoun.Key.Length;

            return string.Concat(word.AsSpan(irregularNounIndex, irregularNoun.Key.Length), 
                                 word.AsSpan(irregularNounIndex, 1), 
                                 irregularNoun.Value.AsSpan(1));
        }

        if (_settings.NonChangingWords.Any(s => word.AsSpan().EndsWith(s, StringComparison.OrdinalIgnoreCase)))
            return word;

        if (char.IsDigit(word.AsSpan()[^1..][0]))
            return word;

        var wordSpan = word.AsSpan();
        var sSpan = "s".AsSpan();

        if (word.Length >= 2)
        {
            var isVocal = wordSpan[^2] is 'a' or 'e' or 'i' or 'o' or 'u';

            if (wordSpan.EndsWith("y"))
                return string.Concat(isVocal ? wordSpan : wordSpan[..^1], [.. "ies"]);

            if (wordSpan.EndsWith("o"))
                return string.Concat(wordSpan, isVocal ? [.. "oes"] : sSpan);
        }

        if (wordSpan.EndsWith("ies"))
            return word;

        if (wordSpan.EndsWith(sSpan) || wordSpan.EndsWith("x") || wordSpan.EndsWith("ch") || wordSpan.EndsWith("sh"))
            return string.Concat(wordSpan, [.. "es"]);
        
        return string.Concat(wordSpan, sSpan);
    }

    public string Pluralize<T>() => Pluralize(typeof(T));
    public string Pluralize(Type t) => Pluralize(t.Name);

    public void AddException(string word) => _settings.Exceptions.Add(word);
    public void AddIrregularWord(string singular, string irregularPlural) => _settings.IrregularWords[singular] = irregularPlural;
    public void AddNonChangingWord(string word) => _settings.NonChangingWords.Add(word);
}
