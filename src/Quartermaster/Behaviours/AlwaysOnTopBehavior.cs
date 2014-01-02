using System.Windows;
using System.Windows.Interactivity;

namespace Mathematically.Quartermaster.Behaviours
{
    public class AlwaysOnTopBehavior : Behavior<Window>
    {
        protected override void OnAttached( )
        {
            AssociatedObject.Topmost = true;

            base.OnAttached();
            AssociatedObject.LostFocus += (s, e) => AssociatedObject.Topmost = true;
        }
    }
}