using bestBuild.DAL.Data;
using bestBuild.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace bestBuild.Areas.Identity.Pages.Account.Manage;

public class OrdersModel : PageModel
{
    private readonly UserManager<ClientCred> _userManager;
    private readonly SignInManager<ClientCred> _signInManager;
    private readonly AppDbContext context;

    public List<Order>? Orders { get; set; }

    public OrdersModel(
        UserManager<ClientCred> userManager,
        SignInManager<ClientCred> signInManager,
        AppDbContext context
        )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        this.context = context;
    }

    private async Task LoadAsync(ClientCred user, AppDbContext context)
    {
        Orders = await context.Orders.Where(o => o.ClientId == user.Id).Include(o => o.Products).ToListAsync();

    }
    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        }

        await LoadAsync(user, context);
        return Page();
    }

}
