using System.Windows.Forms;
using ClearCanvas.Desktop.View.WinForms;

namespace ClearCanvas.Ris.Client.View.WinForms
{
    /// <summary>
    /// Provides a Windows Forms user-interface for <see cref="StaffGroupDetailsEditorComponent"/>.
    /// </summary>
    public partial class StaffGroupDetailsEditorComponentControl : ApplicationComponentUserControl
    {
        private StaffGroupDetailsEditorComponent _component;

        /// <summary>
        /// Constructor.
        /// </summary>
        public StaffGroupDetailsEditorComponentControl(StaffGroupDetailsEditorComponent component)
            :base(component)
        {
			_component = component;
            InitializeComponent();

			_name.DataBindings.Add("Value", _component, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
			_description.DataBindings.Add("Value", _component, "Description", true, DataSourceUpdateMode.OnPropertyChanged);
			_electiveCheckbox.DataBindings.Add("Checked", _component, "IsElective", true, DataSourceUpdateMode.OnPropertyChanged);
            //_cboFacilityChoices.DataBindings.Add("SelectedItem", _component, "SelectedFacility", true, DataSourceUpdateMode.OnPropertyChanged);
		}
    }
}
