using RealEstate.BLL.DTO;
using RealEstate.BLL.DTO.UserDtos;
using System;

namespace XUnitTestProject.DefaultValues
{
    public class AuthUser
    {
         public string Id { get; set; }
         public string Role { get; set; }
         public string Email { get; set; }
    }
    public static class UserDefaultValues
    {
        public static string DefaultString = "SomeString";
        public static DateTime DefaultBirthDate = new DateTime(2017, 7, 15);
        public static string DefaultId = "3f857412-cf5e-4087-bc85-6426fa791d91";
        public static string DefaultRoleId = "3f857412-cf5e-4087-bc85-6426fa791d91";
        public static string DefaultConfirmNum = "1238328";
        public static string DefaultPathTo = "welcome.html";
        public static string DefaultEmail = "andriana@gmail.com";
        public static string DefaultRoleName = "Member";

        public static DateTime FakeBirthDate = new DateTime(2018, 9, 23);
        public static string FakeId = "207b701b-fe10-4f1b-80d8-47c772ea71d5";
        public static string FakeConfirmNum = "3764735";
        public static string FakeEmail = "someEmail@gmail.com";
        public static string FakeRoleName = "Guest";

        public static readonly UserDetailsDto userAll = new UserDetailsDto()
        {
            FirstName = DefaultString,
            LastName = DefaultString,
            Email = DefaultEmail,
            ImagePath = DefaultString
        };
        public static readonly LoginDto loginUser = new LoginDto
        {
            Email = DefaultEmail,
            Password = DefaultString,
        };
        public static readonly AuthUser authUser = new AuthUser
        { 
            Id = DefaultId,
            Role = DefaultRoleId,
            Email = DefaultEmail
        };
        public static readonly ForgotPasswordDto forgotPassword = new ForgotPasswordDto
        {
            Email = FakeEmail
        };
    }
}
