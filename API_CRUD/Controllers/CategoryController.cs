using API_CRUD.Infrastructure.Repositories.Interfaces;
using API_CRUD.Models.Abstract;
using API_CRUD.Models.DTOs;
using API_CRUD.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    [Produces("application/json")]// bütün contrl.daki actionların content type' na ayar verdik.
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this._repo = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categoryList = await _repo.GetCategories(
                selector: x => new GetCategoryVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Slug = x.Slug
                },
                where: x => x.Status != Status.Passive,
                orderBy: x => x.OrderBy(x => x.Name));

            return Ok(categoryList);
        }

        [HttpGet("{id:int}", Name = "GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _repo.GetCategory(id);
            return Ok(category);
        }

        [HttpGet("{slug}", Name = "GetCategoryBySlug")]
        public async Task<IActionResult> GetCategoryBySlug(string slug)
        {
            var category = await _repo.GetCategory(slug);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO model)
        {
            if ((ModelState.IsValid))
            {
                if (model == null)
                {
                    return BadRequest(model); // Status code 400
                }

                var categoryExsist = await _repo.CategoryExists(model.Slug);

                if (categoryExsist == true)
                {
                    ModelState.AddModelError(string.Empty, "Kategori mevcut.");
                    return StatusCode(404, ModelState);
                }

                if (!await _repo.Create(model))
                {
                    ModelState.AddModelError(string.Empty, $"{model.Name} kaydı kaydedilirken bir şeyler ters gitti");
                    return StatusCode(500, ModelState);
                }
                return StatusCode(201); // Status code 201 created
            }
            return BadRequest();
        }

        [HttpPatch(Name = "UpdateCategory")]
        public async Task<IActionResult> UpdateCatogory([FromBody] UpdateCategoryDTO model)
        {
            if (model == null)
            {
                return BadRequest(model);
            }
            if (!await _repo.Update(model))
            {
                ModelState.AddModelError(string.Empty, $"{model.Name} kaydı düzenlenirken bir sorun oluştu");
                return StatusCode(500, model);
            }
            return Ok();
        }

        [HttpDelete("{id}", Name = "DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (!await _repo.Delete(id))
            {
                ModelState.AddModelError(string.Empty, $"Birşeyler ters gitti, kategori bulunamadı.");
                return StatusCode(404, ModelState);
            }
            return Ok();
        }
    }
}
