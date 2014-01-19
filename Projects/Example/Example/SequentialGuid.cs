using System;
using System.Runtime.InteropServices;

namespace Example
{
    public static class SequentialGuid
    {
        [DllImport("rpcrt4.dll", SetLastError = true)]
        static extern int UuidCreateSequential(out Guid guid);

        public static Guid NewGuid()
        {
            const int rpcOk = 0;
            Guid guid;
            return UuidCreateSequential(out guid) == rpcOk ? guid : Guid.NewGuid();
        }
    }
}