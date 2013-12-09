using System;
using Mathematically.Quartermaster.Domain;
using Mathematically.Quartermaster.Domain.Items;

namespace Mathematically.Quartermaster.ViewModel
{
    public class QuartermasterViewModel: IDisposable
    {
        private readonly IQuartermaster _quartermaster;
        public IPoeItem Item { get { return _quartermaster.Item; } }

        public QuartermasterViewModel(IQuartermaster quartermaster)
        {
            _quartermaster = quartermaster;
        }

        public void Dispose()
        {
            _quartermaster.Dispose();
        }
    }
}