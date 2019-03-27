using DockingTempate.Factory.Interfaces;
using DockingTempate.Model.Interfaces;
using DockingTempate.ViewModels;
using DockingTempate.ViewModels.Interfaces;

namespace DockingTempate.Factory
{
    public class PaneViewModelFactory : IPaneViewModelFactory
    {
        public IPaneViewModel CreateNewPaneViewModel(IData data)
        {
            return new DataViewModel(data.Id, data);
        }
    }
}
