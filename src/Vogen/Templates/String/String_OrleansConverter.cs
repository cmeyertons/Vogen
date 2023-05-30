    VODEF VOTYPE : global::Orleans.Serialization.Codecs.IFieldCodec<VOTYPE>
            , global::Orleans.Serialization.Cloning.IOptionalDeepCopier
            , global::Orleans.Serialization.Cloning.IDeepCopier<VOTYPE>
    {
        void global::Orleans.Serialization.Codecs.IFieldCodec<VOTYPE>.WriteField<TBufferWriter>(ref global::Orleans.Serialization.Buffers.Writer < TBufferWriter > writer, uint fieldIdDelta, global::System.Type expectedType, VOTYPE value)
        {
            global::Orleans.Serialization.Codecs.StringCodec.WriteField(ref writer, fieldIdDelta, value.Value);
        }

        VOTYPE global::Orleans.Serialization.Codecs.IFieldCodec<VOTYPE>.ReadValue<TInput>(ref global::Orleans.Serialization.Buffers.Reader < TInput > reader, global::Orleans.Serialization.WireProtocol.Field field)
        {
            var value = global::Orleans.Serialization.Codecs.StringCodec.ReadValue(ref reader, field);
            return VOTYPE.From(value);
        }
        
        bool global::Orleans.Serialization.Cloning.IOptionalDeepCopier.IsShallowCopyable() => true;

        VOTYPE global::Orleans.Serialization.Cloning.IDeepCopier<VOTYPE>.DeepCopy(VOTYPE input, global::Orleans.Serialization.Cloning.CopyContext context) => input;
    }