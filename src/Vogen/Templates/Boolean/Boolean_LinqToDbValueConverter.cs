﻿
        public class LinqToDbValueConverter : global::LinqToDB.Common.ValueConverter<VOTYPE, bool>
        {
            public LinqToDbValueConverter()
                : base(
                      v => v.Value,
                      p => new VOTYPE(p),
                      handlesNulls: false)
            { }
        }