// Copyright (c) Arctium.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Xunit;

namespace Lappa.Pluralization.Tests;

public class UnitTest1
{
    readonly PluralizationService _service = new();

    [Fact]
    public void EndsWithYTest()
    {
        var pluralized = _service.Pluralize("Summary");
        Assert.Equal("Summaries", pluralized);
    }
}
