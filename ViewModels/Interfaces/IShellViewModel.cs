﻿using Caliburn.Micro;
using DockingTempate.Model.Interfaces;
using System;

namespace DockingTempate.ViewModels.Interfaces
{
    public interface IShellViewModel : IConductor
    {
        void CreateNewDocument(IPaneViewModel paneVM);
        void FindOpenPane(Func<IPaneViewModel, bool> identityFunction);
        void CloseAllPanes();
        void CloseSpecifiedPanes(Func<IPaneViewModel, bool> identityFunction);

        void FindOrCreateDocument(Func<IPaneViewModel, bool> identityFunction,
            IData item);
    }
}
