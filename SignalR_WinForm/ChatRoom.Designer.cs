
namespace SignalR_WinForm
{
    partial class ChatRoom
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Name = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_PublicChannel_ChatRoom = new System.Windows.Forms.TextBox();
            this.txt_PublicChannel_Msg = new System.Windows.Forms.TextBox();
            this.lbl_PublicChannel_Send = new System.Windows.Forms.Label();
            this.btn_PublicChannel_Submit = new System.Windows.Forms.Button();
            this.cbx_GroupChannel = new System.Windows.Forms.ComboBox();
            this.txt_AddGroup = new System.Windows.Forms.Button();
            this.txt_GroupChannel_ChatRoom = new System.Windows.Forms.TextBox();
            this.txt_PersonalChannel_ChatRoom = new System.Windows.Forms.TextBox();
            this.lbl_PublickChannel_Title = new System.Windows.Forms.Label();
            this.lbl_GroupChannel_Title = new System.Windows.Forms.Label();
            this.btn_GroupChannel_Submit = new System.Windows.Forms.Button();
            this.lbl_GroupChannel_Send = new System.Windows.Forms.Label();
            this.txt_GroupChannel_Msg = new System.Windows.Forms.TextBox();
            this.btn_PersonalChannel_Submit = new System.Windows.Forms.Button();
            this.lbl_PersonalChannel_Send = new System.Windows.Forms.Label();
            this.txt_PersonalChannel_Msg = new System.Windows.Forms.TextBox();
            this.lbl_PersonalChannel_Title = new System.Windows.Forms.Label();
            this.cbx_PersonalChannel = new System.Windows.Forms.ComboBox();
            this.btn_Name_Submit = new System.Windows.Forms.Button();
            this.lbl_GroupChannel_User = new System.Windows.Forms.Label();
            this.cbx_GroupChannel_User = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(47, 25);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(34, 15);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "姓名:";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(87, 22);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(100, 23);
            this.txt_Name.TabIndex = 1;
            // 
            // txt_PublicChannel_ChatRoom
            // 
            this.txt_PublicChannel_ChatRoom.Location = new System.Drawing.Point(47, 111);
            this.txt_PublicChannel_ChatRoom.Multiline = true;
            this.txt_PublicChannel_ChatRoom.Name = "txt_PublicChannel_ChatRoom";
            this.txt_PublicChannel_ChatRoom.ReadOnly = true;
            this.txt_PublicChannel_ChatRoom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_PublicChannel_ChatRoom.Size = new System.Drawing.Size(387, 275);
            this.txt_PublicChannel_ChatRoom.TabIndex = 2;
            // 
            // txt_PublicChannel_Msg
            // 
            this.txt_PublicChannel_Msg.Location = new System.Drawing.Point(47, 446);
            this.txt_PublicChannel_Msg.Name = "txt_PublicChannel_Msg";
            this.txt_PublicChannel_Msg.Size = new System.Drawing.Size(271, 23);
            this.txt_PublicChannel_Msg.TabIndex = 4;
            // 
            // lbl_PublicChannel_Send
            // 
            this.lbl_PublicChannel_Send.AutoSize = true;
            this.lbl_PublicChannel_Send.Location = new System.Drawing.Point(47, 419);
            this.lbl_PublicChannel_Send.Name = "lbl_PublicChannel_Send";
            this.lbl_PublicChannel_Send.Size = new System.Drawing.Size(91, 15);
            this.lbl_PublicChannel_Send.TabIndex = 5;
            this.lbl_PublicChannel_Send.Text = "發送訊息至公頻";
            // 
            // btn_PublicChannel_Submit
            // 
            this.btn_PublicChannel_Submit.Location = new System.Drawing.Point(364, 446);
            this.btn_PublicChannel_Submit.Name = "btn_PublicChannel_Submit";
            this.btn_PublicChannel_Submit.Size = new System.Drawing.Size(70, 23);
            this.btn_PublicChannel_Submit.TabIndex = 6;
            this.btn_PublicChannel_Submit.Text = "送出";
            this.btn_PublicChannel_Submit.UseVisualStyleBackColor = true;
            this.btn_PublicChannel_Submit.Click += new System.EventHandler(this.btn_PublicChannelSubmit_Click);
            // 
            // cbx_GroupChannel
            // 
            this.cbx_GroupChannel.FormattingEnabled = true;
            this.cbx_GroupChannel.Location = new System.Drawing.Point(562, 82);
            this.cbx_GroupChannel.Name = "cbx_GroupChannel";
            this.cbx_GroupChannel.Size = new System.Drawing.Size(121, 23);
            this.cbx_GroupChannel.TabIndex = 7;
            this.cbx_GroupChannel.SelectedIndexChanged += new System.EventHandler(this.cbx_Group_SelectedIndexChanged);
            // 
            // txt_AddGroup
            // 
            this.txt_AddGroup.Location = new System.Drawing.Point(1238, 21);
            this.txt_AddGroup.Name = "txt_AddGroup";
            this.txt_AddGroup.Size = new System.Drawing.Size(87, 23);
            this.txt_AddGroup.TabIndex = 8;
            this.txt_AddGroup.Text = "建立私人頻道";
            this.txt_AddGroup.UseVisualStyleBackColor = true;
            this.txt_AddGroup.Click += new System.EventHandler(this.txt_AddGroup_Click);
            // 
            // txt_GroupChannel_ChatRoom
            // 
            this.txt_GroupChannel_ChatRoom.Location = new System.Drawing.Point(518, 111);
            this.txt_GroupChannel_ChatRoom.Multiline = true;
            this.txt_GroupChannel_ChatRoom.Name = "txt_GroupChannel_ChatRoom";
            this.txt_GroupChannel_ChatRoom.ReadOnly = true;
            this.txt_GroupChannel_ChatRoom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_GroupChannel_ChatRoom.Size = new System.Drawing.Size(387, 275);
            this.txt_GroupChannel_ChatRoom.TabIndex = 9;
            // 
            // txt_PersonalChannel_ChatRoom
            // 
            this.txt_PersonalChannel_ChatRoom.Location = new System.Drawing.Point(987, 111);
            this.txt_PersonalChannel_ChatRoom.Multiline = true;
            this.txt_PersonalChannel_ChatRoom.Name = "txt_PersonalChannel_ChatRoom";
            this.txt_PersonalChannel_ChatRoom.ReadOnly = true;
            this.txt_PersonalChannel_ChatRoom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_PersonalChannel_ChatRoom.Size = new System.Drawing.Size(387, 275);
            this.txt_PersonalChannel_ChatRoom.TabIndex = 10;
            // 
            // lbl_PublickChannel_Title
            // 
            this.lbl_PublickChannel_Title.AutoSize = true;
            this.lbl_PublickChannel_Title.Location = new System.Drawing.Point(47, 85);
            this.lbl_PublickChannel_Title.Name = "lbl_PublickChannel_Title";
            this.lbl_PublickChannel_Title.Size = new System.Drawing.Size(31, 15);
            this.lbl_PublickChannel_Title.TabIndex = 11;
            this.lbl_PublickChannel_Title.Text = "公頻";
            // 
            // lbl_GroupChannel_Title
            // 
            this.lbl_GroupChannel_Title.AutoSize = true;
            this.lbl_GroupChannel_Title.Location = new System.Drawing.Point(519, 85);
            this.lbl_GroupChannel_Title.Name = "lbl_GroupChannel_Title";
            this.lbl_GroupChannel_Title.Size = new System.Drawing.Size(31, 15);
            this.lbl_GroupChannel_Title.TabIndex = 12;
            this.lbl_GroupChannel_Title.Text = "群組";
            // 
            // btn_GroupChannel_Submit
            // 
            this.btn_GroupChannel_Submit.Location = new System.Drawing.Point(835, 446);
            this.btn_GroupChannel_Submit.Name = "btn_GroupChannel_Submit";
            this.btn_GroupChannel_Submit.Size = new System.Drawing.Size(70, 23);
            this.btn_GroupChannel_Submit.TabIndex = 15;
            this.btn_GroupChannel_Submit.Text = "送出";
            this.btn_GroupChannel_Submit.UseVisualStyleBackColor = true;
            this.btn_GroupChannel_Submit.Click += new System.EventHandler(this.btn_GroupSubmit_Click);
            // 
            // lbl_GroupChannel_Send
            // 
            this.lbl_GroupChannel_Send.AutoSize = true;
            this.lbl_GroupChannel_Send.Location = new System.Drawing.Point(518, 419);
            this.lbl_GroupChannel_Send.Name = "lbl_GroupChannel_Send";
            this.lbl_GroupChannel_Send.Size = new System.Drawing.Size(67, 15);
            this.lbl_GroupChannel_Send.TabIndex = 14;
            this.lbl_GroupChannel_Send.Text = "發送訊息至";
            // 
            // txt_GroupChannel_Msg
            // 
            this.txt_GroupChannel_Msg.Location = new System.Drawing.Point(518, 446);
            this.txt_GroupChannel_Msg.Name = "txt_GroupChannel_Msg";
            this.txt_GroupChannel_Msg.Size = new System.Drawing.Size(271, 23);
            this.txt_GroupChannel_Msg.TabIndex = 13;
            // 
            // btn_PersonalChannel_Submit
            // 
            this.btn_PersonalChannel_Submit.Location = new System.Drawing.Point(1304, 446);
            this.btn_PersonalChannel_Submit.Name = "btn_PersonalChannel_Submit";
            this.btn_PersonalChannel_Submit.Size = new System.Drawing.Size(70, 23);
            this.btn_PersonalChannel_Submit.TabIndex = 18;
            this.btn_PersonalChannel_Submit.Text = "送出";
            this.btn_PersonalChannel_Submit.UseVisualStyleBackColor = true;
            this.btn_PersonalChannel_Submit.Click += new System.EventHandler(this.btn_PersonalChannel_Submit_Click);
            // 
            // lbl_PersonalChannel_Send
            // 
            this.lbl_PersonalChannel_Send.AutoSize = true;
            this.lbl_PersonalChannel_Send.Location = new System.Drawing.Point(987, 419);
            this.lbl_PersonalChannel_Send.Name = "lbl_PersonalChannel_Send";
            this.lbl_PersonalChannel_Send.Size = new System.Drawing.Size(67, 15);
            this.lbl_PersonalChannel_Send.TabIndex = 17;
            this.lbl_PersonalChannel_Send.Text = "發送訊息至";
            // 
            // txt_PersonalChannel_Msg
            // 
            this.txt_PersonalChannel_Msg.Location = new System.Drawing.Point(987, 446);
            this.txt_PersonalChannel_Msg.Name = "txt_PersonalChannel_Msg";
            this.txt_PersonalChannel_Msg.Size = new System.Drawing.Size(271, 23);
            this.txt_PersonalChannel_Msg.TabIndex = 16;
            // 
            // lbl_PersonalChannel_Title
            // 
            this.lbl_PersonalChannel_Title.AutoSize = true;
            this.lbl_PersonalChannel_Title.Location = new System.Drawing.Point(988, 85);
            this.lbl_PersonalChannel_Title.Name = "lbl_PersonalChannel_Title";
            this.lbl_PersonalChannel_Title.Size = new System.Drawing.Size(31, 15);
            this.lbl_PersonalChannel_Title.TabIndex = 20;
            this.lbl_PersonalChannel_Title.Text = "私訊";
            // 
            // cbx_PersonalChannel
            // 
            this.cbx_PersonalChannel.FormattingEnabled = true;
            this.cbx_PersonalChannel.Location = new System.Drawing.Point(1031, 82);
            this.cbx_PersonalChannel.Name = "cbx_PersonalChannel";
            this.cbx_PersonalChannel.Size = new System.Drawing.Size(121, 23);
            this.cbx_PersonalChannel.TabIndex = 19;
            this.cbx_PersonalChannel.SelectedIndexChanged += new System.EventHandler(this.cbx_PersonalChannel_SelectedIndexChanged);
            // 
            // btn_Name_Submit
            // 
            this.btn_Name_Submit.Location = new System.Drawing.Point(231, 22);
            this.btn_Name_Submit.Name = "btn_Name_Submit";
            this.btn_Name_Submit.Size = new System.Drawing.Size(75, 23);
            this.btn_Name_Submit.TabIndex = 21;
            this.btn_Name_Submit.Text = "確認";
            this.btn_Name_Submit.UseVisualStyleBackColor = true;
            this.btn_Name_Submit.Click += new System.EventHandler(this.btn_Name_Submit_Click);
            // 
            // lbl_GroupChannel_User
            // 
            this.lbl_GroupChannel_User.AutoSize = true;
            this.lbl_GroupChannel_User.Location = new System.Drawing.Point(723, 85);
            this.lbl_GroupChannel_User.Name = "lbl_GroupChannel_User";
            this.lbl_GroupChannel_User.Size = new System.Drawing.Size(55, 15);
            this.lbl_GroupChannel_User.TabIndex = 22;
            this.lbl_GroupChannel_User.Text = "群組成員";
            // 
            // cbx_GroupChannel_User
            // 
            this.cbx_GroupChannel_User.FormattingEnabled = true;
            this.cbx_GroupChannel_User.Location = new System.Drawing.Point(784, 82);
            this.cbx_GroupChannel_User.Name = "cbx_GroupChannel_User";
            this.cbx_GroupChannel_User.Size = new System.Drawing.Size(121, 23);
            this.cbx_GroupChannel_User.TabIndex = 23;
            // 
            // ChatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 502);
            this.Controls.Add(this.cbx_GroupChannel_User);
            this.Controls.Add(this.lbl_GroupChannel_User);
            this.Controls.Add(this.btn_Name_Submit);
            this.Controls.Add(this.lbl_PersonalChannel_Title);
            this.Controls.Add(this.cbx_PersonalChannel);
            this.Controls.Add(this.btn_PersonalChannel_Submit);
            this.Controls.Add(this.lbl_PersonalChannel_Send);
            this.Controls.Add(this.txt_PersonalChannel_Msg);
            this.Controls.Add(this.btn_GroupChannel_Submit);
            this.Controls.Add(this.lbl_GroupChannel_Send);
            this.Controls.Add(this.txt_GroupChannel_Msg);
            this.Controls.Add(this.lbl_GroupChannel_Title);
            this.Controls.Add(this.lbl_PublickChannel_Title);
            this.Controls.Add(this.txt_PersonalChannel_ChatRoom);
            this.Controls.Add(this.txt_GroupChannel_ChatRoom);
            this.Controls.Add(this.txt_AddGroup);
            this.Controls.Add(this.cbx_GroupChannel);
            this.Controls.Add(this.btn_PublicChannel_Submit);
            this.Controls.Add(this.lbl_PublicChannel_Send);
            this.Controls.Add(this.txt_PublicChannel_Msg);
            this.Controls.Add(this.txt_PublicChannel_ChatRoom);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.lbl_Name);
            this.Name = "ChatRoom";
            this.Text = "ChatRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_PublicChannel_ChatRoom;
        private System.Windows.Forms.TextBox txt_PublicChannel_Msg;
        private System.Windows.Forms.Label lbl_PublicChannel_Send;
        private System.Windows.Forms.Button btn_PublicChannel_Submit;
        private System.Windows.Forms.ComboBox cbx_GroupChannel;
        private System.Windows.Forms.Button txt_AddGroup;
        private System.Windows.Forms.TextBox txt_GroupChannel_ChatRoom;
        private System.Windows.Forms.TextBox txt_PersonalChannel_ChatRoom;
        private System.Windows.Forms.Label lbl_PublickChannel_Title;
        private System.Windows.Forms.Label lbl_GroupChannel_Title;
        private System.Windows.Forms.Button btn_GroupChannel_Submit;
        private System.Windows.Forms.Label lbl_GroupChannel_Send;
        private System.Windows.Forms.TextBox txt_GroupChannel_Msg;
        private System.Windows.Forms.Button btn_PersonalChannel_Submit;
        private System.Windows.Forms.Label lbl_PersonalChannel_Send;
        private System.Windows.Forms.TextBox txt_PersonalChannel_Msg;
        private System.Windows.Forms.Label lbl_PersonalChannel_Title;
        private System.Windows.Forms.ComboBox cbx_PersonalChannel;
        private System.Windows.Forms.Button btn_Name_Submit;
        private System.Windows.Forms.Label lbl_GroupChannel_User;
        private System.Windows.Forms.ComboBox cbx_GroupChannel_User;
    }
}

