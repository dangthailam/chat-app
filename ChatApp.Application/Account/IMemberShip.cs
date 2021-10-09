namespace ChatApp.ApplicationService
{
    public interface IMemberShip
    {
        void Register(string email, string password);

        void Login(string email, string password);
    }
}