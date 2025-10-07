using Application;
using Domain;
using Microsoft.EntityFrameworkCore;
using persistant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Persistant
{
    public class GetUserInfoByUserId: IGetUserInfoByUserId
    {
        private readonly AppDbContext _context;
        private readonly DbSet<UserInfo> _userInfoDb;

        public GetUserInfoByUserId(AppDbContext context)
        {
            _context = context;
            _userInfoDb=_context.Set<UserInfo>();

        }

        public UserInfo GetUserInfo(string UserId)
        {
            var userInfo = _userInfoDb.Where(x => x.UserId.ToString() == UserId).FirstOrDefault();
            
            return userInfo;
            
        
        }



    }
}
