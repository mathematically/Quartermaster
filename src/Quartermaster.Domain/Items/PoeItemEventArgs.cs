using System;

namespace Mathematically.Quartermaster.Domain.Items
{
    public class PoeItemEventArgs : EventArgs
    {
        public IPoeItem PoeItem { get; private set; }

        public PoeItemEventArgs(IPoeItem poeItem)
        {
            PoeItem = poeItem;
        }
    }
}