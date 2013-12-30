using Caliburn.Micro;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.ViewModels
{
    public class HUDViewModel : Screen
    {
        private readonly IQuartermaster _quartermaster;
        private IPoeItem _item;

        public HUDViewModel(IQuartermaster quartermaster)
        {
            _quartermaster = quartermaster;

            Item = _quartermaster.Item;

            _quartermaster.PoeItemArrived += (sender, args) => Item = _quartermaster.Item;
        }

        public IPoeItem Item
        {
            get { return _item; }
            private set
            {
                _item = value;
                NotifyOfPropertyChange(() => Item);
            }
        }
    }
}