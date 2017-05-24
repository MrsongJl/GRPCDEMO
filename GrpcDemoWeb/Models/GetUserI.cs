using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Public;
using Grpc.Core;
using System.Threading.Tasks;

namespace GrpcDemoWeb.Models
{
    public class GetUserI:GetUserList.GetUserListBase
    {
        public override Task<Userlist> GetList(pharm request, ServerCallContext context)
        {
            var users = new user();
            users.Name = "姓名";
            users.Detail = "描述";
            return Task.FromResult(new Userlist {
                Userinfo= users,
                No=1
            });
        }

    }
}