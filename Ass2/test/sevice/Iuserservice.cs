using Microsoft.AspNetCore.Mvc;
using test.Model;

namespace test.Service
{
    public interface Iuserservice
    {
        public IActionResult Login(Loginguser loginguser);
        public User Singin(User newuser);
        public User Checked(User user);
        public User Tim(int id);
        public List<User> GetUsersByRole(string role);
        public User Xoa(User user);


    }
}
