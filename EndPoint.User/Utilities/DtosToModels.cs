using Application.Dto;

namespace EndPoint.User.Utilities
{
    public static class DtosToModels
    {
        public static Domain.User AddUserDtoToModel(UserDto userDto)
        {
            var user = new Domain.User()
            { 
            PhoneNumber = userDto.PhoneNumber,
            Email = userDto.Email,
            Password=userDto.Password,
            UserName = userDto.UserName,
            FirstName=userDto.FirstName,
            LastName=userDto.LastName,
            };

            return user;
        
        }
    }
}
