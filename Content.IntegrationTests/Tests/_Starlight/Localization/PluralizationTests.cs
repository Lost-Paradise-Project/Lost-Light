using System.Globalization;
using Content.IntegrationTests.Fixtures;
using Robust.Shared.Localization;

namespace Content.IntegrationTests.Tests._Starlight.Localization;

[TestFixture]
public sealed class PluralizationTests : GameTest
{
    [Test]
    [TestCase(3, "cow", "There were 3 cows.")]
    [TestCase(3, "thief", "There were 3 thieves.")]
    [TestCase(3, "carp", "There were 3 carp.")]
    public async Task EORPluralizationTest(int count, string antag, string expected)
    {
        var pair = Pair;
        var server = pair.Server;

        var locMan = server.ResolveDependency<ILocalizationManager>();

        // LP edit start - основной язык у нас ru-RU, а MAKEPLURAL есть только в английской локали
        var culture = locMan.DefaultCulture!;
        locMan.DefaultCulture = new CultureInfo("en-US");
        string result;
        try
        {
            result = locMan.GetString("objectives-round-end-result", ("count", count), ("agent", antag));
        }
        finally
        {
            locMan.DefaultCulture = culture;
        }
        // LP edit end

        Assert.That(result, Is.EqualTo(expected));
    }
}
