using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerWebApiProject.API.DTOs;
using NLayerWebApiProject.Core.Models;
using NLayerWebApiProject.Core.Services;

namespace NLayerWebApiProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonsController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons =  await _personService.GetAllAsync();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Save(PersonDTO personDto)
        {
            var person = await _personService.AddAsync(_mapper.Map<Person>(personDto));
            return Created("", person);
        }
    }
}