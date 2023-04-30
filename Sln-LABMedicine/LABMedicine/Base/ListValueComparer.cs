﻿using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LABMedicine.Base
{
    public class ListValueComparer : ValueComparer<List<string>>
    {
        public ListValueComparer() : base(
            (c1, c2) => c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList())
        { }
    }
}
