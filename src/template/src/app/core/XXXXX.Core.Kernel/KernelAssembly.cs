using System.Reflection;

namespace XXXXX.Template.Core.Kernel
{
    public static class KernelAssembly
    {
        public static Assembly Get()
        {
            return Assembly.GetAssembly(typeof(KernelAssembly));
        }
    }
}