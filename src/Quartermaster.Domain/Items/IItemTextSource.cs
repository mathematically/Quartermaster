using System;

namespace Mathematically.Quartermaster.Domain.Items
{
    public interface IItemTextSource
    {
        event EventHandler<GameItemChangedEventArgs> ItemTextArrived;
    }
}