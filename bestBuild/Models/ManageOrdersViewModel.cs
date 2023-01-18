using bestBuild.DAL.Entities;

namespace bestBuild.Models;

public class ManageOrdersViewModel
{
    public List<ClientCred> ClientsList { get; set; } = null!;
    public ClientCred? Client { get; set; }
}