using DockingTempate.Model.Interfaces;

namespace DockingTempate.ViewModels
{
    public class DataViewModel : PaneViewModel
    {
        private readonly IData _data;

        public DataViewModel(int id, IData data) : base(id)
        {
            _data = data;
            DisplayName = Header;
            Header = data.Name;
        }

        public string Text
        {
            get { return _data.Text; }
            set
            {
                _data.Text = value;
                NotifyOfPropertyChange(() => Header);
            }
        }
    }
}
