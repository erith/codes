using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClusterTest
{
    public class ClusterManager
    {
        public string instanceName;

        double CHECK_INTERVAL_SEC = 2;
        double TIMEOUT_SEC = 10;

        public bool isRun = false;

        public ClusterManager(string instanceName)
        {
            this.instanceName = instanceName;
        }

        public void Start()
        {
            isRun = true;

            Init();

            DateTime timeoutIntervalCheck = DateTime.Now;
            DateTime lastcheckIntervalCheck = DateTime.Now;

            Task.Run(() =>
            {
                while(isRun)
                {

                    var now = DateTime.Now;

                    if (now.Subtract(lastcheckIntervalCheck) > TimeSpan.FromSeconds(2))
                    {
                        QueryManager.UpdateLastCheck(this.instanceName);
                        lastcheckIntervalCheck = now;
                        Console.WriteLine("UpdateLastCheck 실행");
                    }
                    

                    if (now.Subtract(timeoutIntervalCheck) > TimeSpan.FromSeconds(5))
                    {
                        Console.WriteLine("TIME OUT from START");
                        QueryManager.SetTimeoutUnavalialbeServers(TimeSpan.FromSeconds(TIMEOUT_SEC));
                        timeoutIntervalCheck = now;
                        Console.WriteLine("SetTimeoutUnavalialbeServers 실행");
                    }

                    
                    //Console.WriteLine(instanceName + "CHECK");

                    var items = QueryManager.GetAvaliableStatus();
                    var cnt = items.Count();
                    if (cnt == 1)
                    {
                        //계속 진행.
                    }
                    else if (cnt >= 2)
                    {
                        if (items.OrderByDescending(m => m.LAST_LOCK).FirstOrDefault().INSTANCE_NAME == this.instanceName)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(1));
                            continue;
                        }
                    }

                    //ACTIVE된 서버가 하나도 없으면.
                    if (!items.Where(n => n.STATUS == "ACTIVE").Any())
                    {
                        ChangeActiveServer();
                    }


                    QueryManager.SetLock(this.instanceName);

                    Console.WriteLine(this.instanceName + "...PROCESS");

                    QueryManager.ReleaseLock(this.instanceName);

                    Thread.Sleep(TimeSpan.FromSeconds(CHECK_INTERVAL_SEC));

                }
            });
        }

        public void Init()
        {
            Console.WriteLine("TIME OUT from INIT");
            QueryManager.UpdateLastCheck(this.instanceName);
            QueryManager.SetTimeoutUnavalialbeServers(TimeSpan.FromSeconds(TIMEOUT_SEC));
            QueryManager.SetStatus(this.instanceName, "STANDBY");

            //ACTIVE 관련 수행            
            ChangeActiveServer();
        }

        public void ChangeActiveServer()
        {
            //
            var servers = QueryManager.GetAvaliableStatus();
            if (servers != null && servers.Any())
            {
                Server readyServer = servers.OrderBy(n => n.PRIORITY).FirstOrDefault();
                Server oldActiveServer = servers.Where(n => n.STATUS == "ACTIVE").FirstOrDefault();

                //ACTIVE 서버가 변경되는 경우
                if (oldActiveServer != null && oldActiveServer.INSTANCE_NAME != readyServer.INSTANCE_NAME)
                {
                    QueryManager.SetStatus(oldActiveServer.INSTANCE_NAME, "STANDBY");
                }

                //기존 ACTIVE서버와 변경될 ACTIVE 서버가 동일합니다.
                if (oldActiveServer != null && oldActiveServer.INSTANCE_NAME == readyServer.INSTANCE_NAME)
                {
                    //아무런 일도 수행하지 않습니다.
                    return;
                }

                if (readyServer.INSTANCE_NAME == this.instanceName)
                {
                    QueryManager.SetStatus(this.instanceName, "ACTIVE");
                }
                else //다른 서버이므로 다른서버로 명령합니다. 서버를 셧다운 하는 경우 발생가능.
                {
                    //서버를 START 시킵니다.
                    //쿼리는 해당서버에서 자동 실행됩니다.
                    QueryManager.SetStatus(readyServer.INSTANCE_NAME, "ACTIVE");
                }
            }
        }

        public void Broke()
        {
            isRun = false;
        }

        public void Stop()
        {
            isRun = false;
            QueryManager.SetStatus(this.instanceName, "SHUTDOWN");
            ChangeActiveServer();
            Console.WriteLine("STOP");
        }
    }
}
