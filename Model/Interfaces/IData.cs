using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockingTempate.Model.Interfaces
{
    public interface IData
    {
        string Text { get; set; }
        int Id { get; }
        string Name { get; }
    }
}