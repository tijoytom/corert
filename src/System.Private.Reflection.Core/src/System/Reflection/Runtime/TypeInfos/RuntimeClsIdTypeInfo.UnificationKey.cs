// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Reflection.Runtime.TypeInfos
{
    internal sealed partial class RuntimeCLSIDTypeInfo
    {
        //
        // Key for unification.
        //
        private struct UnificationKey : IEquatable<UnificationKey>
        {
            public UnificationKey(Guid clsid, string server)
            {
                ClsId = clsid;
                Server = server;
            }

            public Guid ClsId { get; }
            public string Server { get; }

            public override bool Equals(object obj)
            {
                if (!(obj is UnificationKey))
                    return false;
                return Equals((UnificationKey)obj);
            }

            public bool Equals(UnificationKey other)
            {
                if (!ClsId.Equals(other.ClsId))
                    return false;
                if (Server != other.Server)
                    return false;

                return true;
            }

            public override int GetHashCode()
            {
                return ClsId.GetHashCode() ^ (Server == null ? 0 : Server.GetHashCode());
            }
        }
    }
}

