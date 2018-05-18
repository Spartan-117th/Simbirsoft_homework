namespace TicTacToe
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dimensionMTB = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startBTN = new System.Windows.Forms.Button();
            this.statusRTB = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gameStatusBox = new TicTacToe.StatusBox();
            this.SuspendLayout();
            // 
            // dimensionMTB
            // 
            this.dimensionMTB.Location = new System.Drawing.Point(16, 36);
            this.dimensionMTB.Name = "dimensionMTB";
            this.dimensionMTB.Size = new System.Drawing.Size(112, 20);
            this.dimensionMTB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите размерность поля в диапазоне от 3 до 9 клеток";
            // 
            // startBTN
            // 
            this.startBTN.Location = new System.Drawing.Point(16, 65);
            this.startBTN.Name = "startBTN";
            this.startBTN.Size = new System.Drawing.Size(112, 26);
            this.startBTN.TabIndex = 2;
            this.startBTN.Text = "Начать игру";
            this.startBTN.UseVisualStyleBackColor = true;
            this.startBTN.Click += new System.EventHandler(this.startBTN_Click);
            // 
            // statusRTB
            // 
            this.statusRTB.Location = new System.Drawing.Point(560, 109);
            this.statusRTB.Name = "statusRTB";
            this.statusRTB.Size = new System.Drawing.Size(259, 259);
            this.statusRTB.TabIndex = 3;
            this.statusRTB.Text = "";
            this.statusRTB.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Статус игры";
            // 
            // gameStatusBox
            // 
            this.gameStatusBox.Location = new System.Drawing.Point(291, 109);
            this.gameStatusBox.Name = "gameStatusBox";
            this.gameStatusBox.Size = new System.Drawing.Size(263, 259);
            this.gameStatusBox.TabIndex = 5;
            this.gameStatusBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 378);
            this.Controls.Add(this.gameStatusBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusRTB);
            this.Controls.Add(this.startBTN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dimensionMTB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Крестики-нолики";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox dimensionMTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startBTN;
        private System.Windows.Forms.RichTextBox statusRTB;
        private System.Windows.Forms.Label label2;
        private StatusBox gameStatusBox;
    }
}

