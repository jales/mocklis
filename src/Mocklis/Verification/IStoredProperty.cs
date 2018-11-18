// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStoredProperty.cs">
//   Copyright © 2018 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.Verification
{
    public interface IStoredProperty<TValue>
    {
        TValue Value { get; set; }
    }
}