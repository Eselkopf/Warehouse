namespace Storage.Models
{
    public class StorageLevel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public IEnumerable<Item> Items { get; set; } 
            = Enumerable.Empty<Item>();
        public IEnumerable<StorageLevelTreeObject> StorageLevelTreeObjects { get; set; } 
            = Enumerable.Empty<StorageLevelTreeObject>();
    }
}
