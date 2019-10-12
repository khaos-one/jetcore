using System;
using Khaos.Core.Extensions;

namespace Khaos.Core.Contracts.Web
{
    public class IdNameDto<TId> 
        : IIdentifiable<TId>, INameable
    {
        public TId Id { get; set; }
        
        public string Name { get; set; }
    }
}
