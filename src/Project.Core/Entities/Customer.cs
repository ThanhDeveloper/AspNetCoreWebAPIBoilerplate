namespace Project.Core.Entities
{
    public class Customer: BaseEntity
    {
        public string Name { set; get; }
        public string Country { set; get; }
        public string Phone { set; get; }
    }
}
