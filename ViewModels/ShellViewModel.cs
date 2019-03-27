using Caliburn.Micro;
using DockingTempate.Factory.Interfaces;
using DockingTempate.Model.Interfaces;
using DockingTempate.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace DockingTempate.ViewModels
{
    public class ShellViewModel : Conductor<IPaneViewModel>.Collection.AllActive, IShellViewModel
    {
        private RadSplitContainer _explorerContainer;
        private readonly IPaneViewModelFactory _paneFactory;

        public ShellViewModel(/*IExplorerViewModel explorerViewModel, */IPaneViewModelFactory paneFactory)
        {
            _paneFactory = paneFactory;
            //Items.Add(explorerViewModel);
        }

        public void Load(object param)
        {
            _explorerContainer = (RadSplitContainer)param;
        }

        public void FindOrCreateDocument(Func<IPaneViewModel, bool> identityFunction,
            IData item)
        {
            if (Items.Any(identityFunction))
            {
                FindOpenPane(identityFunction);
            }
            else
            {
                IPaneViewModel paneItem = _paneFactory.CreateNewPaneViewModel(item);
                CreateNewDocument(paneItem);
            }
        }


        public void CreateNewDocument(IPaneViewModel paneVM)
        {
            Items.Add(paneVM);
            paneVM.Activate();
        }
        public void FindOpenPane(Func<IPaneViewModel, bool> identityFunction)
        {
            IPaneViewModel identifiedPane = Items.First(identityFunction);
            if (!identifiedPane.IsSelected)
                identifiedPane.IsSelected = true;
        }

        public void CloseAllPanes()
        {
            Func<IPaneViewModel, bool> identityFunction = x => x is IPaneViewModel;
            CloseSpecifiedPanes(identityFunction);
        }

        public void CloseSpecifiedPanes(Func<IPaneViewModel, bool> identityFunction)
        {
            var removeList = new List<IPaneViewModel>();
            foreach (var item in Items)
            {
                if (item.IsDocument && identityFunction.Invoke(item))
                {
                    removeList.Add(item);
                }
            }

            foreach (var item in removeList)
                Items.Remove(item);
        }
    }
}
