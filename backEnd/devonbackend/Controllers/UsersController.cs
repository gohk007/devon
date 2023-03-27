using devonbackend.Models;
using devonbackend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace devonbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IUserRepository _userRepository;
        private Response _response;

        public UsersController(IUserRepository userRepository,Response response)
        {
            _userRepository = userRepository;
            _response = new Response();
        }


        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            try
            {
                IEnumerable<User> users = await _userRepository.GetUsers();
                return users;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }


            return null;
            
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get (int id)
        {
            try
            {
                User user = await _userRepository.GetUserById(id);
                _response.Result = user;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }


        [HttpPost]
        public async Task<object> Post([FromBody] User user)
        {
            try
            {
                User model = await _userRepository.CreateUpdateUser(user);
                _response.Result = model;
            }
            catch (Exception ex)
            {

               _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

               
            }

            return _response;
        }


        [HttpPut]
        public async Task<object> Put([FromBody] User user)
        {
            try
            {
                User model = await _userRepository.CreateUpdateUser(user);
                _response.Result = model;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _userRepository.DeleetProduct(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }


    }
}
