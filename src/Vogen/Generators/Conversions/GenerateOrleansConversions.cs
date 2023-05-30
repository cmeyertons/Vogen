using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Vogen.Generators.Conversions
{
    internal class GenerateOrleansConversions : IGenerateConversionPartialClass
    {
        public Vogen.Conversions Type => Vogen.Conversions.OrleansConverter;

        public string GenerateAnyPartialClass(TypeDeclarationSyntax tds, VoWorkItem item)
        {


            return string.Empty;
        }
    }
}
