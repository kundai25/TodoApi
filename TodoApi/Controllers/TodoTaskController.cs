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
    public class TodoTaskController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ResponseDto _response;
        private readonly IMapper _mapper;
        public TodoTaskController(IUnitOfWork unitOfWork, ResponseDto response, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _response = response;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<TodoTask>>> GetAll()
        {
            var busisnessFromRepo = _unitOfWork.TodoTaskRepository.GetAll().ToList();
            await Task.CompletedTask;
            return Ok(busisnessFromRepo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TodoTaskDto dto)
        {

            var check = _unitOfWork.TodoTaskRepository.GetById(q => q.TaskName == dto.TaskName);
            if (check != null)
            {
                _response.Status = false;
                _response.Message = "Task already created";
            }
            else
            {
                var stream = _mapper.Map<TodoTask>(dto);
                _unitOfWork.TodoTaskRepository.Add(stream);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "Task created";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "This task could not be created";
                }


            }
            return Ok(_response);

        }

        [HttpPut]

        public async Task<IActionResult> Update([FromBody] TodoTaskDto dto)
        {
            var check = _unitOfWork.TodoTaskRepository.GetById(q => q.Id == dto.Id);
            if (check == null)
            {
                _response.Status = false;
                _response.Message = "Task not found";
            }
            else
            {
                var stream = _mapper.Map<TodoTask>(dto);
                _unitOfWork.TodoTaskRepository.Update(stream);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "The selected task has been updated";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "The selected task could not be updated";
                }


            }
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var check = _unitOfWork.TodoTaskRepository.GetById(q => q.Id == id);
            if (check == null)
            {
                _response.Status = false;
                _response.Message = "The selected task not be found";
            }
            else
            {
                _unitOfWork.TodoTaskRepository.Remove(check);
                var response = await _unitOfWork.Save();
                if (response > 0)
                {
                    _response.Status = true;
                    _response.Message = "the selected task has been Deleted";
                }
                else
                {
                    _response.Status = false;
                    _response.Message = "The selected task could not Deleted";
                }
            }
            return Ok(_response);
        }
    }
}
