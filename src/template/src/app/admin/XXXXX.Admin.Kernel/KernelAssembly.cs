using System.Reflection;

namespace XXXXX.Admin.Kernel
{
    public static class KernelAssembly
    {
        public static Assembly Get()
        {
            return Assembly.GetAssembly(typeof(KernelAssembly));
        }
    }
}