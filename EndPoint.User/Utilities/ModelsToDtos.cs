using Application.Dto;
using Domain;

namespace EndPoint.User.Utilities
{
    public static class ModelsToDtos
    {
        public static DashBoardDto UserUserInfoModelToDashboadDto(Domain.User user, UserInfo userInfo)
        {
            DashBoardDto dto = new DashBoardDto()
            {
                foodplans = user.foodPlans,
                orders=user.orders,                
            };
            return dto;

        }


    }
}
