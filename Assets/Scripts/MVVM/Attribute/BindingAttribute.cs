using System;

namespace MVVM
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method)]
    public class BindingAttribute : Attribute
    {
    }
}