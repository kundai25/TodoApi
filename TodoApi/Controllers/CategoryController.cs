using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Dto;
using TodoApi.Model;
using TodoApi.Repository;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ResponseDto _response;
        private readonly IMapper _mapper;
        public CategoryController(IUnitOfWork unitOfWork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _response = response;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAll()
        {
            var busisnessFromRepo = _unitOfWork.CategoryRepository.GetAll().ToList();
            await Task.CompletedTask;
            return Ok(busisnessFromRepo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDto dto)
        {

            var check = _unitOfWork.CategoryRepository.GetById(q => q.TaskCategory == dto.TaskCategory);
            if (check != null)
            {
                _response.Status = false;
                _response.Message = "Category already taken";
            }
            else
            {
                var stream = _mapper.Map<Category>(dto);
                _unitOfWork.CategoryRepository.Add(stream);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Category created";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "Category could not be created";
                }


            }
            return Ok(_response);

        }

        [HttpPut]

        public async Task<IActionResult> Update([FromBody] CategoryDto dto)
        {
            var check = _unitOfWork.CategoryRepository.GetById(q => q.Id == dto.Id);
            if (check == null)
            {
                _response.Status = false;
                _response.Message = "Category not found";
            }
            else
            {
                var stream = _mapper.Map<Category>(dto);
                _unitOfWork.CategoryRepository.Update(stream);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "The selected category has been updated";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "The selected category could not be updated";
                }


            }
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var check = _unitOfWork.CategoryRepository.GetById(q => q.Id == id);
            if (check == null)
            {
                _response.Status = false;
                _response.Message = "The selected category not be found";
            }
            else
            {
                _unitOfWork.CategoryRepository.Remove(check);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "the selected category has been Deleted";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "The selected category could not Deleted";
                }


            }
            return Ok(_response);
        }
    }
}
