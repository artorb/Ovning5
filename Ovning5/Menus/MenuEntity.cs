using System;

namespace Övning6.Menus
{
    public class MenuEntity
    {
        public string Title { get; }
        private Action Action { get; }

        public MenuEntity(string title, Action action)
        {
            Title = title;
            Action = action;
        }
        public void Execute() => Action.Invoke();
    }
}