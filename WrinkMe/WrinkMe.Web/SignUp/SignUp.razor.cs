using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrinkMe.Domain;

namespace WrinkMe.Web.SignUp
{
    public partial class SignUp
    {
        [Inject] private IUserRepository UserRepo { get; set; }
        [Inject] private NavigationManager Navigation { get; set; }
        private SignUpModel Model = new SignUpModel();

        private async Task SignUpUser()
        {
            var user = await UserRepo.SignUp(Model.Username, Model.Password, Model.Email);
            if (user != null)
                Navigation.NavigateTo("/login");

        }
    }
}
