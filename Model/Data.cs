using DockingTempate.Model.Interfaces;

namespace DockingTempate.Model
{
    public class Data : IData
    {
        public Data(string header, int id, string name)
        {
            Text = header;
            Id = id;
            Name = name;
        }
        public string Name { get; }
        public string Text { get; set; }
        public int Id { get; }
    }
}
