using Caliburn.Micro;
using Telerik.Windows.Controls.Docking;

namespace DockingTempate.ViewModels.Interfaces
{
    public interface IPaneViewModel : IScreen
    {
        bool CanUserClose { get; }
        string Header { get; set; }
        DockState InitialPosition { get; set; }
        bool IsPaneActive { get; set; }
        bool IsHidden { get; set; }
        bool IsDocument { get; }
        bool IsSelected { get; set; }
        bool CanFloat { get; }
        int Id { get; }
    }
}