﻿using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Vogen.Generators;

public class RecordClassGenerator : IGenerateSourceCode
{
    public string BuildClass(VoWorkItem item, TypeDeclarationSyntax tds)
    {
        var className = tds.Identifier;

        var itemUnderlyingType = item.UnderlyingTypeFullName;

        return $@"
using Vogen;

{Util.WriteStartNamespace(item.FullNamespace)}
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage] 
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""{Util.GenerateYourAssemblyName()}"", ""{Util.GenerateYourAssemblyVersion()}"")]
    {Util.GenerateAnyConversionAttributes(tds, item)}
    {Util.GenerateDebugAttributes(item, className, itemUnderlyingType)}
    {Util.GenerateModifiersFor(tds)} record class {className} {Util.GenerateIComparableHeaderIfNeeded(" : ", item, tds)}
    {{
#if DEBUG    
        private readonly global::System.Diagnostics.StackTrace _stackTrace = null;
#endif
        private readonly global::System.Boolean _isInitialized;
        private readonly {itemUnderlyingType} _value;
        
        /// <summary>
        /// Gets the underlying <see cref=""{itemUnderlyingType}"" /> value if set, otherwise a <see cref=""{nameof(ValueObjectValidationException)}"" /> is thrown.
        /// </summary>
        public {itemUnderlyingType} Value
        {{
            [global::System.Diagnostics.DebuggerStepThroughAttribute]
            get
            {{
                EnsureInitialized();
                return _value;
            }}
            [global::System.Diagnostics.DebuggerStepThroughAttribute]
            init
            {{
                {GenerateNullCheckIfNeeded(item)}

                {Util.GenerateNormalizeInputMethodIfNeeded(item)}

                {Util.GenerateValidation(item)}

                _value = value;
            }}
        }}

        [global::System.Diagnostics.DebuggerStepThroughAttribute]
        [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
        public {className}()
        {{
#if DEBUG
            _stackTrace = new global::System.Diagnostics.StackTrace();
#endif
            _isInitialized = false;
            _value = default;
        }}

        [global::System.Diagnostics.DebuggerStepThroughAttribute]
        private {className}({itemUnderlyingType} value)
        {{
            _value = value;
            _isInitialized = true;
        }}

        /// <summary>
        /// Builds an instance from the provided underlying type.
        /// </summary>
        /// <param name=""value"">The underlying type.</param>
        /// <returns>An instance of this type.</returns>
        public static {className} From({itemUnderlyingType} value)
        {{
            {GenerateNullCheckIfNeeded(item)}

            {Util.GenerateNormalizeInputMethodIfNeeded(item)}

            {className} instance = new {className}(value);

            {Util.GenerateValidation(item)}

            return instance;
        }}

        public static explicit operator {className}({itemUnderlyingType} value) => From(value);
        public static explicit operator {itemUnderlyingType}({className} value) => value.Value;

        {Util.GenerateIComparableImplementationIfNeeded(item, tds)}

        // only called internally when something has been deserialized into
        // its primitive type.
        private static {className} Deserialize({itemUnderlyingType} value)
        {{
            {GenerateNullCheckIfNeeded(item)}

            {Util.GenerateNormalizeInputMethodIfNeeded(item)}

            {Util.GenerateCallToValidateForDeserializing(item)}

            return new {className}(value);
        }}

        private void EnsureInitialized()
        {{
            if (!_isInitialized)
            {{
#if DEBUG
                global::System.String message = ""Use of uninitialized Value Object at: "" + _stackTrace ?? """";
#else
                global::System.String message = ""Use of uninitialized Value Object."";
#endif

                throw new {item.ValidationExceptionFullName}(message);
            }}
        }}


        {InstanceGeneration.GenerateAnyInstances(tds, item)}

        // record enumerates fields - we just want our Value and to throw if it's not initialized.
        {Util.GenerateToString(item)}

        {Util.GenerateAnyConversionBodies(tds, item)}

        {Util.GenerateDebuggerProxyForClasses(tds, item)}
    }}{Util.GenerateAnyPartialClasses(tds, item)}
{Util.WriteCloseNamespace(item.FullNamespace)}";
    }

    private static string GenerateNullCheckIfNeeded(VoWorkItem voWorkItem) =>
        voWorkItem.IsValueType ? string.Empty
            : $@"            if (value is null)
            {{
                throw new {voWorkItem.ValidationExceptionFullName}(""Cannot create a value object with null."");
            }}
";
}