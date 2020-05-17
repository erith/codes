using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace ClusterTest
{
    public class QueryManager
    {
        public static string connstr = "Server=Address;Database=DB;Uid=User;Pwd=[PassWord];Allow User Variables=True";

//        public static MySqlConnection conn = new MySqlConnection(connstr);

        public static List<Server> GetAvaliableStatus()
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                return conn.Query<Server>("SELECT * FROM TB_SERVER_LIST WHERE STATUS IN ('STANDBY', 'ACTIVE')").ToList();
            }            
        }



        public static List<Server> GetExistsLock()
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                return conn.Query<Server>("SELECT * FROM TB_SERVER_LIST WHERE LOCK_YN = 'Y'").ToList();
            }                
        }

        public static void SetLock(string instanceName)
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                conn.Execute("UPDATE TB_SERVER_LIST SET LOCK_YN = 'Y', LAST_LOCK = @LAST_LOCK WHERE INSTANCE_NAME = @INSTANCE_NAME", new { LAST_LOCK = DateTime.Now, INSTANCE_NAME = instanceName });
            }            
        }

        public static void ReleaseLock(string instanceName)
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                conn.Execute("UPDATE TB_SERVER_LIST SET LOCK_YN = 'N', LAST_LOCK = @LAST_LOCK WHERE INSTANCE_NAME = @INSTANCE_NAME", new { LAST_LOCK = DateTime.Now, INSTANCE_NAME = instanceName });
            }                
        }

        public static void SetLockAll()
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                conn.Execute("UPDATE TB_SERVER_LIST SET LOCK_YN = 'Y', LAST_LOCK = @LAST_LOCK", new { LAST_LOCK = DateTime.Now });
            }
        }

        public static void ReleaseLockAll()
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                conn.Execute("UPDATE TB_SERVER_LIST SET LOCK_YN = 'N', LAST_LOCK = @LAST_LOCK", new { LAST_LOCK = DateTime.Now });
            }
        }

        public static void SetStatus(string instanceName, string status)
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                conn.Execute("UPDATE TB_SERVER_LIST SET STATUS = @STATUS WHERE INSTANCE_NAME = @INSTANCE_NAME", new { STATUS = status, INSTANCE_NAME = instanceName });
            }                
        }

        public static void UpdateLastCheck(string instanceName)
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                conn.Execute("UPDATE TB_SERVER_LIST SET LAST_CHECK = @LAST_CHECK WHERE INSTANCE_NAME = @INSTANCE_NAME", new { LAST_CHECK = DateTime.Now, INSTANCE_NAME = instanceName });
            }
        }

        public static void SetTimeoutUnavalialbeServers(TimeSpan checkTime)
        {
            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                conn.Execute("UPDATE TB_SERVER_LIST SET STATUS = 'TIMEOUT' WHERE TIMESTAMPDIFF(SECOND, LAST_CHECK, @NOW) > @CHECK AND STATUS IN ('ACTIVE', 'STANDBY')  ", new { NOW = DateTime.Now, CHECK = checkTime.TotalSeconds });
            }
        }

    }

    public class Server
    {
        public string INSTANCE_NAME;
        public string STATUS;
        public string LOCK_YN;
        public string USE_YN;
        public DateTime LAST_LOCK;
        public DateTime LAST_CHECK;
        public int PRIORITY;
    }
}
