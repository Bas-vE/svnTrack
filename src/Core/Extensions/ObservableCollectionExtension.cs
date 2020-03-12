using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svnTrack.Core.Extensions
{
    public static class ObservableCollectionExtension
    {
        /// <summary>
        /// Creates a <see cref="System.Collections.ObjectModel.ObservableCollection{T}"/> from an <see cref="System.Collections.Generic.IEnumerable{T}"/>.
        /// </summary>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            ObservableCollection<T> collection = new ObservableCollection<T>();
            foreach (T item in source)
            {
                collection.Add(item);
            }
            return collection;
        }
    }
}
