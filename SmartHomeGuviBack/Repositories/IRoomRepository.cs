using System.Threading.Tasks;
using SmartHomeAutomation.Models;

namespace SmartHomeAutomation.Repositories
{
    public interface IRoomRepository
    {
        Task<Rooms> AddRoom(Rooms room);
        public Task<IEnumerable<Rooms>> GetAvailableRooms();
        Task<IEnumerable<Rooms>> FindRoomsByUserDetailsAsync(string username, string useremail);
        Task<IEnumerable<Rooms>> GetRoomsByUser(int userId);
    }
}
