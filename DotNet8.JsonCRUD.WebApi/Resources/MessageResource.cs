namespace DotNet8.JsonCRUD.WebApi.Resources
{
    public static class MessageResource
    {
        public static string Success { get; set; } = "Success.";

        public static string SavingSuccess { get; set; } = "Saving Successful.";

        public static string SavingFail { get; set; } = "Saving Fail.";

        public static string UpdateSuccessful { get; set; } = "Updating Successful.";

        public static string UpdateFail { get; set; } = "Updaing Fail.";

        public static string DeleteSuccess { get; set; } = "Successfully Delete.";

        public static string DeleteFail { get; set; } = "Deleting Fail.";

        public static string NotFound { get; set; } = "No Data Found.";

        public static string Duplicate { get; set; } = "Data Already Exist";

        public static string Invalid { get; set; } = "Invalid";
    }
}
