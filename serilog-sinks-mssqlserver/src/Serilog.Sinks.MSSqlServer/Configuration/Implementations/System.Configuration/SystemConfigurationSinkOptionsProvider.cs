﻿using System;
using System.Globalization;
using Serilog.Configuration;

namespace Serilog.Sinks.MSSqlServer.Configuration
{
    internal class SystemConfigurationSinkOptionsProvider : ISystemConfigurationSinkOptionsProvider
    {
        public MSSqlServerSinkOptions ConfigureSinkOptions(MSSqlServerConfigurationSection config, MSSqlServerSinkOptions sinkOptions)
        {
            ReadTableOptions(config, sinkOptions);
            ReadBatchSettings(config, sinkOptions);

            return sinkOptions;
        }

        private static void ReadTableOptions(MSSqlServerConfigurationSection config, MSSqlServerSinkOptions sinkOptions)
        {
            SetProperty.IfProvided<string>(config.TableName, nameof(config.TableName.Value), value => sinkOptions.TableName = value);
            SetProperty.IfProvided<string>(config.SchemaName, nameof(config.SchemaName.Value), value => sinkOptions.SchemaName = value);
            SetProperty.IfProvided<bool>(config.AutoCreateSqlDatabase, nameof(config.AutoCreateSqlDatabase.Value),
                value => sinkOptions.AutoCreateSqlDatabase = value);
            SetProperty.IfProvided<bool>(config.AutoCreateSqlTable, nameof(config.AutoCreateSqlTable.Value),
                value => sinkOptions.AutoCreateSqlTable = value);
            SetProperty.IfProvided<bool>(config.EnlistInTransaction, nameof(config.EnlistInTransaction.Value),
                value => sinkOptions.EnlistInTransaction = value);
        }

        private static void ReadBatchSettings(MSSqlServerConfigurationSection config, MSSqlServerSinkOptions sinkOptions)
        {
            SetProperty.IfProvided<int>(config.BatchPostingLimit, nameof(config.BatchPostingLimit.Value), value => sinkOptions.BatchPostingLimit = value);
            SetProperty.IfProvided<string>(config.BatchPeriod, nameof(config.BatchPeriod.Value), value => sinkOptions.BatchPeriod = TimeSpan.Parse(value, CultureInfo.InvariantCulture));
            SetProperty.IfProvided<bool>(config.EagerlyEmitFirstEvent, nameof(config.EagerlyEmitFirstEvent.Value),
                value => sinkOptions.EagerlyEmitFirstEvent = value);
            SetProperty.IfProvided<bool>(config.UseSqlBulkCopy, nameof(config.UseSqlBulkCopy.Value),
                value => sinkOptions.UseSqlBulkCopy = value);
        }
    }
}
