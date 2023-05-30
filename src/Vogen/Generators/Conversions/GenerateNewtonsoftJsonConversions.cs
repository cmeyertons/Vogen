using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Vogen.Generators.Conversions;

internal class GenerateNewtonsoftJsonConversions : IGenerateConversionAttributes, IGenerateConversionBody
{
    public Vogen.Conversions Type => Vogen.Conversions.NewtonsoftJson;

    public string GenerateAnyAttributes(TypeDeclarationSyntax tds, VoWorkItem item)
    {
        return $@"[global::Newtonsoft.Json.JsonConverter(typeof({item.VoTypeName}NewtonsoftJsonConverter))]";
    }

    public string GenerateAnyBody(TypeDeclarationSyntax tds, VoWorkItem item)
    {
        string? code =
            Templates.TryGetForSpecificType(item.UnderlyingType, "NewtonsoftJsonConverter");
        if (code is null)
        {
            code = item.UnderlyingType.IsValueType ? Templates.GetForAnyType("NewtonsoftJsonConverterValueType") : Templates.GetForAnyType("NewtonsoftJsonConverterReferenceType");
        }

        code = code.Replace("VOTYPE", item.VoTypeName);
        code = code.Replace("VOUNDERLYINGTYPE", item.UnderlyingTypeFullName);

        return code;
    }
}