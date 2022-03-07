namespace Storage.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StorageLevelId { get; set; }
        public int UserId { get; set; }

        public StorageLevel StorageLevel { get; set; }
    }
}
