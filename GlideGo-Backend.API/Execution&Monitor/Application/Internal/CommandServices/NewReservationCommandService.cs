using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Aggregates;
using GlideGo_Backend.API.Execution_Monitor.Domain.Model.Commands;
using GlideGo_Backend.API.Execution_Monitor.Domain.Repositories;
using GlideGo_Backend.API.Execution_Monitor.Domain.Services;
using GlideGo_Backend.API.Shared.Domain.Repositories;

namespace GlideGo_Backend.API.Execution_Monitor.Application.Internal.CommandServices
{
    public class ReservationCommandService : INewReservationCommandService
    {
        private readonly INewReservationRepository _reservationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReservationCommandService(INewReservationRepository reservationRepository, IUnitOfWork unitOfWork)
        {
            _reservationRepository = reservationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Reservation?> Handle(CreateReservationCommand command)
        {
            var reservation = await _reservationRepository.FindByVehicleIdAsync(command.VehicleId);
            if (reservation != null) throw new Exception("Reservation with this VehicleId already exists");

            reservation = new Reservation(command);

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
}