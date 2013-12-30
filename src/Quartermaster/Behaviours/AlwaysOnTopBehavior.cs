using System.Windows;
using System.Windows.Interactivity;

namespace Mathematically.Quartermaster.Behaviours
{
    public class AlwaysOnTopBehavior : Behavior<Window>
    {
        protected override void OnAttached( )
        {
            base.OnAttached();
            AssociatedObject.LostFocus += (s, e) => AssociatedObject.Topmost = true;
        }
    }
}