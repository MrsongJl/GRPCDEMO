using Grpc.Core;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GrpcDemoWeb.Models
{
    /// <summary>
    /// 声明服务端调用类
    /// </summary>
    class GetUserActionI : GetUser.GetUserBase
    {
        /// <summary>
        /// 方法名重写的是 声明的服务名称GetFeature
        /// </summary>
        /// <param name="request">接受参数类型 同proto接受参数类型</param>
        /// <param name="context"></param>
        /// <returns></returns>
        // Server side handler of the SayHello RPC
        public override Task<Feature> GetFeature(Point request, ServerCallContext context)
        {
            return Task.FromResult(new Feature { Message = "你好" });
        }

    }
}