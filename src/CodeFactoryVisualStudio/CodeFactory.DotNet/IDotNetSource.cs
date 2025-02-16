﻿//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;


namespace CodeFactory.DotNet
{
    /// <summary>
    /// The source point in which dot net models are loaded.
    /// </summary>
    public interface IDotNetSource : IDotNetModel, IParent, ILookup 
    {

        /// <summary>
        /// The namespaces that are used as references to access other libraries not hosted in the source document.
        /// </summary>
        IReadOnlyList<IDotNetNamespaceReference> NamespaceReferences { get; }

        /// <summary>
        /// The interfaces that were defined in the source.
        /// </summary>
        IReadOnlyList<IDotNetInterface> Interfaces { get; } 

        /// <summary>
        /// The classes that were defined in the source.
        /// </summary>
        IReadOnlyList<IDotNetClass> Classes { get; }

        /// <summary>
        /// The structures that were defined in the source.
        /// </summary>
        IReadOnlyList<IDotNetStructure> Structures { get; }

        /// <summary>
        /// The delegates that were defined in the source.
        /// </summary>
        IReadOnlyList<IDotNetDelegate> Delegates { get; }

        /// <summary>
        /// The enumerations that were defined in the source.
        /// </summary>
        IReadOnlyList<IDotNetEnum> Enums { get; }

        /// <summary>
        /// The namespaces that were defined in the source.
        /// </summary>
        IReadOnlyList<IDotNetNamespace> Namespaces { get; }
    }
}
