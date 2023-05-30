using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Vogen.Generators.Conversions;

internal class GenerateEfCoreTypeConversions : IGenerateConversionBody
{
    public Vogen.Conversions Type => Vogen.Conversions.EfCoreValueConverter;

    public string GenerateAnyBody(TypeDeclarationSyntax tds, VoWorkItem item)
    {
        string code =
            Templates.TryGetForSpecificType(item.UnderlyingType, "EfCoreValueConverter") ??
            Templates.GetForAnyType("EfCoreValueConverter");

        code = code.Replace("VOTYPE", item.VoTypeName);
        code = code.Replace("VOUNDERLYINGTYPE", item.UnderlyingTypeFullName);

        return code;
    }
}