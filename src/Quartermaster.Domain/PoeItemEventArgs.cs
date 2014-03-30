using System;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.Domain
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