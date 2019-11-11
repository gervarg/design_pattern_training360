using System.Collections.ObjectModel;
using System.Linq;

namespace Mediator
{
    class MvvmMediator
    {
        private readonly DropDownList dropDownList;
        private readonly ObservableCollection<string> observableCollection;

        public MvvmMediator(DropDownList dropDownList, ObservableCollection<string> observableCollection)
        {
            this.dropDownList = dropDownList;
            this.observableCollection = observableCollection;

            this.observableCollection.CollectionChanged += ObservableCollection_CollectionChanged;
        }

        private void ObservableCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // https://stackoverflow.com/questions/30743741/c-sharp-displaying-string-of-observablecollection-on-event-collectionchanged

            if (e.OldItems != null)
            {
                dropDownList.Items.RemoveAll(i => e.OldItems.Contains(i));
            }
            if (e.NewItems != null)
            {
                dropDownList.Items.AddRange(e.NewItems.OfType<string>());
            }
        }
    }
}
