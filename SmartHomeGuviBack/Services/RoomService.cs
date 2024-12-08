using SmartHomeAutomation.Models;
using SmartHomeAutomation.Repositories;
namespace SmartHomeAutomation.Services
{
    public class RoomService
    {
        private readonly RoomRepository _roomsRepository;

        public RoomService(RoomRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }

        // Get all rooms
        public async Task<IEnumerable<Rooms>> GetAllRoomsAsync()
        {
            return await _roomsRepository.GetAvailableRooms();
        }
        public async Task<Rooms> AddRooms(Rooms room)
        {
            return await _roomsRepository.AddRoom(room);
        }

        public async Task<IEnumerable<Rooms>> GetRoomsByUser(int userId)
        {
            return await _roomsRepository.GetRoomsByUser(userId);
        }
        public async Task<IEnumerable<Rooms>> GetRoomsByUsernameAndEmail(string username, string useremail)
        {
            // Assuming a repository pattern is used
            return await _roomsRepository.FindRoomsByUserDetailsAsync(username, useremail);
        }


    }
}
