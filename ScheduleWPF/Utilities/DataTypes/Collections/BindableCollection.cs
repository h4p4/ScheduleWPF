using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWPF.Utilities.DataTypes.Collections
{
    public class BindableCollection<T> : ObservableCollection<T>, ITypedList
    {
        public BindableCollection(IEnumerable<T> collection) : base(collection)
        {
        }
        public BindableCollection(List<T> list) : base(list)
        {
        }
        string ITypedList.GetListName(PropertyDescriptor[] listAccessors) { return null; }
        PropertyDescriptorCollection ITypedList.GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            return TypeDescriptor.GetProperties(typeof(T), PropertyFilter);
        }
        static readonly Attribute[] PropertyFilter = { BrowsableAttribute.Yes };


    }
}
