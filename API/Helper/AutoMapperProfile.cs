using API.DTO;
using API.DTO.Category;
using API.DTO.Product;
using API.DTO.ProductVariation;
using AutoMapper;
using Core.Model;
using System.Reflection;

namespace API.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            var baseDtoType = typeof(BaseDTO);
            var types = Assembly.GetExecutingAssembly().GetTypes()
                        .Where(t => t.IsClass && t != baseDtoType
                            && baseDtoType.IsAssignableFrom(t));

            var coreModelAssembly = Assembly.GetExecutingAssembly().GetReferencedAssemblies()
                .Where(x => x.Name == "Core").FirstOrDefault();
            
            var coreModels = Assembly.Load(coreModelAssembly).GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace) &&
                                type.BaseType != null &&
                                type.BaseType == typeof(BaseEntity));

            foreach (Type type in types)
            {
                var coreModelName = this.RemoveDTOSuffix(type.Name);
                var coreModelType = coreModels.Where(x => x.Name == coreModelName).FirstOrDefault();
                CreateMap(coreModelType, type).ReverseMap();
            }
        }

        private string RemoveDTOSuffix(string modelName, string suffix = "DTO")
        {
            if (modelName.EndsWith("CreateDTO"))
            {
                return modelName.Substring(0, modelName.Length - "CreateDTO".Length);
            }
            else if (modelName.EndsWith("EditDTO"))
            {
                return modelName.Substring(0, modelName.Length - "EditDTO".Length);
            }
            else if (modelName.EndsWith("ViewDTO"))
            {
                return modelName.Substring(0, modelName.Length - "ViewDTO".Length);
            }
            else
            {
                return modelName.Substring(0, modelName.Length - suffix.Length);
            }
        }
    }
}
