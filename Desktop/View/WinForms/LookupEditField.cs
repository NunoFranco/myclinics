#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ClearCanvas.Desktop.View.WinForms
{
    public partial class LookupEditField : UserControl
	{
		class WellBehavedLookupBox : DevExpress.XtraEditors.LookUpEdit 
		{
			protected override void OnCreateControl()
			{
				base.OnCreateControl();

				// if the DataSource property was set, the SelectedItem will be
				// set to the first value in the DataSource list, which means it
				// may be out of since with the value it is bound to on the app component
				// we can fix this by setting it to null here
				this.EditValue  = null;
			}
		}

        public LookupEditField()
		{
			InitializeComponent();
		}

        //public event ListControlConvertEventHandler Format
        //{
        //    add { _LookupBox.Format += value; }
        //    remove { _LookupBox.Format -= value; }
        //}

		[Localizable(true)]
		public string LabelText
		{
			get { return _label.Text; }
			set { _label.Text = value; }
		}

        //public ComboBoxStyle DropDownStyle
        //{
        //    get { return _LookupBox.DropDownStyle; }
        //    set { _LookupBox.DropDownStyle = value; }
        //}

		public object Value
		{
			get { return _LookupBox.EditValue ; }
			set
			{
				// Conver DBNUll to null.  If this is not done and a property bound to Value is set to null,
				// the displayed value of the combo box is not updated correctly.
				if (value is DBNull)
				{
                    _LookupBox.EditValue = null;
				}
				else
				{
                    _LookupBox.EditValue = value;
				}
			}
		}

		public event EventHandler ValueChanged
		{
			// use pass through event subscription
			add { _LookupBox.EditValueChanged  += value; }
            remove { _LookupBox.EditValueChanged -= value; }
		}

		public new string Text
		{
			get { return _LookupBox.Text; }
			set { _LookupBox.Text = value; }
		}

		public new event EventHandler TextChanged
		{
			add { _LookupBox.TextChanged += value; }
			remove { _LookupBox.TextChanged -= value; }
		}

		public object DataSource
		{
			get { return _LookupBox.Properties.DataSource ; }
			set
			{
				// Conver DBNUll to null.  If this is not done and a property bound to Value is set to null,
				// the displayed value of the combo box is not updated correctly.
				if (value is DBNull)
				{
					_LookupBox.Properties.DataSource  = null;
				}
				else
				{
                    _LookupBox.Properties.DataSource = value;
				}
			}
		}

		public string DisplayMember
		{
            get { return _LookupBox.Properties.DisplayMember; }
            set { _LookupBox.Properties.DisplayMember = value; }
		}
	}
}
