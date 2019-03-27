using Caliburn.Micro;
using DockingTempate.ViewModels.Interfaces;
using System.Linq;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Docking;

namespace DockingTempate.Factory
{
    public class CustomDockingPanesFactory : DockingPanesFactory
    {
        protected override void AddPane(RadDocking radDocking, RadPane pane)
        {
            var paneModel = pane.DataContext as IPaneViewModel;
            if (paneModel != null && !(paneModel.IsDocument))
            {
                RadPaneGroup group = null;
                switch (paneModel.InitialPosition)
                {
                    case DockState.DockedRight:
                        group = radDocking.SplitItems.ToList().FirstOrDefault(i => i.Control.Name == "rightGroup") as RadPaneGroup;
                        if (group != null)
                        {
                            group.Items.Add(pane);

                        }
                        return;
                    case DockState.DockedBottom:
                        group = radDocking.SplitItems.ToList().FirstOrDefault(i => i.Control.Name == "bottomGroup") as RadPaneGroup;
                        if (group != null)
                        {
                            group.Items.Add(pane);
                        }
                        return;
                    case DockState.DockedLeft:
                        group = radDocking.SplitItems.ToList().FirstOrDefault(i => i.Control.Name == "leftGroup") as RadPaneGroup;
                        if (group != null)
                        {
                            group.Items.Add(pane);
                        }
                        return;
                    case DockState.FloatingDockable:
                        var fdSplitContainer = radDocking.GeneratedItemsFactory.CreateSplitContainer();
                        group = radDocking.GeneratedItemsFactory.CreatePaneGroup();
                        fdSplitContainer.Items.Add(group);
                        group.Items.Add(pane);
                        radDocking.Items.Add(fdSplitContainer);
                        pane.MakeFloatingDockable();
                        return;
                    case DockState.FloatingOnly:
                        var foSplitContainer = radDocking.GeneratedItemsFactory.CreateSplitContainer();
                        group = radDocking.GeneratedItemsFactory.CreatePaneGroup();
                        foSplitContainer.Items.Add(group);
                        group.Items.Add(pane);
                        radDocking.Items.Add(foSplitContainer);
                        pane.MakeFloatingOnly();
                        return;
                    case DockState.DockedTop:
                    default:
                        return;
                }
            }

            base.AddPane(radDocking, pane);
        }

        protected override RadPane CreatePaneForItem(object item)
        {
            var viewModel = item as IPaneViewModel;
            if (viewModel != null)
            {
                RadPane pane;

                if (viewModel.IsDocument)
                {
                    pane = new RadDocumentPane();
                }
                else
                {
                    pane = new RadPane();
                    pane.Width = 600;
                }
                pane.DataContext = item;
                pane.SetValue(View.IsGeneratedProperty, true);
                RadDocking.SetSerializationTag(pane, viewModel.Header);
                pane.Content = ViewLocator.LocateForModel(viewModel, null, null);
                ViewModelBinder.Bind(viewModel, pane, null);
                viewModel.IsPaneActive = true;
                viewModel.IsSelected = true;
                return pane;
            }
            return base.CreatePaneForItem(item);
        }

        protected override void RemovePane(RadPane pane)
        {
            pane.DataContext = null;
            pane.Content = null;
            pane.ClearValue(RadDocking.SerializationTagProperty);
            pane.RemoveFromParent();
        }
    }
}
