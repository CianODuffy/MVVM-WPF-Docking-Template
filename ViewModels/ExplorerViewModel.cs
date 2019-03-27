using Caliburn.Micro;
using DockingTempate.Factory.Interfaces;
using DockingTempate.ViewModels.Interfaces;
using System;
using Telerik.Windows.Controls.Docking;

namespace DockingTempate.ViewModels
{
    public class ExplorerViewModel : Screen, IExplorerViewModel
    {
        private readonly IDataFactory _dataFactory;

        public ExplorerViewModel(IDataFactory dataFactory)
        {
            _dataFactory = dataFactory;
            DisplayName = "Explorer";
            Header = DisplayName;
            IsDocument = false;
            CanUserClose = false;
            CanFloat = false;
            InitialPosition = DockState.DockedLeft;
        }

        public void AddDocument()
        {
            var data = _dataFactory.GetData();
            Func<IPaneViewModel, bool> identityFunction = x => x.Id.Equals(data.Id);
            IShellViewModel parent = (this.Parent as IShellViewModel);
            parent.FindOrCreateDocument(identityFunction, data);
        }


        public bool CanFloat { get; }
        public bool CanUserClose { get; }
        public string Header { get; set; }
        public DockState InitialPosition { get; set; }
        public bool IsPaneActive { get; set; }
        public bool IsHidden { get; set; }
        public bool IsDocument { get; }
        public bool IsSelected { get; set; }

        public int Id => -1; //explorer id
    }
}
