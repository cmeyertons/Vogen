using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;

namespace Vogen.Generators.Conversions
{
    internal class GenerateOrleansConversions : IGenerateConversionPartialClass
    {
        public Vogen.Conversions Type => Vogen.Conversions.OrleansConverter;

        public string GenerateAnyPartialClass(TypeDeclarationSyntax tds, VoWorkItem item)
        {
            var voDef = Util.GenerateDefinitionFor(tds);

            var code = new StringBuilder(ResolveTemplate(item))
                .Replace("VODEF", voDef)
                .Replace("VOTYPE", item.VoTypeName)
                .Replace("VOUNDERLYINGTYPE", item.UnderlyingTypeFullName)
            ;

            return code.ToString();
        }

        private static string ResolveTemplate(VoWorkItem item) =>
            Templates.TryGetForSpecificType(item.UnderlyingType, "OrleansConverter") ??
            Templates.GetForAnyType("OrleansConverter");
    }
}
