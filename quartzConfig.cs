
            DbProvider.RegisterDbMetadata("MYSQL", new DbMetadata()
            {
                AssemblyName = typeof(MySql.Data.MySqlClient.MySqlConnection).Assembly.GetName().Name,
                ConnectionType = typeof(MySql.Data.MySqlClient.MySqlConnection),
                CommandType = typeof(MySql.Data.MySqlClient.MySqlCommand),
                ParameterType = typeof(MySql.Data.MySqlClient.MySqlParameter),
                ParameterDbType = typeof(MySql.Data.MySqlClient.MySqlDbType),
                ParameterDbTypePropertyName = "DbType",
                ParameterNamePrefix = "@",
                ExceptionType = typeof(MySql.Data.MySqlClient.MySqlException),
                BindByName = true
            });


            // construct a scheduler factory
            NameValueCollection props = new NameValueCollection
            {
                { "quartz.scheduler.instanceId", "AUTO" },
                { "quartz.threadPool.threadCount", "20" },
                { "quartz.serializer.type", "json" },
                { "quartz.jobStore.type", "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz" },
                { "quartz.jobStore.lockHandler.type", "Quartz.Impl.AdoJobStore.UpdateLockRowSemaphore, Quartz"},
                { "quartz.jobStore.driverDelegateType", "Quartz.Impl.AdoJobStore.MySQLDelegate, Quartz"},
                { "quartz.jobStore.tablePrefix", "QRTZ_" },
                { "quartz.jobStore.dataSource", "MYSQL" },
                { "quartz.jobStore.useProperties", "true" },
                { "quartz.jobStore.misfireThreshold", "60000" },
                { "quartz.jobStore.clustered", "true" },
                { "quartz.jobStore.clusterCheckinInterval", "15000" },
                { "quartz.jobStore.acquireTriggersWithinLock", "true" },
                { "quartz.dataSource.MYSQL.provider", "MYSQL" },
                { "quartz.dataSource.MYSQL.connectionString", "Server=192.168.0.xx;Database=xxxx;Uid=root;Pwd=xxxxxx;" },

            };

            StdSchedulerFactory factory = new StdSchedulerFactory(props);
