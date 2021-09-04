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
        private readonly string _signalrUrl = @"https://localhost:44378/chatHub";
        private HubConnection _hubConnection;

        private List<Cbx_Item> cbx_GroupChannel_Items = new List<Cbx_Item>();
        private List<Cbx_Item> cbx_PersonalChannel_Items = new List<Cbx_Item>();


        public ChatRoom()
        {
            InitializeComponent();

            Connect();

            cbx_GroupChannel.DataSource = cbx_GroupChannel_Items;
            cbx_GroupChannel.DisplayMember = "Name";
            cbx_GroupChannel.ValueMember = "Value";
        }

        private async void Connect()
        {
            this._hubConnection = new HubConnectionBuilder()
                    .WithUrl(_signalrUrl)
                    .AddMessagePackProtocol()
                    .Build();

            this._hubConnection.ServerTimeout = TimeSpan.FromMinutes(10);
            await _hubConnection.StartAsync();

            // Register PublicChannel Msg
            this._hubConnection.On("AllMessage_Recevie",
                              (string content) =>
                              {
                                  this.txt_PublicChannel_ChatRoom
                                      .InvokeIfNecessary(() => this.txt_PublicChannel_ChatRoom.AppendText(content + "\r\n"));
                              });

            // Register Group Info
            this._hubConnection.On("GetAllGroup_Recevie",
                  (Dictionary<string, string> groupNameMapping, Dictionary<string, List<(string, string)>> groupInfo) =>
                  {
                      this.cbx_GroupChannel
                          .InvokeIfNecessary(() =>
                          {
                              this.cbx_GroupChannel_Items = groupNameMapping.Select(x =>
                                new Cbx_Item(x.Value, x.Key, Convert.ToInt32(x.Key.Split('_').Last()))).ToList();

                              this.cbx_GroupChannel_Items = this.cbx_GroupChannel_Items.OrderBy(o => o.Order).ToList();

                              cbx_GroupChannel.DataSource = cbx_GroupChannel_Items;
                              cbx_GroupChannel.DisplayMember = "Name";
                              cbx_GroupChannel.ValueMember = "Value";
                          });
                  });

            // Register Group Msg
            this._hubConnection.On("GroupMessage_Recevie",
                  (string content) =>
                  {
                      this.txt_GroupChannel_ChatRoom
                          .InvokeIfNecessary(() =>
                          {
                              this.txt_GroupChannel_ChatRoom
                                  .InvokeIfNecessary(() => this.txt_GroupChannel_ChatRoom.AppendText(content + "\r\n"));
                          });
                  });

            // Register Group Msg
            this._hubConnection.On("JoinGroup_Error",
                  (string content) =>
                  {
                      MessageBox.Show(content, "別亂取名");
                  });

            // Register User Info
            this._hubConnection.On("GetAllUser_Recevie",
                  (List<string> userList) =>
                  {
                      this.cbx_GroupChannel
                          .InvokeIfNecessary(() =>
                          {
                              this.cbx_PersonalChannel_Items = userList.Select(x =>
                                new Cbx_Item(x, x)).ToList();

                              this.cbx_PersonalChannel_Items = this.cbx_PersonalChannel_Items.OrderBy(o => o.Order).ToList();

                              cbx_PersonalChannel.DataSource = cbx_PersonalChannel_Items;
                              cbx_PersonalChannel.DisplayMember = "Name";
                              cbx_PersonalChannel.ValueMember = "Value";
                          });
                  });

            // Register User Info
            this._hubConnection.On("UserMessage_Recevie",
                  (string content) =>
                  {
                      this.txt_PersonalChannel_ChatRoom
                          .InvokeIfNecessary(() =>
                          {
                              this.txt_PersonalChannel_ChatRoom
                                  .InvokeIfNecessary(() => this.txt_PersonalChannel_ChatRoom.AppendText(content + "\r\n"));
                          });
                  });

            await this._hubConnection.InvokeAsync("GetAllGroup_Send");
            await this._hubConnection.InvokeAsync("GetAllUser_Send");
        }

        /// <summary>
        /// 確認姓名
        /// </summary>
        private async void btn_Name_Submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_Name.Text))
            {
                MessageBox.Show("請輸入姓名", "你他媽是誰");
                return;
            }

            this.txt_Name.Enabled = false;
            this.btn_Name_Submit.Visible = false;

            // 姓名輸入完，若存在現有群組 則自動加入
            if (this.cbx_GroupChannel != null &&
                this.cbx_GroupChannel.Items.Count != 0 &&
                !string.IsNullOrEmpty(this.cbx_GroupChannel.SelectedValue.ToString()))
            {
                await this._hubConnection.InvokeAsync("JoinGroup_Send",
                                this._hubConnection.ConnectionId,
                                this.cbx_GroupChannel.SelectedValue,
                                txt_Name.Text);
            }
        }

        #region PublicChannel

        /// <summary>
        /// 發送公頻訊息
        /// </summary>
        private async void btn_PublicChannelSubmit_Click(object sender, EventArgs e)
        {
            await this._hubConnection.InvokeAsync("AllMessage_Send", this.txt_Name.Text, this.txt_PublicChannel_Msg.Text);
        }

        /// <summary>
        /// 切換群組
        /// </summary>
        private async void cbx_Group_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 切換頻道 清空聊天室
            this.txt_PublicChannel_ChatRoom.InvokeIfNecessary(() => this.txt_GroupChannel_ChatRoom.Text = string.Empty);

            lbl_GroupChannel_Send.InvokeIfNecessary(() =>
                this.lbl_GroupChannel_Send.Text = $"發送訊息至{cbx_GroupChannel_Items.FirstOrDefault(w => w.Value == this.cbx_GroupChannel.SelectedValue.ToString()).Name}");

            if (!string.IsNullOrEmpty(txt_Name.Text))
                await this._hubConnection.InvokeAsync("JoinGroup_Send",
                    this._hubConnection.ConnectionId,
                    this.cbx_GroupChannel.SelectedValue,
                    txt_Name.Text);
        }

        #endregion PublicChannel

        #region GroupChannel

        /// <summary>
        /// 建立群組頻道
        /// </summary>
        private async void txt_AddGroup_Click(object sender, EventArgs e)
        {
            int groupOrder = this.cbx_GroupChannel_Items.Where(w => w.Value.Contains("PersonalChannel"))
                                                        .OrderByDescending(o => o.Order)
                                                        .FirstOrDefault()?.Order ?? 0;

            string groupName = $"PersonalChannel_{groupOrder + 1}";

            await this._hubConnection.InvokeAsync("CreateGroup_Send", groupName, $"私人頻道{groupOrder + 1}");
        }

        /// <summary>
        /// 發送訊息至群組
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_GroupSubmit_Click(object sender, EventArgs e)
        {
            await this._hubConnection.InvokeAsync("GroupMessage_Send",
                cbx_GroupChannel.SelectedValue,
                this.txt_Name.Text,
                this.txt_GroupChannel_Msg.Text);
        }

        #endregion GroupChannel

        /// <summary>
        /// 切換私訊
        /// </summary>
        private void cbx_PersonalChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 發送訊息至群組
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_PersonalChannel_Submit_Click(object sender, EventArgs e)
        {
            await this._hubConnection.InvokeAsync("UserMessage_Send",
                cbx_PersonalChannel.SelectedValue,
                this.txt_Name.Text,
                this.txt_PersonalChannel_Msg.Text);
        }
    }
}