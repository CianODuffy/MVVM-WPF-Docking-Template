using Caliburn.Micro;
using DockingTempate.ViewModels.Interfaces;
using Telerik.Windows.Controls.Docking;

namespace DockingTempate.ViewModels
{
    public abstract class PaneViewModel : Screen, IPaneViewModel
    {
        private DockState _initialPosition;
        private bool _isHidden;
        private bool _isDocument;
        private bool _isSelected;
        private bool _isPaneActive;
        public int Id { get; }

        protected PaneViewModel(int id)
        {
            Id = id;
            IsDocument = true;
            CanUserClose = true;
            CanFloat = true;
        }
        public bool CanUserClose { get; protected set; }
        public bool CanFloat { get; protected set; }

        public string Header
        {
            get
            {
                return DisplayName;
            }
            set
            {
                if (DisplayName != value)
                {
                    DisplayName = value;
                    NotifyOfPropertyChange(() => Header);
                }
            }
        }

        public DockState InitialPosition
        {
            get
            {
                return _initialPosition;
            }
            set
            {
                if (_initialPosition != value)
                {
                    _initialPosition = value;
                    NotifyOfPropertyChange(() => InitialPosition);
                }
            }
        }

        public bool IsPaneActive
        {
            get { return _isPaneActive; }
            set
            {
                _isPaneActive = value;
                NotifyOfPropertyChange(() => IsPaneActive);
            }
        }

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    NotifyOfPropertyChange(() => IsSelected);
                }
            }
        }


        public bool IsHidden
        {
            get
            {
                return _isHidden;
            }
            set
            {
                if (_isHidden != value)
                {
                    _isHidden = value;
                    NotifyOfPropertyChange(() => IsHidden);
                }
            }
        }


        public bool IsDocument
        {
            get
            {
                return _isDocument;
            }
            set
            {
                if (_isDocument != value)
                {
                    _isDocument = value;
                    NotifyOfPropertyChange(() => IsDocument);
                }
            }
        }
    }
}