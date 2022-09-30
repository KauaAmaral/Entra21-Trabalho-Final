using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Repositories.Generic;

namespace Entra21.CSharp.Area21.Repository.Repositories.Notifications
{
    public interface INotificationRepository : IGenericRepository<Notification>
    {
        Notification? GetByPlate(string plate);
    }
}