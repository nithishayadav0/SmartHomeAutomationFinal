using SmartHomeAutomation.Models;
namespace SmartHomeAutomation.Services
{
    public interface IRoomService
    {
        public Task<IEnumerable<Rooms>> GetAllRoomsAsync();
        public  Task<IEnumerable<Rooms>> GetRoomsByUsernameAndEmail(string username, string useremail);
    }
}
