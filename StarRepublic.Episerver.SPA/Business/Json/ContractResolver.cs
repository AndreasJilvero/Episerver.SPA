using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace StarRepublic.Episerver.SPA.Business.Json
{
    public class ContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            if (typeof(IContent).IsAssignableFrom(type))
            {
                var properties = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.DeclaredOnly);
                var jsonProperties = properties.Select(x => CreateProperty(x, memberSerialization)).ToList();
                jsonProperties.ForEach(p => { p.Writable = true; p.Readable = true; });
                return jsonProperties;
            }

            return base.CreateProperties(type, memberSerialization);
        }
    }
}