using RealEstate.BLL.DTO;

namespace XUnitTestProject.DefaultValues
{
    public static class DefaultValues
    {
        public static double DefaultSize = 45.5;
        public static int DefaultCategory = 1;
        public static int DefaultFloorsNumber = 3;
        public static int DefaultFloors = 3;
        public static double DefaultPrice = 30000;
        public static string DefaultCity = "Lviv";
        public static string DefaultAddress = "Lukasha 5";
        public static int DefaultBuildYear = 2000;
        public static int DefaultStatus = 1;
        public static string DefaultUserId = "3f857412-cf5e-4087-bc85-6426fa791d91";
        public static string DefaultString = "Some string";
        public static int DefaultInt = 2;

        public static PropertyCreateDto propertyCreate = new PropertyCreateDto()
        {
            Size = DefaultSize,
            Сategory = DefaultCategory,
            FloorsNumber = DefaultFloorsNumber,
            Floors = DefaultFloors,
            Price = DefaultPrice,
            City = DefaultCity,
            Address = DefaultAddress,
            BuildYear = DefaultBuildYear,
            AgentsId = null,
            Photos = null,
            QuestionsDtos = null
        };
    }
}
