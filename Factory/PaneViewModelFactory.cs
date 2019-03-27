using DockingTempate.Factory.Interfaces;
using DockingTempate.Model.Interfaces;
using DockingTempate.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockingTempate.Factory
{
    public class PaneViewModelFactory : IPaneViewModelFactory
    {
        public IPaneViewModel CreateNewPaneViewModel(IData data)
        {
            return null;

            //return new DataViewModel(data.Id, data);
        }
    }
}
