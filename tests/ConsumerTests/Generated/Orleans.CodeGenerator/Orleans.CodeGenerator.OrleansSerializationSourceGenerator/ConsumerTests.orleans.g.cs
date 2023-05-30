[assembly: global::Orleans.ApplicationPartAttribute("ConsumerTests")]
[assembly: global::Orleans.ApplicationPartAttribute("Orleans.Core.Abstractions")]
[assembly: global::Orleans.ApplicationPartAttribute("Orleans.Serialization")]
[assembly: global::Orleans.ApplicationPartAttribute("Orleans.Core")]
[assembly: global::Orleans.ApplicationPartAttribute("Orleans.Persistence.Memory")]
[assembly: global::Orleans.ApplicationPartAttribute("Orleans.Runtime")]
[assembly: global::Orleans.ApplicationPartAttribute("Orleans.Reminders")]
[assembly: global::Orleans.ApplicationPartAttribute("Orleans.Streaming")]
[assembly: global::Orleans.ApplicationPartAttribute("Orleans.TestingHost")]
[assembly: global::Orleans.Serialization.Configuration.TypeManifestProviderAttribute(typeof(OrleansCodeGen.ConsumerTests.Metadata_ConsumerTests))]
namespace OrleansCodeGen.ConsumerTests.Orleans
{
    using global::Orleans.Serialization.Codecs;
    using global::Orleans.Serialization.GeneratedCodeHelpers;

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("OrleansCodeGen", "7.0.0.0")]
    [global::Orleans.CompoundTypeAliasAttribute("inv", typeof(global::Orleans.Runtime.GrainReference), typeof(global::ConsumerTests.Orleans.ISerializationTestGrain), "BC95D0D1")]
    public sealed class Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1<T> : global::Orleans.Runtime.Request<T>
    {
        public T arg0;
        global::ConsumerTests.Orleans.ISerializationTestGrain target;
        private static readonly global::System.Reflection.MethodInfo MethodBackingField = OrleansGeneratedCodeHelper.GetMethodInfoOrDefault(typeof(global::ConsumerTests.Orleans.ISerializationTestGrain), "Return", new[] { typeof(T) }, new[] { typeof(T) });
        public override int GetArgumentCount() => 1;
        public override string GetMethodName() => "Return<T>";
        public override string GetInterfaceName() => "ConsumerTests.Orleans.ISerializationTestGrain";
        public override string GetActivityName() => "ISerializationTestGrain/Return<T>";
        public override global::System.Type GetInterfaceType() => typeof(global::ConsumerTests.Orleans.ISerializationTestGrain);
        public override global::System.Reflection.MethodInfo GetMethod() => MethodBackingField;
        public override void SetTarget(global::Orleans.Serialization.Invocation.ITargetHolder holder) => target = holder.GetTarget<global::ConsumerTests.Orleans.ISerializationTestGrain>();
        public override object GetTarget() => target;
        public override void Dispose()
        {
            arg0 = default;
            target = default;
        }

        public override object GetArgument(int index)
        {
            switch (index)
            {
                case 0:
                    return arg0;
                default:
                    return OrleansGeneratedCodeHelper.InvokableThrowArgumentOutOfRange(index, 0);
            }
        }

        public override void SetArgument(int index, object value)
        {
            switch (index)
            {
                case 0:
                    arg0 = (T)value;
                    return;
                default:
                    OrleansGeneratedCodeHelper.InvokableThrowArgumentOutOfRange(index, 0);
                    return;
            }
        }

        protected override global::System.Threading.Tasks.ValueTask<T> InvokeInner() => target.Return<T>(arg0);
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("OrleansCodeGen", "7.0.0.0")]
    internal sealed class Proxy_ISerializationTestGrain : global::Orleans.Runtime.GrainReference, global::ConsumerTests.Orleans.ISerializationTestGrain
    {
        public Proxy_ISerializationTestGrain(global::Orleans.Runtime.GrainReferenceShared arg0, global::Orleans.Runtime.IdSpan arg1) : base(arg0, arg1)
        {
        }

        global::System.Threading.Tasks.ValueTask<T> global::ConsumerTests.Orleans.ISerializationTestGrain.Return<T>(T arg0)
        {
            var request = new OrleansCodeGen.ConsumerTests.Orleans.Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1<T>();
            using var copyContext = base.CopyContextPool.GetContext();
            request.arg0 = copyContext.DeepCopy(arg0);
            return base.InvokeAsync<T>(request);
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("OrleansCodeGen", "7.0.0.0")]
    public sealed class Codec_StringHolder : global::Orleans.Serialization.Codecs.IFieldCodec<global::ConsumerTests.Orleans.StringHolder>, global::Orleans.Serialization.Serializers.IValueSerializer<global::ConsumerTests.Orleans.StringHolder>
    {
        private readonly global::System.Type _codecFieldType = typeof(global::ConsumerTests.Orleans.StringHolder);
        private readonly global::System.Type _type0 = typeof(global::ConsumerTests.Orleans.StringValueObject);
        private readonly global::Orleans.Serialization.Codecs.IFieldCodec<global::ConsumerTests.Orleans.StringValueObject> _codec0;
        private static readonly global::Orleans.Serialization.Utilities.ValueTypeSetter<global::ConsumerTests.Orleans.StringHolder, global::ConsumerTests.Orleans.StringValueObject> setField0 = (global::Orleans.Serialization.Utilities.ValueTypeSetter<global::ConsumerTests.Orleans.StringHolder, global::ConsumerTests.Orleans.StringValueObject>)global::Orleans.Serialization.Utilities.FieldAccessor.GetValueSetter(typeof(global::ConsumerTests.Orleans.StringHolder), "<VO>k__BackingField");
        public Codec_StringHolder(global::Orleans.Serialization.Serializers.ICodecProvider codecProvider)
        {
            _codec0 = OrleansGeneratedCodeHelper.GetService<global::Orleans.Serialization.Codecs.IFieldCodec<global::ConsumerTests.Orleans.StringValueObject>>(this, codecProvider);
        }

        [global::System.Runtime.CompilerServices.MethodImplAttribute(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public void Serialize<TBufferWriter>(ref global::Orleans.Serialization.Buffers.Writer<TBufferWriter> writer, scoped ref global::ConsumerTests.Orleans.StringHolder instance)
            where TBufferWriter : global::System.Buffers.IBufferWriter<byte>
        {
            _codec0.WriteField(ref writer, 0U, _type0, instance.VO);
            writer.WriteEndBase();
        }

        [global::System.Runtime.CompilerServices.MethodImplAttribute(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public void Deserialize<TReaderInput>(ref global::Orleans.Serialization.Buffers.Reader<TReaderInput> reader, scoped ref global::ConsumerTests.Orleans.StringHolder instance)
        {
            uint id = 0;
            global::Orleans.Serialization.WireProtocol.Field header = default;
            while (true)
            {
                reader.ReadFieldHeader(ref header);
                if (header.IsEndBaseOrEndObject)
                    break;
                id += header.FieldIdDelta;
                if (id == 0)
                {
                    setField0(ref instance, _codec0.ReadValue(ref reader, header));
                    reader.ReadFieldHeader(ref header);
                }

                reader.ConsumeEndBaseOrEndObject(ref header);
                break;
            }

            id = 0;
            if (header.IsEndBaseFields)
            {
                reader.ReadFieldHeader(ref header);
                reader.ConsumeEndBaseOrEndObject(ref header);
            }
        }

        [global::System.Runtime.CompilerServices.MethodImplAttribute(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public void WriteField<TBufferWriter>(ref global::Orleans.Serialization.Buffers.Writer<TBufferWriter> writer, uint fieldIdDelta, global::System.Type expectedType, global::ConsumerTests.Orleans.StringHolder @value)
            where TBufferWriter : global::System.Buffers.IBufferWriter<byte>
        {
            ReferenceCodec.MarkValueField(writer.Session);
            writer.WriteStartObject(fieldIdDelta, expectedType, _codecFieldType);
            Serialize(ref writer, ref @value);
            writer.WriteEndObject();
        }

        [global::System.Runtime.CompilerServices.MethodImplAttribute(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public global::ConsumerTests.Orleans.StringHolder ReadValue<TReaderInput>(ref global::Orleans.Serialization.Buffers.Reader<TReaderInput> reader, global::Orleans.Serialization.WireProtocol.Field field)
        {
            field.EnsureWireTypeTagDelimited();
            var result = default(global::ConsumerTests.Orleans.StringHolder);
            ReferenceCodec.MarkValueField(reader.Session);
            Deserialize(ref reader, ref result);
            return result;
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("OrleansCodeGen", "7.0.0.0")]
    public sealed class Codec_Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1<T> : global::Orleans.Serialization.Codecs.IFieldCodec<OrleansCodeGen.ConsumerTests.Orleans.Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1<T>>
    {
        private readonly global::System.Type _codecFieldType = typeof(OrleansCodeGen.ConsumerTests.Orleans.Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1<T>);
        private readonly global::System.Type _type0 = typeof(T);
        private readonly global::Orleans.Serialization.Codecs.IFieldCodec<T> _codec0;
        public Codec_Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1(global::Orleans.Serialization.Serializers.ICodecProvider codecProvider)
        {
            _codec0 = OrleansGeneratedCodeHelper.GetService<global::Orleans.Serialization.Codecs.IFieldCodec<T>>(this, codecProvider);
        }

        [global::System.Runtime.CompilerServices.MethodImplAttribute(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public void Serialize<TBufferWriter>(ref global::Orleans.Serialization.Buffers.Writer<TBufferWriter> writer, OrleansCodeGen.ConsumerTests.Orleans.Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1<T> instance)
            where TBufferWriter : global::System.Buffers.IBufferWriter<byte>
        {
            _codec0.WriteField(ref writer, 0U, _type0, instance.arg0);
        }

        [global::System.Runtime.CompilerServices.MethodImplAttribute(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public void Deserialize<TReaderInput>(ref global::Orleans.Serialization.Buffers.Reader<TReaderInput> reader, OrleansCodeGen.ConsumerTests.Orleans.Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1<T> instance)
        {
            uint id = 0;
            global::Orleans.Serialization.WireProtocol.Field header = default;
            while (true)
            {
                reader.ReadFieldHeader(ref header);
                if (header.IsEndBaseOrEndObject)
                    break;
                id += header.FieldIdDelta;
                if (id == 0)
                {
                    instance.arg0 = _codec0.ReadValue(ref reader, header);
                    reader.ReadFieldHeader(ref header);
                }

                reader.ConsumeEndBaseOrEndObject(ref header);
                break;
            }
        }

        [global::System.Runtime.CompilerServices.MethodImplAttribute(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public void WriteField<TBufferWriter>(ref global::Orleans.Serialization.Buffers.Writer<TBufferWriter> writer, uint fieldIdDelta, global::System.Type expectedType, OrleansCodeGen.ConsumerTests.Orleans.Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1<T> @value)
            where TBufferWriter : global::System.Buffers.IBufferWriter<byte>
        {
            if (@value is null)
            {
                ReferenceCodec.WriteNullReference(ref writer, fieldIdDelta);
                return;
            }

            ReferenceCodec.MarkValueField(writer.Session);
            writer.WriteStartObject(fieldIdDelta, expectedType, _codecFieldType);
            Serialize(ref writer, @value);
            writer.WriteEndObject();
        }

        [global::System.Runtime.CompilerServices.MethodImplAttribute(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public OrleansCodeGen.ConsumerTests.Orleans.Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1<T> ReadValue<TReaderInput>(ref global::Orleans.Serialization.Buffers.Reader<TReaderInput> reader, global::Orleans.Serialization.WireProtocol.Field field)
        {
            if (field.IsReference)
                return ReferenceCodec.ReadReference<OrleansCodeGen.ConsumerTests.Orleans.Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1<T>, TReaderInput>(ref reader, field);
            field.EnsureWireTypeTagDelimited();
            var result = new OrleansCodeGen.ConsumerTests.Orleans.Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1<T>();
            ReferenceCodec.MarkValueField(reader.Session);
            Deserialize(ref reader, result);
            return result;
        }
    }

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("OrleansCodeGen", "7.0.0.0")]
    public sealed class Copier_Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1<T> : global::Orleans.Serialization.Cloning.IDeepCopier<OrleansCodeGen.ConsumerTests.Orleans.Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1<T>>
    {
        private readonly global::Orleans.Serialization.Cloning.IDeepCopier<T> _copier0;
        [global::System.Runtime.CompilerServices.MethodImplAttribute(global::System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public OrleansCodeGen.ConsumerTests.Orleans.Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1<T> DeepCopy(OrleansCodeGen.ConsumerTests.Orleans.Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1<T> original, global::Orleans.Serialization.Cloning.CopyContext context)
        {
            if (original is null)
                return null;
            var result = new OrleansCodeGen.ConsumerTests.Orleans.Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1<T>();
            result.arg0 = _copier0.DeepCopy(original.arg0, context);
            return result;
        }

        public Copier_Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1(global::Orleans.Serialization.Serializers.ICodecProvider codecProvider)
        {
            _copier0 = OrleansGeneratedCodeHelper.GetService<global::Orleans.Serialization.Cloning.IDeepCopier<T>>(this, codecProvider);
        }
    }
}

namespace OrleansCodeGen.ConsumerTests
{
    using global::Orleans.Serialization.Codecs;
    using global::Orleans.Serialization.GeneratedCodeHelpers;

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("OrleansCodeGen", "7.0.0.0")]
    internal sealed class Metadata_ConsumerTests : global::Orleans.Serialization.Configuration.ITypeManifestProvider
    {
        public void Configure(global::Orleans.Serialization.Configuration.TypeManifestOptions config)
        {
            config.Serializers.Add(typeof(OrleansCodeGen.ConsumerTests.Orleans.Codec_StringHolder));
            config.Serializers.Add(typeof(OrleansCodeGen.ConsumerTests.Orleans.Codec_Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1<>));
            config.Copiers.Add(typeof(global::Orleans.Serialization.Cloning.ShallowCopier<global::ConsumerTests.Orleans.StringHolder>));
            config.Copiers.Add(typeof(OrleansCodeGen.ConsumerTests.Orleans.Copier_Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1<>));
            config.Copiers.Add(typeof(global::ConsumerTests.Orleans.StringValueObject));
            config.Serializers.Add(typeof(global::ConsumerTests.Orleans.StringValueObject));
            config.InterfaceProxies.Add(typeof(OrleansCodeGen.ConsumerTests.Orleans.Proxy_ISerializationTestGrain));
            config.Interfaces.Add(typeof(global::ConsumerTests.Orleans.ISerializationTestGrain));
            config.InterfaceImplementations.Add(typeof(global::ConsumerTests.Orleans.SerializationTestGrain));
            var n1 = config.CompoundTypeAliases.Add("inv");
            var n2 = n1.Add(typeof(global::Orleans.Runtime.GrainReference));
            var n3 = n2.Add(typeof(global::ConsumerTests.Orleans.ISerializationTestGrain));
            n3.Add("BC95D0D1", typeof(OrleansCodeGen.ConsumerTests.Orleans.Invokable_ISerializationTestGrain_GrainReference_BC95D0D1_1<>));
        }
    }
}