using System;
using System.Linq;
using System.Text;
using TodoApi.Models;
using Newtonsoft.Json;
using TodoApi.Core.Helpers;
using TodoApi.Models.Request;
using System.Security.Claims;
using System.Threading.Tasks;
using TodoApi.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using TodoApi.Core.Utils.Interface;
using Microsoft.IdentityModel.Tokens;
using TodoApi.Core.Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using TodoApi.Core.Repositories.Interface;

namespace TodoApi.Core.Service {
    public class UserService: IUserService {
        private readonly IUserRepository _userRepository;
        private readonly IJwtUtils _jwtUtils;
        public UserService(
            IUserRepository userRepository, IJwtUtils jwtUtils) {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
        }

        public User GetById(Guid id) {
            return _userRepository.GetById(id).FirstOrDefault();
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest user) {
            var userInfo = _userRepository.AuthenticateUser(user);
            if (userInfo == null) return null;
            var token = _jwtUtils.GenerateJwtToken(userInfo);
            return new AuthenticateResponse(userInfo, token);
        }
    }
}
