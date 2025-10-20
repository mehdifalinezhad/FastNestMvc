using Application.Dto;
using CommonJust;
using Domain;
using persistant;

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
        public static UserInfo UserAnswerToUserInfoModel(UserAnswerDto dto)
        {

            UserInfo userInfo = new UserInfo()
            {
                ArmRound = dto.ArmRound,
                ActionSkiny = dto.ActionSkiny,
                DailyActivity = dto.DailyActivity,
                LastMeal = dto.LastMeal,
                LaunchMeal = dto.LaunchMeal,
                marrige = dto.married,
                gender = dto.gender,
                height = dto.height,
                Job = dto.Job,
                Historysickness = dto.Historysickness,
                AbdominalRound = dto.AbdominalRound,
                AssRound = dto.AssRound,
                wakeTime = dto.wakeTime,
                weight = dto.weight,
                age = dto.age,
                BreakfastMeal = dto.BreakfastMeal,
                //this how know to insert
                //sicKness=dto.Historysickness,
                DurationUsed = dto.DurationUsed,
                registerDate = dto.registerDate,
                dislikeFood = dto.dislikeFood,
                EaveningMeal = dto.EaveningMeal,
                favoriteFood = dto.favoriteFood,
                LegRound = dto.LegRound,
                LaunchTime = dto.LaunchTime,
                BirthDay = dto.BirthDay,
                Deal = dto.Deal,
                //StateId = dto.StateId,
                dinnerMeal = dto.dinnerMeal,
                medicineUse = dto.medicineUse,
                morningBetweenMeal = dto.morningBetweenMeal,
                SleepTime = dto.SleepTime,
                ThighRound = dto.ThighRound,
                ImageUrls = HimImageUrls(dto.ImageFiles, dto.LoginedUser.LastName),
                UserId = dto.LoginedUser.Id,
                dinnerTime = dto.dinnerTime,
                CityId = dto.CityId,


            };
            return userInfo;
        }
        private static string HimImageUrls(List<IFormFile> files, string LastName)
        {
            var urls = new List<string>();
            foreach (var item in files)
            {
                urls.Add(UploadImages.SaveImage(item, LastName));
            }
            string strings = string.Join(",", urls);
            //List<string> ass= strings.Split(",").ToList();
            return strings;

        }
    }
}
