namespace SignalR_WinForm.Models
{
    public class Cbx_Item
    {
        public Cbx_Item(string name, string value, int order = -1)
        {
            this.Name = name;
            this.Value = value; 

            this.Order = order == -1 ? this.Order + 1 : order;
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public int Order { get; set; }
    }
}