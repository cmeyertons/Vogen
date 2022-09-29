﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using LargeTests.SnapshotTests.GenerationTests;
using VerifyTests;
using VerifyXunit;
using Vogen;
using Xunit;

namespace LargeTests.SnapshotTests.PermutationsOfConversions;

public class PermutationsOfConversionsTests
{
    /// <summary>
    /// For different types (class, struct, readonly struct), generate types with different
    /// permutations of conversions to ensure that everything builds OK.
    /// </summary>
    [UsesVerify]
    public class ConversionPermutationTests
    {
        static readonly string[] _permutations = new Permutations().ToArray();
        static readonly string[] _types = {"partial class", "partial struct", "readonly partial struct"};

        // These used to be 'ClassData' tests, but they were run sequentially, which was very slow.
        // This test now runs the permutations in parallel.
        [Fact]
        public async Task CompilesWithAnyCombinationOfConverters()
        {
            var tasks = _types.Select(t => Task.Run(() => Run(t))).ToArray();
            
            await Task.WhenAll(tasks);
        }

        private static async Task Run(string type)
        {
            var typeHash = type.Replace(' ', '-');

            foreach(var conversions in _permutations)
            {
                var settings = new VerifySettings();

                // shorten the filename used
                string parameters = typeHash + Hash(conversions);
                settings.UseFileName(parameters);
#if AUTO_VERIFY
        settings.AutoVerify();
#endif

                await RunTest($@"
  [ValueObject(conversions: {conversions}, underlyingType: typeof(int))]
  public {type} MyIntVo {{ }}", settings);
            }
        }
    }
    
    private static object Hash(string input)
    {
        using var sha1 = SHA1.Create();
        var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));

        //make sure the hash is only alpha numeric to prevent characters that may break the url
        return string.Concat(Convert.ToBase64String(hash).ToCharArray().Where(char.IsLetterOrDigit).Take(10));
    }

    private static async Task RunTest(string declaration, VerifySettings? settings = null)
    {
        var source = $@"using System;
using Vogen;
namespace Whatever
{{
{declaration}
}}";

        var (diagnostics, output) = TestHelper.GetGeneratedOutput<ValueObjectGenerator>(source);

        output.Should().NotBeEmpty();

        diagnostics.Should().BeEmpty();

        await Verifier.Verify(output, settings).UseDirectory(SnapshotUtils.GetSnapshotDirectoryName());
    }    
}