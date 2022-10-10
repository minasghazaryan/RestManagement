namespace RestManagement.Service.ServiceModels
{
    public class LoginResponseServiceModel
    {
        public LoginResponseServiceModel(string accessToken)
        {
            AccessToken = accessToken;
        }

        public string AccessToken { get; set; }
    }
}
