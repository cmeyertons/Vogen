using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Vogen.Generators.Conversions;

internal class GenerateDapperConversions : IGenerateConversionBody
{
    public Vogen.Conversions Type => Vogen.Conversions.DapperTypeHandler;

    public string GenerateAnyBody(TypeDeclarationSyntax tds, VoWorkItem item)
    {
        string code =
            Templates.TryGetForSpecificType(item.UnderlyingType, "DapperTypeHandler") ??
            Templates.GetForAnyType("DapperTypeHandler");

        code = code.Replace("VOTYPE", item.VoTypeName);
        code = code.Replace("VOUNDERLYINGTYPE", item.UnderlyingTypeFullName);

        return code;
    }
}