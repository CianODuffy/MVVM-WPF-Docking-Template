using DockingTempate.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace DockingTempate.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
            this.Loaded += OnLoaded;
        }


        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as ShellViewModel;
            if (viewModel != null)
            {
                viewModel.Load(this.ExplorerContainer);
            }
        }

        private void OnPreviewShowCompass(object sender, PreviewShowCompassEventArgs e)
        {
            bool isRootCompass = e.Compass is RootCompass;
            var splitContainer = e.DraggedElement as RadSplitContainer;
            if (splitContainer != null)
            {
                bool isDraggingDocument = splitContainer.EnumeratePanes().Any(p => p is RadDocumentPane);
                var isTargetDocument = e.TargetGroup == null ? true : e.TargetGroup.EnumeratePanes().Any(p => p is RadDocumentPane);
                if (isDraggingDocument)
                {
                    e.Canceled = isRootCompass || !isTargetDocument;
                }
                else
                {
                    e.Canceled = !isRootCompass && isTargetDocument;
                }
            }
        }
    }
}
