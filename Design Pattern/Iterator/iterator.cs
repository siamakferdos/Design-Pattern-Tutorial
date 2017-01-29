using System;
using System.Collections;

namespace Design_Pattern.Iterator
{
    public class Iterator
    {
        public class MonthCollection : IEnumerable
        {
            readonly string[] _months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            public IEnumerator GetEnumerator()
            {
                foreach (var month in _months)
                {
                    yield return month;
                }
            }
        }

    }
}
