using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities;
using School.WebApi.Dtos;
using School.Repository.Data;

namespace School.WebApi.Controllers
{

    [ApiController]
    [Route("api/{controller}")]
    public class TeachersController : ControllerBase
    {
        private readonly ISRepository _repo;
        private readonly SContext _context;
        //  private readonly IMapper _mapper; IMapper mapper

        public TeachersController(ISRepository repo, SContext context)
        {
            _repo = repo;
            _context = context;
            //  _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {

                Teacher[] Teachers = await _repo.GetAllTeachersAsync(true);


                // TeacherDto[] results = _mapper.Map<TeacherDto[]>(Teachers);


                if (Teachers != null)
                {
                    return Ok(Teachers);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception msg)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"A base de dados falhou, erro: {msg.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Teacher Teacher = await _repo.GetTeacherAsync(id, true);

                //  TeacherDto results = _mapper.Map<TeacherDto>(Teacher);

                return Ok(Teacher);

            }
            catch (System.Exception msg)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"A base de dados falhou, erro: {msg.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Teacher model)
        {


            //   Teacher teacher = _mapper.Map<Teacher>(model);

            //model.UnitTeachers = null;
            _context.Add(model);

            if (await _repo.SaveChangesAsync())
            {
                return Created($"api/teachers/{model.Id}", model);
            }
            return NotFound();

        }


        /////////////////////////////////

        [HttpPost("{PostUnitTeacher}")]
        public async Task<IActionResult> PostUnitTeacher(List<UnitTeacher> model)
        {
            try
            {
                if (model == null) return NotFound();
                //    Unit unit = model;
                //    unit.Address = model.Address;
                //    unit.Contact = model.Contact;
                _context.AddRange(model);
                //_repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"api/units/{model}", model);
                }
            }
            catch (System.Exception msg)
            {
                this.StatusCode(StatusCodes.Status500InternalServerError, $"A base de dados falhou. Erro: {msg.Message}");
            }
            return Ok(model);
        }



        [HttpGet("{GetUnitTeacher}/t")]
        public async Task<IActionResult> GetUnitTeacher(string t)
        {
            try
            {

                var unitTeachers = _context.UnitsTeachers;

                return Ok(unitTeachers);              


            }
            catch (System.Exception msg)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"A base de dados falhou, erro: {msg.Message}");
            }
        }
        /////////////////////////////////

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Teacher model)
        {
            try
            {
                Teacher teacher = await _repo.GetTeacherAsync(id, true);
                if (teacher == null) return NotFound();

                /*  if (model.Disciplines.Count > 0)
                  {
                      _repo.DeteleRange(teacher.Disciplines.ToArray());
                      await _repo.SaveChangesAsync();
                  }*/

                model.Contact.Id = teacher.Contact.Id;
                model.Address.Id = teacher.Address.Id;


                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"api/teachers/{model.Id}", model);
                }

            }
            catch (System.Exception ex)
            {
                this.StatusCode(StatusCodes.Status500InternalServerError, $"A base de dados falhou {ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Teacher Teacher = await _repo.GetTeacherAsync(id, true);


                if (Teacher == null) return null;


                _repo.Delete(Teacher);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok("Registro Removido com êxito.");
                }



            }
            catch (System.Exception ex)
            {
                return this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                $"Registro não removido, {ex.Message}");
            }
            return BadRequest();

        }

        [HttpPost("upload")]
        public async Task<IActionResult> upload()
        {
            //Get file
            IFormFile GetFile = Request.Form.Files[0];
            //path to resources
            //  string folderName = Path.Combine("resources", "images");
            //path to save resources
            //  string pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (GetFile.Length > 0)
            {
                string fileName = ContentDispositionHeaderValue.Parse(GetFile.ContentDisposition).FileName;
                string fullPath = Path.Combine(AppRootPath(), fileName.Replace("\"", " ").Trim());
                //Generate some  logic of extensions catch for check compare and return results.
                //for avoid attacks then using the extensions fakes.
                // string[] NameFileTorray = fullPath.Split('.');
                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    GetFile.CopyTo(stream);
                }
                return Ok();
            }
            return BadRequest();
        }


        [HttpGet("deletefile/{fileName}")]
        public bool deletefile(string fileName)
        {
            string FullPath = AppRootPath() + "\\" + fileName;

            if (System.IO.File.Exists(FullPath))
            {
                System.IO.File.Delete(FullPath);

                return true;

            }

            return false;
        }

        public string AppRootPath()
        {
            string pathPart01 = Path.Combine("resources", "images");
            string currentPath = Directory.GetCurrentDirectory();
            string completePath = Path.Combine(currentPath, pathPart01);
            return completePath;
        }





    }
}