using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Public;
using GrpcDemoWeb.Models;

namespace GrpcDemoWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //启动GRPC服务 使用本地服务的50051端口
            const int Port = 50051;
            Server server = new Server
            {
                Services = {
                    GetUser.BindService(new GetUserActionI()),
                    //GetUserList.BindService(new GetUserI())
                },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
     
            Server server1 = new Server
            {
                Services = {
                   // GetUser.BindService(new GetUserActionI()),
                    GetUserList.BindService(new GetUserI())
                },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };

            server.Start();
            server1.Start();

            //server.ShutdownAsync().Wait();
        }
    }
}
