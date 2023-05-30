using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Vogen.Generators.Conversions;

internal class GenerateLinqToDbConversions : IGenerateConversionBody
{
    public Vogen.Conversions Type => Vogen.Conversions.LinqToDbValueConverter;

    public string GenerateAnyBody(TypeDeclarationSyntax tds, VoWorkItem item)
    {
        string code =
            Templates.TryGetForSpecificType(item.UnderlyingType, "LinqToDbValueConverter") ??
            Templates.GetForAnyType("LinqToDbValueConverter");

        code = code.Replace("VOTYPE", item.VoTypeName);
        code = code.Replace("VOUNDERLYINGTYPE", item.UnderlyingTypeFullName);

        return code;
    }
}