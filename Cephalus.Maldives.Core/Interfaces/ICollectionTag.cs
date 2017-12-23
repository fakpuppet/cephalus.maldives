using Cephalus.Maldives.Core.Models;
using System.Collections.Generic;

namespace Cephalus.Maldives.Core.Interfaces
{
    public interface ICollectionTag<TCollection> where TCollection: Tag
    {
        ICollection<TCollection> Tags { get; set; }
    }
}
