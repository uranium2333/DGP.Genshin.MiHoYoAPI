﻿using DGP.Genshin.MiHoYoAPI.Request;
using DGP.Genshin.MiHoYoAPI.Response;

namespace DGP.Genshin.MiHoYoAPI.User
{
    public class UserGameRoleProvider
    {
        private const string ApiTakumi = @"https://api-takumi.mihoyo.com";

        private readonly string cookie;
        public UserGameRoleProvider(string cookie)
        {
            this.cookie = cookie;
        }

        /// <summary>
        /// 获取用户角色信息
        /// </summary>
        /// <returns>用户角色信息</returns>
        public UserGameRoleInfo? GetUserGameRoles()
        {
            Requester requester = new(new RequestOptions
            {
                {"Accept", RequestOptions.Json },
                {"User-Agent", RequestOptions.CommonUA2101 },
                {"Cookie", cookie },
                {"X-Requested-With", RequestOptions.Hyperion }
            });
            Response<UserGameRoleInfo>? resp = requester.Get<UserGameRoleInfo>
                ($"{ApiTakumi}/binding/api/getUserGameRolesByCookie?game_biz=hk4e_cn");
            return resp?.Data;
        }
    }
}