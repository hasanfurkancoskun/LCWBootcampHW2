//using MailKit.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using API1.clothesoperations;
using static API1.clothesoperations.Createclothe;
using static API1.clothesoperations.Updateclothe;
using static API1.clothesoperations.DeleteClotheCommand;
using AutoMapper;
using static API1.clothesoperations.GetClothesDetail;

namespace API1.Controllers
{
    //new webapi is created
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesController : ControllerBase
    {
        //adding default clothes
        private static List<clothes> products = new List<clothes>
        {
            new clothes {
                Id = 1,
                Name ="blue jean",
                Category ="Jean",
                Material ="Cotton",
                CutType = "Skinny"
            },
            new clothes {
                Id = 2,
                Name ="purple tshirt",
                Category ="tshirt",
                Material ="Cotton",
                CutType = "Large"
            }
        };
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ClothesController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //getting all the clothes which is avaible 
        [HttpGet]
        //public async Task<ActionResult<List<clothes>>> Get()
        public IActionResult GetClothes()
        {
            Getclothes query = new Getclothes(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
            //var clothlist=products.OrderBy(x=> x.Id).ToList<clothes>();
            //return Ok(await _context.clothess.ToListAsync());
            //return clothlist;
            // return Ok(products);
        }
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<clothes>>> Search([FromQuery] clothes searchQuery)
        {
            IQueryable<clothes> query = _context.clothess;

            if (!string.IsNullOrEmpty(searchQuery.Name))
            {
                query = query.Where(cl => cl.Name == searchQuery.Name);
            }

            if (!string.IsNullOrEmpty(searchQuery.Category))
            {
                query = query.Where(cl => cl.Category == searchQuery.Category);
            }

            if (query.Count() == 0)
            {
                return NotFound("clothe not found");
            }
            return await query.ToListAsync();
        }
        //getting only one clothe from the list by its id number
        [HttpGet("{id}")]
        public IActionResult GeyById(int id)
        {
            ClotheDetailViewModel result;
            try
            {
                GetClothesDetail query = new GetClothesDetail(_context, _mapper);
                query.ClotheId = id;
                result = query.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }

        //Posting a new clothe to the list
        [HttpPost]
        //public async Task<ActionResult<List<clothes>>> AddClothes(clothes clothe)
        public IActionResult Addclothe([FromBody] CreateclotheModel newclothe)
        {
            Createclothe command= new Createclothe(_context,_mapper);
            try
            {
                command.Model = newclothe;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok();
            /*_context.clothess.Add(clothe);
            await _context.SaveChangesAsync();
            return Ok(await _context.clothess.ToListAsync());*/
        }

        //updating a clothe in the list with put method
        [HttpPut("{id}")]
        public IActionResult UpdateClothe(int id,[FromBody] UpdateClotheModel updatedclothe)
        //public async Task<ActionResult<List<clothes>>> UpdateClothes(clothes request)
        {
            try
            {
                Updateclothe command = new Updateclothe(_context);
                command.clotheId = id;
                command.Model = updatedclothe;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            /* var dbclothe = await _context.clothess.FindAsync(request.Id);
             if (dbclothe == null)
             {
                 return BadRequest("Clothes is not found.");
             }
             dbclothe.Name=request.Name;
             dbclothe.Category=request.Category;
             dbclothe.Material=request.Material;
             dbclothe.CutType=request.CutType;
             await _context.SaveChangesAsync();
             return Ok(await _context.clothess.ToListAsync());*/
            return Ok();
        }

        //deleting a clothe from the list by the Delete method
        [HttpDelete("{id}")]
        //public async Task<ActionResult<List<clothes>>> Delete(int id)
        public IActionResult DeleteClothe (int id)
        {
            /*var dbclothe = await _context.clothess.FindAsync(id);
            if (dbclothe == null)
            {
                return BadRequest("Clothes is not found.");
            }
            _context.clothess.Remove(dbclothe);
            await _context.SaveChangesAsync();
            return Ok(await _context.clothess.ToListAsync());*/
            try
            {
                DeleteClotheCommand command = new DeleteClotheCommand(_context);
                command.ClotheId = id;
                command.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }



    }
}
