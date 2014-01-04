using Caliburn.Micro;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.ViewModels
{
    public class ItemViewModel : Screen
    {
        private readonly IQuartermaster _quartermaster;
        private IPoeItem _item;
        private IPoeWeapon _weapon;

        protected ItemViewModel(IQuartermaster quartermaster)
        {
            _quartermaster = quartermaster;

            Item = _quartermaster.Item;

            _quartermaster.PoeItemArrived += _quartermaster_PoeItemArrived;
        }

        void _quartermaster_PoeItemArrived(object sender, PoeItemEventArgs e)
        {
            Item = _quartermaster.Item;
            Weapon = _quartermaster.Item;
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

        public IPoeWeapon Weapon
        {
            get { return _weapon; }
            private set
            {
                _weapon = value;
                NotifyOfPropertyChange(() => Weapon);
            }
        }
    }
}