using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using SignalR_WinForm.Extensions;
using SignalR_WinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SignalR_WinForm
{
    public partial class ChatRoom : Form
    {
        private readonly string _actionName = "SendAllMessage";
        private readonly string _hubName = "chatHub";
        private readonly string _signalrUrl = @"https://localhost:44378/chatHub";
        private HubConnection _hubConnection;
        private List<Cbx_Item> cbx_Items = new List<Cbx_Item>();

        public ChatRoom()
        {
            InitializeComponent();

            Connect();

            cbx_Items.Add(new Cbx_Item("公頻", "PublicChannel", 0));

            cbx_ChatType.DataSource = cbx_Items;
            cbx_ChatType.DisplayMember = "Name";
            cbx_ChatType.ValueMember = "Value";
        }

        private async void Connect()
        {
            this._hubConnection = new HubConnectionBuilder()
                    .WithUrl(_signalrUrl)
                    .AddMessagePackProtocol()
                    .Build();

            await _hubConnection.StartAsync();



            this._hubConnection.On("AllMessage_Recevie",
                              (string content) =>
                              {
                                  this.txt_ChatRoom
                                      .InvokeIfNecessary(() => this.txt_ChatRoom.AppendText(content + "\r\n"));
                              });

            this._hubConnection.On("GetAllGroup_Recevie",
                  (Dictionary<string, string> groupNameMapping, Dictionary<string, List<(string, string)>> groupInfo) =>
                  {
                      this.cbx_ChatType
                          .InvokeIfNecessary(() =>
                          {
                              var cbx_Item = groupNameMapping.Select(x =>
                                new Cbx_Item(x.Value, x.Key, Convert.ToInt32(x.Key.Split('_').Last()))).ToList();

                              this.cbx_Items.AddRange(cbx_Item);
                              cbx_ChatType.DataSource = null;
                              cbx_ChatType.DataSource = cbx_Items;
                              cbx_ChatType.DisplayMember = "Name";
                              cbx_ChatType.ValueMember = "Value";
                          });
                  });

            await this._hubConnection.InvokeAsync("GetAllGroup_Send");
        }

        private async void btn_Submit_Click(object sender, EventArgs e)
        {
            await this._hubConnection.InvokeAsync("AllMessage_Send", this.txt_Name.Text, this.txt_Msg.Text);
        }

        private async void cbx_ChatType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 切換頻道 清空聊天室
            this.txt_ChatRoom.InvokeIfNecessary(() => this.txt_ChatRoom.Text = string.Empty);
        }

        private async void txt_AddGroup_Click(object sender, EventArgs e)
        {
            string groupName = "";
            int groupOrder = (this.cbx_Items.Where(w => w.Value.Contains("PersonalChannel"))
                                                 .OrderByDescending(o => o.Order)
                                                 .FirstOrDefault()?.Order ?? 0);

            groupName = $"PersonalChannel_{groupOrder + 1}";

            await this._hubConnection.InvokeAsync("JoinGroup_Send", groupName, $"私人頻道{groupOrder + 1}", this.txt_Name.Text);
        }
    }
}