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

        #region PublicChannel

        /// <summary>
        /// 公共頻道-傳送訊息
        /// </summary>
        /// <param name="user">使用者</param>
        /// <param name="message">訊息</param>
        public async Task AllMessage_Send(string user, string message)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(message))
                return;

            var content = $"{user} ({DateTime.Now.ToShortTimeString()})：{message}";

            await Clients.All.SendAsync("AllMessage_Recevie", content);
        }

        #endregion PublicChannel

        #region GroupChannel

        /// <summary>
        /// 取得所有群組資訊
        /// </summary>
        public async Task GetAllGroup_Send()
        {
            await Clients.All.SendAsync("GetAllGroup_Recevie", _groupNameMapping, _groupInfo);
        }

        /// <summary>
        /// 建立群組
        /// </summary>
        /// <param name="groupId">群組Id</param>
        /// <param name="groupName">群組 中文名稱</param>
        public async Task CreateGroup_Send(string groupId, string groupName)
        {
            if (string.IsNullOrEmpty(groupId) || string.IsNullOrEmpty(groupName))
                return;

            // 加入群組名稱
            _groupNameMapping.AddOrUpdate(groupId, groupName, (di, value) => groupName);

            // 加入群組資訊
            _groupInfo.AddOrUpdate(
                groupId,
                (di) => new List<(string, string)>(),
                (di, value) => value);

            await Clients.All.SendAsync("GetAllGroup_Recevie", _groupNameMapping, _groupInfo);
        }

        /// <summary>
        /// 加入群組
        /// </summary>
        /// <param name="connectionId">連線Id</param>
        /// <param name="groupId">群組Id</param>
        /// <param name="userName">使用者名稱</param>
        public async Task JoinGroup_Send(string connectionId, string groupId, string userName)
        {
            if (string.IsNullOrEmpty(groupId) || string.IsNullOrEmpty(userName))
                return;

            if (_groupInfo.Any(w => w.Value.Any(a => a.Item1 == userName)))
            {
                await Clients.All.SendAsync("JoinGroup_Error", $"{userName} 已存在, 請更換名稱");
                return;
            }

            await Groups.AddToGroupAsync(connectionId, groupId);

            // 加入群組資訊
            _groupInfo.AddOrUpdate(
                groupId,
                (di) => new List<(string, string)>(),
                (di, value) =>
                {
                    value.Add((userName, Context.ConnectionId));
                    return value;
                });

            await GetAllUser_Send();
        }

        /// <summary>
        /// 群組-傳送訊息
        /// </summary>
        /// <param name="groupID">群組Id</param>
        /// <param name="message">訊息</param>
        public async Task GroupMessage_Send(string groupId, string user, string message)
        {
            if (string.IsNullOrEmpty(groupId) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(message))
                return;

            if (!_groupInfo.ContainsKey(groupId))
                return;

            var content = $"{user} ({DateTime.Now.ToShortTimeString()})：{message}";

            await Clients.Group(groupId).SendAsync($"GroupMessage_Recevie", content);
        }

        #endregion GroupChannel

        /// <summary>
        /// 取得所有使用者
        /// </summary>
        public async Task GetAllUser_Send()
        {
            if (!_groupInfo.Any())
                return;

            List<string> userName = _groupInfo.SelectMany(key => key.Value, (key, value) => value.Item1).ToList();

            await Clients.All.SendAsync($"GetAllUser_Recevie", userName);
        }

        /// <summary>
        /// 使用者-傳送訊息
        /// </summary>
        public async Task UserMessage_Send(string userNameReceive, string userName, string message)
        {
            if (string.IsNullOrEmpty(userName))
                return;

            var connectionIdList = _groupInfo.FirstOrDefault(x => x.Value.Any(y => y.Item1 == userNameReceive)).Value.Select(s => s.Item2).ToList();

            var content = $"{userName} ({DateTime.Now.ToShortTimeString()})：{message}";

            await Clients.Clients(connectionIdList).SendAsync("UserMessage_Recevie", content);
        }
    }
}