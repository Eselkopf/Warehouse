using Storage.Context;
using Storage.Models;
using Storage.Responses;

namespace Storage.Handlers
{
    public class StorageHandler
    {
        private readonly StorageContext storageContext;

        public StorageHandler(StorageContext storageContext)
        {
            this.storageContext = storageContext;
        }

        public StorageLevelResponse GetStorageLevel(int? storageLevelId, int userId)
        {
            StorageLevel currentStorageLevel;
            if (storageLevelId == null)
            {
                currentStorageLevel = storageContext.StorageLevels.FirstOrDefault(x => x.UserId == userId);
            }
            else
            {
                currentStorageLevel = storageContext.StorageLevels.FirstOrDefault(x => x.Id == storageLevelId);
                if (currentStorageLevel.UserId != userId)
                    throw new Exception("Unauthorized");
            }
            var level = storageContext.StorageLevelTreeObjects
                .FirstOrDefault(x => x.ChildId == currentStorageLevel.Id).Level;

            var childLevels = storageContext.StorageLevelTreeObjects
                .Where(x => x.ParentId == currentStorageLevel.Id && x.Level == level + 1)
                .Select(x => x.Child);

            var childItems = currentStorageLevel.Items;

            var res = new StorageLevelResponse
            {
                Items = childItems,
                StorageLevels = childLevels.ToList()
            };

            return res;
        }
    
        public void AddStorageLevel(int parentId, string name, int userId)
        {
            var parent = storageContext.StorageLevels.FirstOrDefault(x => x.Id == parentId);
            if (parent.UserId != userId)
                throw new Exception("Unauthorized");
            var parentStorageLevel = storageContext.StorageLevelTreeObjects
                .Where(x => x.ParentId == parentId);
            var storageLevel = new StorageLevel
            { 
                Name = name 
            }
            storageContext.StorageLevels.Add()
        }
    }
}
