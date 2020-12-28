using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrinkeMe.Dal;
using WrinkeMe.Dal.Repositories;
using WrinkMe.Domain;

namespace WrinkMe.Web.SignUp
{
    public partial class SignUp
    {
        [Inject] private IDbContextFactory<WrinkMeDataContext> ContextFactory { get; set; }
        [Inject] private NavigationManager Navigation { get; set; }
        private SignUpModel Model = new SignUpModel();

        private async Task SignUpUser()
        {
            using (var userRepo = new UserRepository(ContextFactory))
            {
                var user = await userRepo.SignUp(Model.Username, Model.Password, Model.Email);
                if (user != null)
                    Navigation.NavigateTo("/login");
            }
        }
    }
}
