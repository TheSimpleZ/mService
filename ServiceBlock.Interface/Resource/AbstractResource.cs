using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ServiceBlock.Extensions;

namespace ServiceBlock.Interface.Resource
{
    // This class describes resources in the service
    // To create a resource, you must extend this class
    public abstract class AbstractResource
    {
        // This parameter is used to identify the resource in the API
        // If overridden, you must ensure uniqueness
        [ReadOnly(true)]
        public virtual Guid Id { get; set; } = Guid.NewGuid();

        // Retrives a list of all properties with the QueryableAttribute
        public static IEnumerable<PropertyInfo> GetQueryableProperties(Type type) => type.GetProperties().Where(p => p.HasAttribute<QueryableAttribute>());

        // This method gets the name of the service that the resource belongs to
        public static string GetServiceName(Type type) => type.Assembly.GetName().Name.Split('.').FirstOrDefault();

        // This method will be fired after the resource has been retrieved from storage, but before it's returned to the client.
        public virtual Task OnRead() => Task.CompletedTask;

        // This method will be fired after the resource has been received from the API, but before it's written to the storage.
        public virtual Task OnCreate() => Task.CompletedTask;

        // This method will be fired after the resource has been received from the API, but before it's written to the storage.
        public virtual Task OnUpdate() => Task.CompletedTask;

    }
}