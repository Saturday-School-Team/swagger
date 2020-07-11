using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swagger.Utility
{
    // This make replacement of v{version:apiVersion} to real version of corresponding swagger doc.
    public class ReplaceVersionWithExactValueInPath : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            if (swaggerDoc == null)
                throw new ArgumentNullException(nameof(swaggerDoc));

            var replacements = new OpenApiPaths();
            foreach (var (key, value) in swaggerDoc.Paths)
            {
                replacements.Add(key.Replace("v{version}", swaggerDoc.Info.Version, StringComparison.InvariantCulture), value);
            }
            swaggerDoc.Paths = replacements;
        }
    }
}


//public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
//{
//    swaggerDoc.Paths = (OpenApiPaths)swaggerDoc.Paths
//        .ToDictionary(
//            path => path.Key.Replace("v{version}", swaggerDoc.Info.Version),
//            path => path.Value
//        );

//    //swaggerDoc.Paths = (OpenApiPaths)lol;
//}
