using static WebApiPerson.Models.EntitiesModels;
using System.ComponentModel.DataAnnotations;

namespace WebApiPerson.Dtos
{
    public class EcommerceDtos
    {
        public class BaseResponse<TResult>
        {
            public bool Success { get; set; }
            public string? ErrorMessage { get; set; }
            public TResult Result { get; set; }
        }

        public class BaseCollectionResponse<TDtoClass> where TDtoClass : class
        {
            public bool Success { get; set; }
            public string? ErrorMessage { get; set; }
            public int TotalPages { get; set; }
            public ICollection<TDtoClass>? Collection { get; set; }
        }



        public class CategoryDtoCollectionResponse : BaseCollectionResponse<CategoryDto>
        {

        }

        public class CustomersDtoCollectionResponse : BaseCollectionResponse<CustomerDto>
        {

        }

        public class CategoryDto
        {
            public string? Id { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
        }

        public class CustomerDto
        {
            public string? Id { get; set; }

            public string? Name { get; set; }

            public string? LastName { get; set; }

            public string? Email { get; set; }

            public DateTime BirthDate { get; set; }

            public string? Dni { get; set; }

        }
    }
}
