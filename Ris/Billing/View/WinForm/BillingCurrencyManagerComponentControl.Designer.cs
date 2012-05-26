#region License

// Copyright (c) 2006-2007, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

namespace ClearCanvas.Ris.Billing.View.WinForms
{
    partial class BillingCurrencyManagerComponentControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSetPrimaryCurrnency = new System.Windows.Forms.Button();
            this._clearButton = new System.Windows.Forms.Button();
            this._searchButton = new System.Windows.Forms.Button();
            this._id = new ClearCanvas.Desktop.View.WinForms.TextField();
            this._name = new ClearCanvas.Desktop.View.WinForms.TextField();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._CurrencyTableView = new ClearCanvas.Desktop.View.WinForms.TableView();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnSetPrimaryCurrnency);
            this.panel1.Controls.Add(this._clearButton);
            this.panel1.Controls.Add(this._searchButton);
            this.panel1.Controls.Add(this._id);
            this.panel1.Controls.Add(this._name);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 54);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(528, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(234, 27);
            this.button1.TabIndex = 6;
            this.button1.Text = "Change Primary Ex-Rate Currency";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnChangedPrimaryExRateCurrnency_Click);
            // 
            // btnSetPrimaryCurrnency
            // 
            this.btnSetPrimaryCurrnency.Location = new System.Drawing.Point(365, 19);
            this.btnSetPrimaryCurrnency.Name = "btnSetPrimaryCurrnency";
            this.btnSetPrimaryCurrnency.Size = new System.Drawing.Size(157, 27);
            this.btnSetPrimaryCurrnency.TabIndex = 6;
            this.btnSetPrimaryCurrnency.Text = "Change Primary Currency";
            this.btnSetPrimaryCurrnency.UseVisualStyleBackColor = true;
            this.btnSetPrimaryCurrnency.Click += new System.EventHandler(this.btnSetPrimaryCurrnency_Click);
            // 
            // _clearButton
            // 
            this._clearButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._clearButton.BackColor = System.Drawing.Color.Transparent;
            this._clearButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._clearButton.FlatAppearance.BorderSize = 0;
            this._clearButton.Image = global::ClearCanvas.Ris.Billing.View.WinForms.SR.ClearFilterSmall;
            this._clearButton.Location = new System.Drawing.Point(332, 19);
            this._clearButton.Margin = new System.Windows.Forms.Padding(0);
            this._clearButton.Name = "_clearButton";
            this._clearButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._clearButton.Size = new System.Drawing.Size(30, 30);
            this._clearButton.TabIndex = 5;
            this._clearButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._clearButton.UseVisualStyleBackColor = false;
            this._clearButton.Click += new System.EventHandler(this._clearButton_Click);
            // 
            // _searchButton
            // 
            this._searchButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._searchButton.BackColor = System.Drawing.Color.Transparent;
            this._searchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._searchButton.FlatAppearance.BorderSize = 0;
            this._searchButton.Image = global::ClearCanvas.Ris.Billing.View.WinForms.SR.SearchToolSmall;
            this._searchButton.Location = new System.Drawing.Point(301, 19);
            this._searchButton.Margin = new System.Windows.Forms.Padding(0);
            this._searchButton.Name = "_searchButton";
            this._searchButton.Size = new System.Drawing.Size(30, 30);
            this._searchButton.TabIndex = 4;
            this._searchButton.UseVisualStyleBackColor = false;
            this._searchButton.Click += new System.EventHandler(this._searchButton_Click);
            // 
            // _id
            // 
            this._id.LabelText = "Currency Code";
            this._id.Location = new System.Drawing.Point(0, 6);
            this._id.Margin = new System.Windows.Forms.Padding(2);
            this._id.Mask = "";
            this._id.Name = "_id";
            this._id.PasswordChar = '\0';
            this._id.Size = new System.Drawing.Size(152, 41);
            this._id.TabIndex = 0;
            this._id.ToolTip = null;
            this._id.Value = null;
            this._id.Leave += new System.EventHandler(this._field_Leave);
            this._id.Enter += new System.EventHandler(this._field_Enter);
            // 
            // _name
            // 
            this._name.LabelText = "Currency Name";
            this._name.Location = new System.Drawing.Point(150, 6);
            this._name.Margin = new System.Windows.Forms.Padding(2);
            this._name.Mask = "";
            this._name.Name = "_name";
            this._name.PasswordChar = '\0';
            this._name.Size = new System.Drawing.Size(150, 41);
            this._name.TabIndex = 1;
            this._name.ToolTip = null;
            this._name.Value = null;
            this._name.Leave += new System.EventHandler(this._field_Leave);
            this._name.Enter += new System.EventHandler(this._field_Enter);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this._cancelButton);
            this.flowLayoutPanel1.Controls.Add(this._okButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 500);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(839, 30);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(762, 2);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(683, 2);
            this._okButton.Margin = new System.Windows.Forms.Padding(2);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 0;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this._CurrencyTableView, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(837, 432);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // _CurrencyTableView
            // 
            this._CurrencyTableView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._CurrencyTableView.Location = new System.Drawing.Point(3, 3);
            this._CurrencyTableView.Name = "_CurrencyTableView";
            this._CurrencyTableView.ReadOnly = false;
            this._CurrencyTableView.Size = new System.Drawing.Size(831, 426);
            this._CurrencyTableView.TabIndex = 0;
            // 
            // BillingCurrencyManagerComponentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "BillingCurrencyManagerComponentControl";
            this.Size = new System.Drawing.Size(846, 534);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _clearButton;
        private System.Windows.Forms.Button _searchButton;
        private ClearCanvas.Desktop.View.WinForms.TextField _id;
        private ClearCanvas.Desktop.View.WinForms.TextField _name;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ClearCanvas.Desktop.View.WinForms.TableView _CurrencyTableView;
        private System.Windows.Forms.Button btnSetPrimaryCurrnency;
        private System.Windows.Forms.Button button1;
        
    }
}
