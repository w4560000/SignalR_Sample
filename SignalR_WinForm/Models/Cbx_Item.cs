namespace SignalR_WinForm.Models
{
    public class Cbx_Item
    {
        public Cbx_Item(string name, string value, int order)
        {
            this.Name = name;
            this.Value = value;
            this.Order = order;
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public int Order { get; set; }
    }
}