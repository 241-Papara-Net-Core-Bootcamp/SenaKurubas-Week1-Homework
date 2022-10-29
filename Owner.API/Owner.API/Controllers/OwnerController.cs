using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Owner.API.Data;



namespace Owner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOwners()
        {
            var ownerDatas = new OwnerData().GetOwnerList();
            return Ok(ownerDatas);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOwner(int id)
        {
            var ownerList = new OwnerData().GetOwnerList();
            if (ownerList.Any(owner => owner.Id == id))
            {
                return Ok(ownerList.Where(owner => owner.Id == id));
            }
            else
                return NotFound("User Not Found.");
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult CreateOwner([FromBody] Model.Owner owner)
        {
            if (owner == null)
                return BadRequest("Owner Is Empty");

            if (owner.Description == null)
                return BadRequest("Description is Empty.");

            if (owner.Description.ToLower().Contains("hack"))
                return BadRequest("Inappopriate Content.");
            
            var owners = new OwnerData();
            owners.AddToOwnerList(owner);
            return Ok(owner);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOwner(int id, [FromBody] Model.Owner newOwner)
        {

            var ownerData = new OwnerData();
            var ownerList = ownerData.GetOwnerList();

            if(ownerList.Any(owner=> owner.Id == id))
            {
                ownerList.Where(owner => owner.Id == id).First().UpdateInformation(newOwner);
                return Ok(newOwner);
            }
            else
            {
                return BadRequest("Could not find the owner to update.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var ownerData = new OwnerData();
            var ownerList = ownerData.GetOwnerList();

            if (ownerList.Any(owner => owner.Id == id))
            {
                var ownerToDelete = ownerList.Where(owner => owner.Id == id).First();
                ownerData.RemoveFromOwnerList(ownerToDelete);
                return Ok(ownerList);
            }
            else
                return BadRequest("Could not find the owner to delete.");
        }

    }
}