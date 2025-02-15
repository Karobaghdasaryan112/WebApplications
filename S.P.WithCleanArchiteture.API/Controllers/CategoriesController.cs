using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using S.P.WithCleanArchitecture.Application.Interfaces;
using S.P.WithCleanArchitecture.Application.Services.LoggerService;
using S.P.WithCleanArchitecture.Application.Validations.Interfaces;
using S.P.WithCleanArchitecture.Application.Validations.ValidationExceptions;
using S.P.WithCleanArchiteture.API.DTOs.Category;

namespace S.P.WithCleanArchiteture.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;
        private ILoggerService _loggerService;
        private IPrintService _printService;
        private IMapper _mapper;

        public CategoriesController(
            ICategoryService categoryService,
            ILoggerService loggerService,
            IPrintService printService,
            IValidatorBase validatorBase,
            IMapper mapper
            )
        {
            _printService = printService;
            _categoryService = categoryService;
            _loggerService = loggerService;
            _mapper = mapper;
        }

        [HttpGet("Category/{Name}")]
        public async Task<IActionResult> GetCategoryByName([FromRoute] string Name)
        {
            if (string.IsNullOrEmpty(Name))
                throw new InvalidDataFormatException($"CategoryName cannot be Empty");

            var CategoryDTO = await _categoryService.GetCategoryByName(Name);

            await _loggerService.LogIntoFile(
                new LogObject()
                {
                    CreatedDate = DateTime.Now,
                    Message = $"Sucsess: GetCategory by Name:{Name}",
                    ResponseBody = StatusCodes.Status200OK
                });

            return Ok(CategoryDTO);
        }


        [HttpDelete("Category/{Id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int Id)
        {
            if (Id < 0)
                throw new InvalidDataFormatException("Id of Category cannot be less than 1");

            await _categoryService.DeleteCategoryById(Id);

            await _loggerService.LogIntoFile(
            new LogObject()
            {
                CreatedDate = DateTime.Now,
                Message = $"Sucsess: Category by Id:{Id} deleted",
                ResponseBody = StatusCodes.Status200OK
            });

            return Ok($"Sucsess for Deleted CategoryBy Id {Id}");
        }

        [HttpPut]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryViewModel category)
        {
            throw new NotImplementedException();
        }
    }
}
