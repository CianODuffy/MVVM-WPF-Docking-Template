using DockingTempate.Factory.Interfaces;
using DockingTempate.Model;
using DockingTempate.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockingTempate.Factory
{
    public class DataFactory : IDataFactory
    {
        private int _index = 0;
        private readonly string _prefix = "Data ", _text = "Type your text here...";

        public IData GetData()
        {
            _index++;
            return new Data(_text, _index, _prefix + _index);
        }
    }
}
