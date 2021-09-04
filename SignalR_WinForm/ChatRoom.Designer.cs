
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_ChatRoom = new System.Windows.Forms.TextBox();
            this.txt_Msg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.cbx_ChatType = new System.Windows.Forms.ComboBox();
            this.txt_AddGroup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名:";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(87, 18);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(100, 23);
            this.txt_Name.TabIndex = 1;
            // 
            // txt_ChatRoom
            // 
            this.txt_ChatRoom.Location = new System.Drawing.Point(47, 111);
            this.txt_ChatRoom.Multiline = true;
            this.txt_ChatRoom.Name = "txt_ChatRoom";
            this.txt_ChatRoom.ReadOnly = true;
            this.txt_ChatRoom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_ChatRoom.Size = new System.Drawing.Size(443, 275);
            this.txt_ChatRoom.TabIndex = 2;
            // 
            // txt_Msg
            // 
            this.txt_Msg.Location = new System.Drawing.Point(87, 416);
            this.txt_Msg.Name = "txt_Msg";
            this.txt_Msg.Size = new System.Drawing.Size(314, 23);
            this.txt_Msg.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 419);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "訊息:";
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(426, 416);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(64, 23);
            this.btn_Submit.TabIndex = 6;
            this.btn_Submit.Text = "送出";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // cbx_ChatType
            // 
            this.cbx_ChatType.FormattingEnabled = true;
            this.cbx_ChatType.Location = new System.Drawing.Point(47, 82);
            this.cbx_ChatType.Name = "cbx_ChatType";
            this.cbx_ChatType.Size = new System.Drawing.Size(121, 23);
            this.cbx_ChatType.TabIndex = 7;
            this.cbx_ChatType.SelectedIndexChanged += new System.EventHandler(this.cbx_ChatType_SelectedIndexChanged);
            // 
            // txt_AddGroup
            // 
            this.txt_AddGroup.Location = new System.Drawing.Point(403, 82);
            this.txt_AddGroup.Name = "txt_AddGroup";
            this.txt_AddGroup.Size = new System.Drawing.Size(87, 23);
            this.txt_AddGroup.TabIndex = 8;
            this.txt_AddGroup.Text = "新增私人頻道";
            this.txt_AddGroup.UseVisualStyleBackColor = true;
            this.txt_AddGroup.Click += new System.EventHandler(this.txt_AddGroup_Click);
            // 
            // ChatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 482);
            this.Controls.Add(this.txt_AddGroup);
            this.Controls.Add(this.cbx_ChatType);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Msg);
            this.Controls.Add(this.txt_ChatRoom);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.label1);
            this.Name = "ChatRoom";
            this.Text = "ChatRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_ChatRoom;
        private System.Windows.Forms.TextBox txt_Msg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.ComboBox cbx_ChatType;
        private System.Windows.Forms.Button txt_AddGroup;
    }
}

