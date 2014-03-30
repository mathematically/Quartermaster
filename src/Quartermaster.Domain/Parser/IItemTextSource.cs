using System;

namespace Mathematically.Quartermaster.Domain.Parser
{
    public interface IItemTextSource
    {
        event EventHandler<GameItemChangedEventArgs> ItemTextArrived;
        string ItemText { get; }
        bool HasItemText();
    }
}