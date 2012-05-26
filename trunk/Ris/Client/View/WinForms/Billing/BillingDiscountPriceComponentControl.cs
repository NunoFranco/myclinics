#region License

// Copyright (c) 2010, ClearCanvas Inc.
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.View.WinForms;
using ClearCanvas.Common;
using ClearCanvas.Ris.Application.Common.Billing;
using DevExpress.XtraEditors.Controls;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Ris.Application.Common.Admin.DiagnosticServiceAdmin;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ClearCanvas.Ris.Client.Billing;
namespace ClearCanvas.Ris.Client.View.WinForms.Billing
{
    //public enum DiscountAmountType{
    //    PERCENT ,
    //    REDUCEAMOUNT,
    //    FIXEDPRICE 
    //}
    /// <summary>
    /// Provides a Windows Forms user-interface for <see cref="BillingDiscountPriceComponent"/>.
    /// </summary>
    /// 

    public partial class BillingDiscountPriceComponentControl : ApplicationComponentUserControl
    {
        private BillingDiscountPriceComponent _component;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// 
        public DiscountRuleSummary ObjectSummary { get; set; }
        public DiscountRuleDetail ObjectDetail { get; set; }
        private List<string> NodeValue;
        private List<string> NodeValueUP;
        private List<TreeView> treeView;
        private List<TreeView> treeViewUP;
        private List<bool> ListChecked;
        private List<bool> ListCheckedUP;
        public List<DiscountRuleDetail> ListDiscount;
        public List<DiscountRuleDetail> ListDiscountUP;
        public List<BindGrid> ListBindGrid;
        private int pointIDParent;
        
        public IList<BindGrid> bindingSource;
        public class BindGrid
        {
            public string TypeCode;
            public string TypeName;
            //public string Code;
            //public string Name;
            public string Type;
            public decimal Amount;
        }

        public BillingDiscountPriceComponentControl(BillingDiscountPriceComponent component)
            : base(component)
        {
            _component = component;
            InitializeComponent();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = _component;
            //BindClasses();
            // TODO add .NET databindings to bindingSource
            bindTreeView();

            //.DataBindings.Add("Value", _component, "ListCheck", false, DataSourceUpdateMode.OnPropertyChanged);

            bindData();


            
        }
        void BindClasses()
        {

            this.cmbClasses.Properties.Items.Clear();
            string displayFormat = ClearCanvas.Ris.Application.Common.Billing.Constant.ComboDisplayFormat;
            foreach (var item in _component.ClassChoice)
            {
                ImageComboBoxItem subItem = new ImageComboBoxItem("", string.Format(displayFormat, item.Code, item.Name), -1);
                subItem.Value = string.Format(displayFormat, item.Code, item.Name);
                subItem.Description = item.DiscountRef.ToString();
                this.cmbClasses.Properties.Items.Add(subItem);

            }
            //this.cmbClasses.Properties.Items.AddRange(_component.ClassChoice);
        }
        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

        }

        

        private void cmbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void bindData()
        {
            cmbClasses.Properties.Items.AddRange(_component.DiscountTypeEnumValueList.ToArray());
            foreach (var item in Enum.GetNames(typeof(DisCountInsuranceAmountType)))
            {                
                comboBoxAmountType.Properties.Items.Add(DiscountAmountTypeEnumText(item));
            }
            comboBoxAmountType.Properties.Items.Remove(DiscountAmountTypeEnumText(DisCountInsuranceAmountType.FIXEDPRICE.ToString()));
            bindingSource = new List<BindGrid>();

        }

        
        private void simpleButtonAdd_Click(object sender, EventArgs e)//add to DB
        {
            decimal result = 0;
            if (cmbClasses.SelectedIndex >= 0 && comboBoxAmountType.SelectedIndex >= 0 && decimal.TryParse(textEditAmount.Text, out result))
            {
                List<DiscountRuleDetail> checkedList = checkedItem();
                
                if(checkedList.Count>0)
                {
                    if (!_component.Save(checkedList, cmbClasses.SelectedIndex))
                        Platform.ShowMessageBox(SR.DiscountInsuranceRulesExisting);
                    
                }
                    BindingSource bindingSourceGrid = new BindingSource();
                    bindingSourceGrid.DataSource = _component.BindProcedureType(_component.DiscountTypeEnumCode(cmbClasses.SelectedIndex));
                    this.gridControlList.DataSource = bindingSourceGrid;

            }
            else
            {
                Platform.ShowMessageBox(SR.DiscountInsuranceItemRuleNotSelected);
                if (textEditAmount.Text != "")
                    textEditAmount.Focus();
                if (comboBoxAmountType.SelectedIndex < 0)
                    comboBoxAmountType.Focus();
                if(cmbClasses.SelectedIndex<0)
                cmbClasses.Focus();

            }

        }

        

        private void bindTreeView()
        {


            repositoryItemCheckEdit2.CheckedChanged += new EventHandler(repositoryItemCheckEdit2_CheckedChanged);
            repositoryItemCheckEdit3.CheckedChanged += new EventHandler(repositoryItemCheckEdit3_CheckedChanged);

            try
            {
                
                List<ClearCanvas.Ris.Application.Common.DiagnosticServiceSummary> listItem=null; 
                   ClearCanvas.Common.Platform.GetService<IDiagnosticServiceAdminService>(delegate (IDiagnosticServiceAdminService service)
                   {
                       listItem = service.ListDiagnosticServices(
                       new ListDiagnosticServicesRequest()).DiagnosticServices;
                   });

                NodeValue = new List<string>();
                NodeValueUP = new List<string>();
                ListChecked = new List<bool>();
                ListCheckedUP = new List<bool>();
                treeView = new List<TreeView>();
                treeViewUP = new List<TreeView>();
                ListDiscount = new List<DiscountRuleDetail>();
                ListDiscountUP = new List<DiscountRuleDetail>();

                
                DiscountRuleDetail discountDetail;
                foreach (var item in listItem)
                {
                    List<ClearCanvas.Ris.Application.Common.ProcedureTypeSummary> listChildItem=null;
                        ClearCanvas.Common.Platform.GetService<IDiagnosticServiceAdminService>(delegate (IDiagnosticServiceAdminService service){

                            listChildItem = service.LoadDiagnosticServiceForEdit(
                        new LoadDiagnosticServiceForEditRequest(item.DiagnosticServiceRef))
                        .DiagnosticService.ProcedureTypes;});
                    

                    if (item.IsPackageProcedure)
                    {
                        
                        NodeValue.Add(item.Name);
                        
                        TreeView tvp = new TreeView();
                        tvp.Nodes.Add(item.Id);
                        tvp.Nodes[0].ToolTipText = item.Name;


                        discountDetail = new DiscountRuleDetail();                       

                        //discountDetail.ProcedureTypeRef = item.DiagnosticServiceRef;

                        ListDiscount.Add(discountDetail);


                        treeView.Add(tvp);
                        foreach (var childItem in listChildItem)
                        {
                            
                            NodeValue.Add(childItem.Name);
                            
                            TreeView tv = new TreeView();
                            tv.Nodes.Add(item.Id);
                            tv.Nodes[0].Nodes.Add(childItem.Id);
                            tv.Nodes[0].Nodes[0].ToolTipText = childItem.Name;
                            treeView.Add(tv);

                            discountDetail = new DiscountRuleDetail();
                            
                            discountDetail.ProcedureTypeRef = childItem.ProcedureTypeRef;


                            ListDiscount.Add(discountDetail);

                        }
                    }
                    else
                    {
                        
                        NodeValueUP.Add(item.Name);
                        
                        TreeView tvp = new TreeView();
                        tvp.Nodes.Add(item.Id);
                        tvp.Nodes[0].ToolTipText = item.Name;
                        treeViewUP.Add(tvp);
                        discountDetail = new DiscountRuleDetail();
                        
                        //discountDetail.ProcedureTypeRef = item.DiagnosticServiceRef;
                        ListDiscountUP.Add(discountDetail);
                        foreach (var childItem in listChildItem)
                        {
                            
                            NodeValueUP.Add(childItem.Name);
                           
                            TreeView tv = new TreeView();
                            tv.Nodes.Add(item.Id);
                            tv.Nodes[0].Nodes.Add(childItem.Id);
                            tv.Nodes[0].Nodes[0].ToolTipText = childItem.Name;
                            treeViewUP.Add(tv);
                            discountDetail = new DiscountRuleDetail();
                            
                            discountDetail.ProcedureTypeRef = childItem.ProcedureTypeRef;

                            ListDiscountUP.Add(discountDetail);
                        }
                    }


                    

                }
            }
            catch (Exception e)
            {
                
            }



            pointIDParent = -1;
            treeListPackage.BeginUnboundLoad();
            for (int id = 0; id < treeView.Count; id++)
            
            {
                
                AppendChild(treeView[id], NodeValue, id, treeListPackage);
                ListChecked.Add(false);

            }
            treeListPackage.EndUnboundLoad();
            pointIDParent = -1;
            treeListUnPackage.BeginUnboundLoad();
            for (int id = 0; id < treeViewUP.Count; id++)
            
            {
                        
                AppendChild(treeViewUP[id], NodeValueUP, id, treeListUnPackage);
                ListCheckedUP.Add(false);
            }
            treeListUnPackage.EndUnboundLoad();

        }


        private string seperator = "\\";
        private void AppendChild(TreeView tv, List<string> value, int idRow, DevExpress.XtraTreeList.TreeList tree)
        {

            if (tv.Nodes[0].Nodes.Count == 0)
            {
                tree.AppendNode(new object[] { tv.Nodes[0].Text, value[idRow], null, idRow}, -1);
                //treeList1.Nodes[idRow].TreeList.VisibleColumns[1].Visible = false;
                pointIDParent = idRow;
            }
            else
            {
                tree.AppendNode(new object[] { tv.Nodes[0].Nodes[0].Text, value[idRow], null, idRow}, pointIDParent);
                //treeList1.Nodes[idRow].TreeList.VisibleColumns[1].Visible = false;
            }
        }

        private DevExpress.XtraTreeList.Nodes.TreeListNode Node(DevExpress.XtraTreeList.Nodes.TreeListNode parent, string Path)
        {
            if (Path.IndexOf(seperator) < 0)
                return parent.Nodes.TreeList.FindNodeByFieldValue("Code", Path);
            else
            {
                return null;
            }
        }





        
        private void repositoryItemCheckEdit2_CheckedChanged(object sender, System.EventArgs e)
        {
            ListCheckedUP[treeListUnPackage.Selection[0].Id] =
                !ListCheckedUP[treeListUnPackage.Selection[0].Id];

            bool check = !treeListUnPackage.Selection[0].Checked;


            if (treeListUnPackage.Selection[0].Level == 0)
            {
                treeListUnPackage.Selection[0].ExpandAll();
                for (int index = 0; index < treeListUnPackage.Selection[0].Nodes.Count; index++)
                {

                    treeListUnPackage.Selection[0].Nodes[index].SetValue(treeListColumn3, check);
                    ListCheckedUP[treeListUnPackage.Selection[0].Nodes[index].Id] = treeListUnPackage.Selection[0].Checked;

                }
                treeListUnPackage.Selection[0].SetValue(treeListColumn3, check);//set true
                treeListUnPackage.Selection[0].Checked = check;//set false
            }
            else
            {
                if (!treeListUnPackage.Selection[0].Checked && treeListUnPackage.Selection[0].ParentNode.Checked)
                {
                    treeListUnPackage.Selection[0].ParentNode.SetValue(treeListColumn3, false);
                    treeListUnPackage.Selection[0].ParentNode.Checked = false;
                    treeListUnPackage.Selection[0].SetValue(treeListColumn3, false);
                    treeListUnPackage.Selection[0].Checked = false;
                }
            }
        }

        private void repositoryItemCheckEdit3_CheckedChanged(object sender, System.EventArgs e)
        {
            ListChecked[treeListPackage.Selection[0].Id] =
                !ListChecked[treeListPackage.Selection[0].Id];

            bool check = !treeListPackage.Selection[0].Checked;


            if (treeListPackage.Selection[0].Level == 0)
            {
                treeListPackage.Selection[0].ExpandAll();
                for (int index = 0; index < treeListPackage.Selection[0].Nodes.Count; index++)
                {

                    treeListPackage.Selection[0].Nodes[index].SetValue(treeListColumn3, check);
                    ListChecked[treeListPackage.Selection[0].Nodes[index].Id] = treeListPackage.Selection[0].Checked;

                }
                treeListPackage.Selection[0].SetValue(treeListColumn3, check);//set true
                treeListPackage.Selection[0].Checked = check;//set false
            }
            else
            {
                if (!treeListPackage.Selection[0].Checked && treeListPackage.Selection[0].ParentNode.Checked)
                {
                    treeListPackage.Selection[0].ParentNode.SetValue(treeListColumn3, false);
                    treeListPackage.Selection[0].ParentNode.Checked = false;
                    treeListPackage.Selection[0].SetValue(treeListColumn3, false);
                    treeListPackage.Selection[0].Checked = false;
                }
            }
        }

        private bool IsExists(string parent, List<TreeView> list)
        {
            bool rs = false;
            int lastTreeIndex = list.Count;
            if (lastTreeIndex > 0)
            {
                rs = parent == list[lastTreeIndex - 1].Nodes[0].Text;
            }

            return rs;
        }

        public List<TreeView> checkedTreeItem()
        {
            List<TreeView> tv = new List<TreeView>();

            for (int index = 0; index < ListChecked.Count; index++)
            {
                if (ListChecked[index])
                {
                    if (!IsExists(treeView[index].Nodes[0].Text, tv))
                    {
                        TreeView parent = new TreeView();
                        parent.Nodes.Add(treeView[index].Nodes[0].Text);
                        tv.Add(parent);
                    }
                    if (treeView[index].Nodes[0].Nodes.Count > 0)
                    {
                        tv.Add(treeView[index]);
                    }

                }
            }

            for (int index = 0; index < ListCheckedUP.Count; index++)
            {
                if (ListCheckedUP[index]) tv.Add(treeViewUP[index]);
            }
            return tv;
        }

        public List<DiscountRuleDetail> checkedItem()
        {
            List<DiscountRuleDetail> drd = new List<DiscountRuleDetail>();
            string ClassIDCode = _component.DiscountTypeEnumCode(cmbClasses.SelectedIndex);
            string ClassIDValue = _component.DiscountTypeEnumValue(cmbClasses.SelectedIndex);
            DisCountInsuranceAmountType DiscountAmountTypeSelected = DiscountAmountTypeEnumCode(comboBoxAmountType.SelectedIndex);
            decimal amount = GetAmount();


            
            foreach(DevExpress.XtraTreeList.Nodes.TreeListNode node in treeListPackage.Nodes)
            {
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode child in node.Nodes)
                    if (child.GetValue(2) == null ? false : (bool)child.GetValue(2))
                {
                    ListDiscount[child.Id].ClassIDCode = ClassIDCode;
                    ListDiscount[child.Id].ClassIDValue = ClassIDValue;
                    ListDiscount[child.Id].AmountType = DiscountAmountTypeSelected;
                    ListDiscount[child.Id].Amount = amount;
                    drd.Add(ListDiscount[child.Id]);
                }
            }

           
            foreach(DevExpress.XtraTreeList.Nodes.TreeListNode node in treeListUnPackage.Nodes)
            {
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode child in node.Nodes)

                    if (child.GetValue(2) == null ? false : (bool)child.GetValue(2))
                {
                    ListDiscountUP[child.Id].ClassIDCode = ClassIDCode;
                    ListDiscountUP[child.Id].ClassIDValue = ClassIDValue;
                    ListDiscountUP[child.Id].AmountType = DiscountAmountTypeSelected;
                    ListDiscountUP[child.Id].Amount = amount;
                    drd.Add(ListDiscountUP[child.Id]);
                }
            }
           
            return drd;
        }

        

        private void textEditAmount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            {
                e.Handled = !(((DevExpress.XtraEditors.TextEdit)sender).SelectionStart != 0 && (e.KeyChar.ToString() ==
                    System.Windows.Forms.Application.CurrentCulture.NumberFormat.NumberDecimalSeparator &&
                    ((DevExpress.XtraEditors.TextEdit)sender).Text.IndexOf(System.Windows.Forms.Application.CurrentCulture.NumberFormat.NumberDecimalSeparator) == -1)) &&
                    e.KeyChar != Convert.ToChar(8);
            }
            else
            {
                if (DiscountAmountTypeEnumCode(comboBoxAmountType.SelectedIndex) == 
                    DisCountInsuranceAmountType.PERCENTAGE)
                {
                    try
                    {
                        e.Handled = Convert.ToDecimal(textEditAmount.Text + e.KeyChar) > 100;
                    }
                    catch
                    {
                    }
                    
                } 
            }

        }

       

        public decimal GetAmount()
        {
            decimal res = 0;
            try
            {
                res = Convert.ToDecimal(textEditAmount.Text);
            }
            catch
            {
                textEditAmount.Focus();
            }
            return res;

        }

        private void cmbClasses_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //Platform.ShowMessageBox("Loaded");
            //this.comboBoxEdit1.Properties.Items.AddRange(new object[] { BindProcedureType().ToArray() });
            if (cmbClasses.SelectedIndex < 0)
                return;

            BindingSource bindingSourceGrid = new BindingSource();
            bindingSourceGrid.DataSource = _component.BindProcedureType(_component.DiscountTypeEnumCode(cmbClasses.SelectedIndex));
            this.gridControlList.DataSource = bindingSourceGrid;
        }

        

        
        private string DiscountAmountTypeEnumText(string Code)
        {
            string Text = "";
            if (Code == DisCountInsuranceAmountType.PERCENTAGE.ToString())
                Text = SR.PERCENTAGE;
            if (Code == DisCountInsuranceAmountType.REDUCEAMOUNT.ToString())
                Text = SR.REDUCEAMOUNT;
            if (Code == DisCountInsuranceAmountType.FIXEDPRICE.ToString())
                Text = SR.FIXEDPRICE;
            return Text;
        }

        public DisCountInsuranceAmountType DiscountAmountTypeEnumCode(int Index)
        {
            DisCountInsuranceAmountType type = DisCountInsuranceAmountType.PERCENTAGE;
            switch (Index)
            {
                case 0: type = DisCountInsuranceAmountType.PERCENTAGE;
                    break;
                case 1: type = DisCountInsuranceAmountType.REDUCEAMOUNT;
                    break;
                case 2: type = DisCountInsuranceAmountType.FIXEDPRICE;
                    break;

            }
            return type;
        }

        
        private void DoRowDoubleClick(DevExpress.XtraGrid.GridControl grdControl, Point pt)
        {
            GridHitInfo info = (GridHitInfo)grdControl.MainView.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                //string colCaption = info.Column == null ? "N/A" : info.Column.GetCaption();
                IDesktopWindow desktop = _component.ActiveWindow;
                BillingDiscountEditComponent form = new BillingDiscountEditComponent(gridView1.GetDataRow(info.RowHandle)[4].ToString());
                //Platform.ShowMessageBox(gridView1.GetDataRow(info.RowHandle)[4].ToString());
                //form.BindData(gridView1.GetDataRow(info.RowHandle)[4].ToString());
                
                _component.OpenEditDiscountForm(desktop, form);
                BindingSource bindingSourceGrid = new BindingSource();
                bindingSourceGrid.DataSource = _component.BindProcedureType(_component.DiscountTypeEnumCode(cmbClasses.SelectedIndex));
                this.gridControlList.DataSource = bindingSourceGrid;
                
            }
        }

        

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.GridControl control = (DevExpress.XtraGrid.GridControl)sender;
            Point pt = control.PointToClient(Control.MousePosition);
            DoRowDoubleClick(control, pt); 
        }

        private void cmbClasses_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBoxEditAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBoxAmountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisCountInsuranceAmountType DiscountAmountTypeSelected = DiscountAmountTypeEnumCode(comboBoxAmountType.SelectedIndex);
            
            if (DiscountAmountTypeSelected == DisCountInsuranceAmountType.PERCENTAGE)
            {
                int percentMax = 100;
                if (decimalAmount != null&&decimalAmount > percentMax) textEditAmount.Text = percentMax.ToString();
                textEditAmount.Properties.MaxLength = 6;
            }
            else
                textEditAmount.Properties.MaxLength = 13;
        }
        private void textEditAmount_Validating(object sender, CancelEventArgs e)
        {

            if (decimalAmount != null)
            {
                if (DiscountAmountTypeEnumCode(comboBoxAmountType.SelectedIndex) == DisCountInsuranceAmountType.PERCENTAGE)

                    e.Cancel = decimalAmount > 100;

                else
                    e.Cancel = textEditAmount.Text.Length > 14;
            }
        }

        private decimal? decimalAmount
        {
            get
            {
                decimal isdecimal = 0;
                if (decimal.TryParse(textEditAmount.Text, out isdecimal))
                {
                    return isdecimal;
                }
                else
                    return null;

            }
        }

    }
       
}
