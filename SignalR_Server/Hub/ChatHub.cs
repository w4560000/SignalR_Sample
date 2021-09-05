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
        /// 使用者資訊
        /// { "ConnectionID", "UserName" }
        /// </summary>
        private static ConcurrentDictionary<string, string> _UserInfo = new ConcurrentDictionary<string, string>();

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

        public override async Task OnConnectedAsync()
        {
            var userName = Context.GetHttpContext().Request.Query["userName"];

            _UserInfo.AddOrUpdate(Context.ConnectionId, userName, (key, value) => userName);

            await GetAllUser_Send();
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;
            var userName = Context.GetHttpContext().Request.Query["userName"];

            _UserInfo.Remove(Context.ConnectionId, out _);



            // 清除 群組內的使用者連線
            List<string> groupList = _groupInfo.Where(w => w.Value.Any(w1 => w1.Item2 == Context.ConnectionId))
                                               .Select(s => s.Key).ToList();

            groupList.ForEach(async x => await Groups.RemoveFromGroupAsync(connectionId, x));

            // 清除 群組資料
            foreach (var group in _groupInfo)
            {
                group.Value.Remove(group.Value.SingleOrDefault(w => w.Item2 == connectionId));
            }


            if (_groupInfo.Any(w => w.Value.Count == 0))
            {
                foreach (var group in _groupInfo.Where(w => w.Value.Count == 0).ToList())
                {
                    _groupInfo.Remove(group.Key, out _);
                    _groupNameMapping.Remove(group.Key, out _);
                }
            }

            await base.OnDisconnectedAsync(exception);
        }

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

            await Groups.AddToGroupAsync(connectionId, groupId);

            // 加入群組資訊
            _groupInfo.AddOrUpdate(
                groupId,
                (di) => new List<(string, string)>(),
                (di, value) =>
                {
                    if (value.Any(a => a.Item1 == userName))
                        value.Remove(value.Where(w => w.Item1 == userName).FirstOrDefault());

                    value.Add((userName, Context.ConnectionId));
                    return value;
                });
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

        /// <summary>
        /// 取得群組內 所有使用者
        /// </summary>
        /// <param name="groupID">群組Id</param>
        public async Task GetGroupUser_Send(string groupId)
        {
            if (string.IsNullOrEmpty(groupId))
                return;

            if (_groupInfo.TryGetValue(groupId, out List<(string, string)> userList))
            {
                await Clients.Group(groupId).SendAsync($"GetGroupUser_Recevie", userList.Select(s => s.Item1).ToList());
            }
        }

        #endregion GroupChannel

        /// <summary>
        /// 取得所有使用者
        /// </summary>
        public async Task GetAllUser_Send()
        {
            if (!_UserInfo.Any())
                return;

            List<string> userName = _UserInfo.Select(s => s.Value).ToList();

            await Clients.All.SendAsync($"GetAllUser_Recevie", userName);
        }

        /// <summary>
        /// 使用者-傳送訊息
        /// </summary>
        public async Task UserMessage_Send(string userNameReceive, string userName, string message)
        {
            if (string.IsNullOrEmpty(userName))
                return;

            var connectionIdReceivList = _UserInfo.Where(x => x.Value == userNameReceive || x.Value == userName)
                                               .Select(s => s.Key)
                                               .ToList();

            if (!connectionIdReceivList.Any())
                return;

            var content = $"{userName} ({DateTime.Now.ToShortTimeString()})：{message}";

            await Clients.Clients(connectionIdReceivList).SendAsync("UserMessage_Recevie", content);
        }
    }
}