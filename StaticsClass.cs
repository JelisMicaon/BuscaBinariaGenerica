using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnitaryTests
{
    public static class StaticsClass
    {
        #region Algorithm Binary
        public static List<T> ListOrderByProperty<T>(this List<T> list, string property)
            => typeof(T).GetProperty(property) is null ? null : list.OrderBy(x => typeof(T).GetProperty(property)?.GetValue(x, null)).ToList();

        public static T BinarySearch<T>(this List<T> list, string propertySearch, long valueSearch, bool orderList = false) where T : class
        {
            List<PropertyInfo> propriedades = typeof(T).GetProperties().ToList();
            if (propriedades.Any(x => x.Name == propertySearch) && list.Count > 0)
            {
                if (orderList)
                    list = list.ListOrderByProperty<T>(propertySearch);

                int middle;
                int start = 0;
                int end = list.Count - 1;
                long valueProperty;

                do
                {
                    middle = (start + end) / 2;
                    valueProperty = Convert.ToInt64(list.ElementAt(middle).GetType().GetProperty(propertySearch).GetValue(list.ElementAt(middle)));
                    if (valueProperty == valueSearch)
                        return list.ElementAt(middle);
                    else if (valueSearch > valueProperty)
                        start = middle + 1;
                    else
                        end = middle - 1;
                } while (start <= end);

                return null;
            }

            return null;
        }
        #endregion Algorithm Binary

        #region Methods Pop for UnityTest
        public static List<InfoList> ReturnListEmpty()
            => new List<InfoList>();

        public static List<InfoList> ReturnListInfo()
            => new List<InfoList>() {
                new InfoList(123, 321),
                new InfoList(321, 1234),
                new InfoList(2, 3212351),
                new InfoList(145, 321241),
                new InfoList(1238748123, 3123421),
                new InfoList(1233213, 34321),
                new InfoList(2, 32321),
                new InfoList(3, 313421),
                new InfoList(0, 23321),
                new InfoList(123, 31321)
            };
        #endregion Methods Pop for UnityTest
    }

    public class InfoList
    {
        public InfoList(int id, int old)
            => (Id, Old) = (id, old);

        public int Id { get; set; }
        public int Old { get; set; }
    }
}