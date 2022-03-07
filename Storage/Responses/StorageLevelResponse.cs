using Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Responses
{
    public class StorageLevelResponse
    {
        public IEnumerable<StorageLevel> StorageLevels { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
