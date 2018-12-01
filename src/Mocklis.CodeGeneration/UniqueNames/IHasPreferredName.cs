// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHasPreferredName.cs">
//   Copyright © 2018 Esbjörn Redmo and contributors. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Mocklis.CodeGeneration.UniqueNames
{
    public interface IHasPreferredName
    {
        string PreferredName { get; }
    }
}