using System;
namespace QuizApp.Interfaces
{
    public interface ISessionStore
    {
        void PopulateSession(SignInContext sign_in, bool is_refresh = false);
    }
}
