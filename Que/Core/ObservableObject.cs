using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

/*
INotifyPropertyChanged allows WPF UI elements (via the standard data binding mechanisms)
to subscribe to the PropertyChanged event and automatically update themselves.
For example, if you had a TextBlock displaying your FirstName property, 
by using INotifyPropertyChanged, you can display it on a form, 
and it will automatically stay up to date when the FirstName property is changed in code.
The View just subscribes to the event - which tells it everything necessary. 
The event includes the name of the changed property, so if a UI element is bound to that property, it updates.
*/

namespace Que.Core
{
    class ObservableObject : INotifyPropertyChanged // update
    {
        public event PropertyChangedEventHandler? PropertyChanged;

       protected void onPropertyChanged([CallerMemberName] string name = null)
       {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
       }

    }
}
