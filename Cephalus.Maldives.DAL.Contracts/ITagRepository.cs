using Cephalus.Maldives.Core.Models;
using System;

namespace Cephalus.Maldives.DAL.Contracts
{
    public interface ITagRepository
    {
        Tag Get(Guid id);
    }
}
