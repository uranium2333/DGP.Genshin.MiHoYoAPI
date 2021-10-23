﻿using DGP.Genshin.MiHoYoAPI.Request;
using DGP.Genshin.MiHoYoAPI.Request.DynamicSecret;

namespace DGP.Genshin.MiHoYoAPI.Record.DailyNote
{
    public class DailyNoteProvider : IApiTakumiInterop
    {
        private const string BaseUrl = @"https://api-takumi.mihoyo.com/game_record/app/genshin/api";
        private const string Referer = @"https://webstatic.mihoyo.com/app/community-game-records/index.html?v=6";

        private readonly Requester requester;

        public DailyNoteProvider(string cookie)
        {
            requester = new Requester(new RequestOptions
            {
                {"Accept", RequestOptions.Json },
                {"x-rpc-app_version", DynamicSecretProvider2.AppVersion },
                {"User-Agent", RequestOptions.CommonUA2111 },
                {"x-rpc-client_type", "5" },
                {"Referer",Referer },
                {"Cookie", cookie },
                {"X-Requested-With", RequestOptions.Hyperion }
            });
        }

        public DailyNote? GetDailyNote(string server, string uid)
        {
            return requester.GetWhileUpdateDynamicSecret2<DailyNote>($"{BaseUrl}/dailyNote?server={server}&role_id={uid}");   
        }
    }
}