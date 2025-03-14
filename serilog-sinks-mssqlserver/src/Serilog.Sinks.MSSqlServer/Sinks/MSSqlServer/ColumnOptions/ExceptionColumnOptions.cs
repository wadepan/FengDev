﻿using System;
using System.Data;

namespace Serilog.Sinks.MSSqlServer
{
    public partial class ColumnOptions // Standard Column options are inner classes for backwards-compatibility.
    {
        /// <summary>
        /// Options for the Exception column.
        /// </summary>
        public class ExceptionColumnOptions : SqlColumn
        {
            /// <summary>
            /// Constructor.
            /// </summary>
            public ExceptionColumnOptions() : base()
            {
                StandardColumnIdentifier = StandardColumn.Exception;
                DataType = SqlDbType.NVarChar;
            }

            /// <summary>
            /// The Exception column defaults to NVarChar and must be of a character-storage data type.
            /// </summary>
            public new SqlDbType DataType
            {
                get => base.DataType;
                set
                {
                    if (!SqlDataTypes.VariableCharacterColumnTypes.Contains(value))
                        throw new ArgumentException("The Standard Column \"Exception\" must be NVarChar or VarChar.");
                    base.DataType = value;
                }
            }
        }
    }
}
