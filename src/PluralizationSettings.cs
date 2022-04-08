// Copyright (c) Arctium.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Lappa.Pluralization;

internal class PluralizationSettings
{
    public List<string> Exceptions { get; } = new();

    public Dictionary<string, string> IrregularWords { get; } = new()
    {
        // -is
        ["axis"] = "axes", ["analysis"] = "analyses", ["basis"] = "bases",
        ["diagnosis"] = "diagnoses", ["ellipsis"] = "ellipses", ["hypothesis"] = "hypotheses",
        ["synthesis"] = "syntheses", ["synopsis"] = "synopses", ["thesis"] = "theses",
        // -ix
        ["appendix"] = "appendices", ["index"] = "indices", ["matrix"] = "matrices",
        // other
        ["child"] = "children", ["man"] = "men", ["ox"] = "oxen",
        ["woman"] = "women", ["person"] = "persons"
    };

    public List<string> NonChangingWords { get; } = new()
    {
        "aircraft", "deer", "fish", "moose", "offspring",
        "sheep", "species", "salmon", "trout", "data", "info",
        "information"
    };
}
