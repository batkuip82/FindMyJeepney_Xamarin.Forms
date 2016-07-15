using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FJM_XF.Behaviours
{
    public class AutoCompleteBehaviour : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(bindable);
            // Perform setup
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(bindable);
            // Perform clean up
        }

        // Behavior implementation
    }
}
