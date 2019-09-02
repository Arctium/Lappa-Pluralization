// Copyright (C) Arctium.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;

namespace Lappa.Pluralization
{
    class PluralizationSettings
    {
        public List<string> Exceptions { get; } = new List<string>();

        public Dictionary<string, string> IrregularWords { get; } = new Dictionary<string, string>()
        {
            // -is
            ["axis"] = "axes", ["analysis"] = "analyses", ["basis"] = "bases",
            ["diagnosis"] = "diagnoses", ["ellipsis"] = "ellipses", ["hypothesis"] = "hypotheses",
            ["synthesis"] = "syntheses", ["synopsis"] = "synopses", ["thesis"] = "theses",
            // -ix
            ["appendix"] = "appendices", ["index"] = "indices", ["matrix"] = "matrices",
            // other
            ["child"] = "children" ,["man"] = "men", ["ox"] = "oxen",
            ["woman"] = "women", ["person"] = "persons",
        };

        public List<string> NonChangingWords { get; } = new List<string>()
        {
            "aircraft", "deer", "fish", "moose", "offspring",
            "sheep", "species", "salmon", "trout", "data", "info",
            "information"
        };
    }
}
