using System.Collections.Generic;

namespace Övning6.Menus
{
    public interface IMenu
    {
        public Dictionary<Option<int>, MenuEntity> Instance { get; }
    }
}