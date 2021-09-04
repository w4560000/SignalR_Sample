using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Server
{
    public class ChatHub : Hub
    {
        /// <summary>
        /// 群組資訊
        /// { "GroupName", ( "ConnectionID", "UserName" ) }
        /// </summary>
        private static ConcurrentDictionary<string, List<(string, string)>> _groupInfo = new ConcurrentDictionary<string, List<(string, string)>>();

        /// <summary>
        /// 群組名稱Mapping
        /// </summary>
        private static ConcurrentDictionary<string, string> _groupNameMapping = new ConcurrentDictionary<string, string>();


        /// <summary>
        /// 公共頻道-傳送訊息
        /// </summary>
        public async Task AllMessage_Send(string user, string message)
        {
            var content = $"{user} ({DateTime.Now.ToShortTimeString()})：{message}";

            await Clients.All.SendAsync("AllMessage_Recevie", content);
        }

        /// <summary>
        /// 取得所有群組資訊
        /// </summary>
        public async Task GetAllGroup_Send()
        {
            await Clients.All.SendAsync("GetAllGroup_Recevie", _groupNameMapping, _groupInfo);
        }

        public async Task JoinGroup_Send(string groupName_enus,string groupName_zhtw, string userName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName_enus);

            // 加入群組名稱
            _groupNameMapping.AddOrUpdate(groupName_enus, groupName_zhtw, (di, value) => groupName_zhtw);

            // 加入群組資訊
            _groupInfo.AddOrUpdate(
                groupName_enus, 
                (di) => new List<(string, string)>(), 
                (di, value) => {
                    value.Add((userName, Context.ConnectionId));
                    return value;
                    });

            await Clients.All.SendAsync("GetAllGroup_Recevie", _groupNameMapping, _groupInfo);
        }
    }
}