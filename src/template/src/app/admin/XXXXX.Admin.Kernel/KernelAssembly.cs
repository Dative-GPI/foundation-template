using System.Reflection;

namespace XXXXX.Template.Admin.Kernel
{
    public static class KernelAssembly
    {
        public static Assembly Get()
        {
            return Assembly.GetAssembly(typeof(KernelAssembly));
        }
    }
}