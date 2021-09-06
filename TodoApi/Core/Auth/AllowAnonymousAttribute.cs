using System;

namespace TodoApi.Core.Auth {
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute { }
}
