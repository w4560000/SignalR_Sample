using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using SignalR_WinForm.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalR_WinForm
{
    public partial class PublicChannel : Form
    {
        private readonly string _actionName = "SendAllMessage";
        private readonly string _hubName = "chatHub";
        private readonly string _signalrUrl = @"http://localhost:5000/";
        private HubConnection _hubConnection;

        public PublicChannel()
        {
            InitializeComponent();

            Connect();
        }

        private async void Connect()
        {
            this._hubConnection = new HubConnectionBuilder()
                    .WithUrl("https://localhost:44378/chatHub")
                    .AddMessagePackProtocol()
                    .Build();


            await _hubConnection.StartAsync();

            this._hubConnection.On("AllMessage_Recevie",
                              (string content) =>
                              {
                                  this.txt_ChatRoom
                                      .InvokeIfNecessary(() =>
                                      {
                                          this.txt_ChatRoom.AppendText(content + "\r\n");
                                      });
                              });
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await this._hubConnection.InvokeAsync("AllMessage_Send",
                                            this.txt_Name.Text,
                                            this.txt_Msg.Text);
        }
    }
}
