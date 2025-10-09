namespace jupter_server.Helpers;

using AutoMapper;
using jupter_server.Models;
using jupter_server.Models.UserModel;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // CreateRequest -> User
        CreateMap<CreateRequest, User>();

        // UpdateRequest -> User
        //CreateMap<UpdateRequest, User>()
        //    .ForAllMembers(x => x.Condition(
        //        (src, dest, prop) =>
        //        {
        //            // ignore both null & empty string properties
        //            if (prop == null) return false;
        //            if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

        //            // ignore null role
        //            //if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

        //            return true;
        //        }
        //    ));
        CreateMap<UpdateRequest, User>();
    }

}