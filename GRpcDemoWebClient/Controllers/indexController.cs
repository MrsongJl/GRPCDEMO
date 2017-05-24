using Grpc.Core;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GRpcDemoWebClient.Controllers
{
    public class indexController : Controller
    {
        // GET: index
        public ActionResult Index()
        {
            //链接对应的服务端
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var result = new GetUserList.GetUserListClient(channel);
            var client = new GetUser.GetUserClient(channel);

            //调用对应方法并传递参数
            var reply = result.GetList(new pharm {Name="1"});
            var reply1 = client.GetFeature(new Point { Latitude = 111, Longitude = 222 });
            //等待计划完成
            channel.ShutdownAsync().Wait();
            //返回页面
            return Content(reply.Userinfo.Name+":"+ reply1.Message);
        }
    }
}