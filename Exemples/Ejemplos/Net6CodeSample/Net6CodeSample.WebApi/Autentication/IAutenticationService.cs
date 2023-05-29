namespace Net6CodeSample.WebApi.Autentication
{
    public interface IAutenticationService
    {
        public string Autenticate(string profile);
        public string Generate(string user);
    }
}