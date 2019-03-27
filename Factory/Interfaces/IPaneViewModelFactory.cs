using DockingTempate.Model.Interfaces;
using DockingTempate.ViewModels.Interfaces;

namespace DockingTempate.Factory.Interfaces
{
    public interface IPaneViewModelFactory
    {
        IPaneViewModel CreateNewPaneViewModel(IData data);
    }
}