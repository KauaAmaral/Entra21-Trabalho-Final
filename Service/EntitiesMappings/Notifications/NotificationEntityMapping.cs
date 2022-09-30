using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Repository.Enums;
using Entra21.CSharp.Area21.Service.ViewModels.Notifications;

namespace Entra21.CSharp.Area21.Service.EntitiesMappings.Notifications
{
    public class NotificationEntityMapping : INotificationEntityMapping
    {
        public Notification RegisterWith(NotificationRegisterViewModel viewModel) =>
            new Notification
            {
                GuardId = viewModel.GuardId,
                VehicleId = viewModel.VehicleId,
                VehicleLicensePlate = viewModel.VehiclePlate,
                RegisteredVehicle = viewModel.Registered,
                Comments = viewModel.Comments,
                Address = viewModel.Address,
                Value = (decimal)viewModel.Value,
                Type = viewModel.Type
            };

        public Notification UpdateWith(Notification notification, NotificationUpdateViewModel viewModel)
        {
            notification.Address = viewModel.Address;
            notification.UpdatedAt = DateTime.Now; 

            return notification;
        }
    }
}
