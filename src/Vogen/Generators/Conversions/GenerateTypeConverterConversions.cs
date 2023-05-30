using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Vogen.Generators.Conversions;

class GenerateTypeConverterConversions : IGenerateConversionAttributes, IGenerateConversionBody
{
    public Vogen.Conversions Type => Vogen.Conversions.TypeConverter;

    public string GenerateAnyAttributes(TypeDeclarationSyntax tds, VoWorkItem item)
    {
        return $@"[global::System.ComponentModel.TypeConverter(typeof({item.VoTypeName}TypeConverter))]";
    }

    public string GenerateAnyBody(TypeDeclarationSyntax tds, VoWorkItem item)
    {
        string code = Templates.TryGetForSpecificType(item.UnderlyingType, "TypeConverter") ??
                       Templates.GetForAnyType("TypeConverter");

        code = code.Replace("VOTYPE", item.VoTypeName);
        return code.Replace("VOUNDERLYINGTYPE", item.UnderlyingTypeFullName);
    }

}