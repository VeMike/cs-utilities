﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Memory.Unmanaged
{
    interface IUnmanagedMemory : IDisposable
    {
        /// <summary>
        ///     Sets the data, which will be copied into unmanaged
        ///     memory
        /// </summary>
        byte[] Data { set; }

        /// <summary>
        ///     A pointer/handle representing the unmanaged memory,
        ///     that stores the bytes passed to <see cref="Data"/>
        /// </summary>
        IntPtr Memory { get; }

        /// <summary>
        ///     The number of bytes, that are currently stored in unmanaged
        ///     memory.
        /// </summary>
        int MemorySize { get; }
    }
}
