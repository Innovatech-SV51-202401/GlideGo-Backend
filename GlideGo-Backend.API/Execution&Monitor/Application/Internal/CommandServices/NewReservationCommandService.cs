using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Entities;
using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Commands;
using GlideGo_Backend.API.Execution_Monitor.Domain.Repositories;
using GlideGo_Backend.API.Execution_Monitor.Domain.Services;
using GlideGo_Backend.API.Shared.Domain.Repositories;

namespace GlideGo_Backend.API.Execution_Monitor.Application.Internal.CommandServices;

public class ReservationCommandService : IReservationCommandService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly IActiveServiceRepository _activeServiceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ReservationCommandService(IReservationRepository reservationRepository, IActiveServiceRepository activeServiceRepository, IUnitOfWork unitOfWork)
    {
        _reservationRepository = reservationRepository;
        _activeServiceRepository = activeServiceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Reservation?> Handle(CreateReservationCommand command)
    {
        var activeService = await _activeServiceRepository.GetActiveServiceByUser(command.ClientId);
        if (activeService != null) throw new Exception("User already has an active service.");

        var reservation = new Reservation
        {
            ClientId = command.ClientId,
            VehicleId = command.VehicleId
        };

        try
        {
            await _reservationRepository.AddAsync(reservation);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            return null;
        }

        return reservation;
    }
}