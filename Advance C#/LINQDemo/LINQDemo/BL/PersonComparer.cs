using System.Collections.Generic;
using System;
using LINQDemo.Models;



// Custom comparer for the Product class
class PersonComparer : IEqualityComparer<Per01>
{
    // Per01s are equal if their names and Per01 numbers are equal.
    public bool Equals(Per01 x, Per01 y)
    {

        //Check whether the compared objects reference the same data.
        if (Object.ReferenceEquals(x, y)) return true;

        //Check whether any of the compared objects is null.
        if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
            return false;

        //Check whether the Per01s' properties are equal.
        return x.r01f01 == y.r01f01;
    }

    // If Equals() returns true for a pair of objects
    // then GetHashCode() must return the same value for these objects.

    public int GetHashCode(Per01 Per01)
    {
        //Check whether the object is null
        if (Object.ReferenceEquals(Per01, null)) return 0;

        //Get hash code for the Name field if it is not null.
        int hashPer01Name =  Per01.r01f01.GetHashCode();

        //Get hash code for the Code field.
        int hashProductCode = Per01.r01f01.GetHashCode();

        //Calculate the hash code for the product.
        return hashPer01Name ^ hashProductCode;
    }
}