
namespace WFA_TCMB_Doviz_Kuru
{
    partial class OptionsFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsFrm));
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.lbLang = new System.Windows.Forms.Label();
            this.cmbBoxLang = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageGeneral.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.lbLang);
            this.tabPageGeneral.Controls.Add(this.cmbBoxLang);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(384, 263);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // lbLang
            // 
            this.lbLang.AutoSize = true;
            this.lbLang.Location = new System.Drawing.Point(6, 12);
            this.lbLang.Name = "lbLang";
            this.lbLang.Size = new System.Drawing.Size(58, 13);
            this.lbLang.TabIndex = 3;
            this.lbLang.Text = "Language:";
            // 
            // cmbBoxLang
            // 
            this.cmbBoxLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxLang.FormattingEnabled = true;
            this.cmbBoxLang.Location = new System.Drawing.Point(70, 9);
            this.cmbBoxLang.Name = "cmbBoxLang";
            this.cmbBoxLang.Size = new System.Drawing.Size(176, 21);
            this.cmbBoxLang.TabIndex = 4;
            this.cmbBoxLang.SelectedIndexChanged += new System.EventHandler(this.cmbBoxLang_SelectedIndexChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageGeneral);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(392, 289);
            this.tabControl.TabIndex = 1;
            // 
            // OptionsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 289);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.tabPageGeneral.ResumeLayout(false);
            this.tabPageGeneral.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.Label lbLang;
        private System.Windows.Forms.ComboBox cmbBoxLang;
        private System.Windows.Forms.TabControl tabControl;
    }
}