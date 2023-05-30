using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace Vogen.Generators.Conversions;

/// <summary>
/// Generates attributes decorated on the vogen object
/// </summary>
public interface IGenerateConversionAttributes : IGenerateConversion
{
    string GenerateAnyAttributes(TypeDeclarationSyntax tds, VoWorkItem item);
}

/// <summary>
/// Generates code inside the body of the vogen object
/// </summary>
public interface IGenerateConversionBody : IGenerateConversion
{
    string GenerateAnyBody(TypeDeclarationSyntax tds, VoWorkItem item);
}

/// <summary>
/// Generates a new partial class declaration below the vogen object's main declaration
/// </summary>
public interface IGenerateConversionPartialClass : IGenerateConversion
{
    string GenerateAnyPartialClass(TypeDeclarationSyntax tds, VoWorkItem item);
}

public interface IGenerateConversion
{
    Vogen.Conversions Type { get; }
}

public static class IGenerateConversionExtensions
{
    public static IEnumerable<T> WhereOurs<T>(this IEnumerable<T> conversions, VoWorkItem vo) where T : IGenerateConversion
    {
        foreach (var conversion in conversions)
        {
            if (conversion.IsOurs(vo))
            {
                yield return conversion;
            }
        }
    }

    public static bool IsOurs(this IGenerateConversion conversion, VoWorkItem vo)
    {
        return vo.Conversions.HasFlag(conversion.Type);
    }
}