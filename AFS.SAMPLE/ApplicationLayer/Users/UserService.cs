using AutoMapper;
using AFS.SAMPLE.Helper.Repository;
using AFS.SAMPLE.DomainModelLayer.Users;
using AFS.SAMPLE.ViewModels;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace AFS.SAMPLE.ApplicationLayer.Users
{
    public class UserService: IUserService
    {
        readonly IRepository<User> userRepository;
        readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository,
         IUnitOfWork unitOfWork,
         IMapper mapper)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Response SignIn(LoginModel model)
        {
            User user = this.userRepository.Get(s=>s.UserName==model.UserName && s.Password==model.Password);
            if (user == null || user.Id == 0)
                return new ErrorResponse("Username or password is incorrect.");

            var token = GenerateJSONWebToken(user);
            var result = new
            {
                user.Email,
                user.PhoneNumber,
                token.Result,
                user.TokenExpiredMinute
            };
            
            return new SuccessfulResponse(result);
        }


        private async Task<string> GenerateJSONWebToken(User user)
        {           
            var claims = new List<Claim>();
            claims.Add(new Claim(nameof(User.Id), user.Id.ToString()));
            claims.Add(new Claim(nameof(User.Email),user.Email));
            claims.Add(new Claim(nameof(User.Role),user.Role.ToString()));
            claims.Add(new Claim(nameof(User.PhoneNumber),user.PhoneNumber));                       
           
            var newGuid = "30536584-44c0-42b1-94dd-3d8cae4d760b";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(newGuid));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("AFS",
              "AFS",
              claims,
              expires: DateTime.Now.AddMinutes(user.TokenExpiredMinute),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
