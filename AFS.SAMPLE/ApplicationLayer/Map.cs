using AutoMapper;
using AFS.SAMPLE.DomainModelLayer.Users;
using AFS.SAMPLE.ViewModels;

namespace AFS.SAMPLE.ApplicationLayer;

public class Map : Profile
{
    public Map()
    {
        CreateMap<User, LoginModel>();
        CreateMap<LoginModel, User>();
    }
  
}
