using Jifter.Repositories;
using Jifter.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jifter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }
        // GET: api/<UserProfileController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userProfileRepository.GetAll());
        }

        // GET api/<UserProfileController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var userProfiles = _userProfileRepository.GetById(id);
            if (userProfiles == null)
            {
                return NotFound();
            }
            return Ok(userProfiles);
        }

        // POST api/<UserProfileController>
        [HttpPost]
        public IActionResult Post(UserProfile userProfile)
        {
            userProfile.DateCreated = DateTime.Now;
            _userProfileRepository.Add(userProfile);
            return NoContent();
        }

        // PUT api/<UserProfileController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, UserProfile userProfile)
        {
            if (id != userProfile.Id)
            {
                return BadRequest();
            }
            _userProfileRepository.Update(userProfile);
            return NoContent();
        }

        // DELETE api/<UserProfileController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userProfileRepository.Delete(id);
            return NoContent();
        }
    }
}
