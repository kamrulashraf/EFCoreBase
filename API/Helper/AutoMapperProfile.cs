using API.DTO;
using AutoMapper;
using Core.Model;
using System.Reflection;

namespace API.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
               .Where(type => !string.IsNullOrEmpty(type.Namespace) &&
                               type.BaseType != null &&
                               type.BaseType == typeof(BaseDTO));

            var coreModelAssembly = Assembly.GetExecutingAssembly().GetReferencedAssemblies()
                .Where(x => x.Name == "Core").FirstOrDefault();
            var coreModels = Assembly.Load(coreModelAssembly).GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace) &&
                                type.BaseType != null &&
                                type.BaseType == typeof(BaseEntity));
            
            foreach (Type type in types)
            {
                var coreModelName = this.RemoveDTOSuffix(type.Name, "DTO");
                var coreModelType = coreModels.Where(x => x.Name == coreModelName).FirstOrDefault();
                var temp = typeof(Users);
                CreateMap(coreModelType, type).ReverseMap();
            }
        }

        private string RemoveDTOSuffix(string modelName, string suffix)
        {
            return modelName.Substring(0, modelName.Length - suffix.Length);
        }
    }
}
