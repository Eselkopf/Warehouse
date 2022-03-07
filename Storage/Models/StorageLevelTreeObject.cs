namespace Storage.Models
{
    public class StorageLevelTreeObject
    {
        public int ParentId { get; set; }
        public int ChildId { get; set; }
        public int Level { get; set; }
        public int UserId { get; set; }

        public StorageLevel Parent { get; set; }

        public StorageLevel Child { get; set; }
    }
}
