using System.Reflection;

namespace XXXXX.Core.Kernel
{
    public static class KernelAssembly
    {
        public static Assembly Get()
        {
            return Assembly.GetAssembly(typeof(KernelAssembly));
        }
    }
}