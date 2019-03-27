using DockingTempate.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockingTempate.Factory.Interfaces
{
    public interface IDataFactory
    {
        IData GetData();
    }
}