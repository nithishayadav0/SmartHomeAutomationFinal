using Microsoft.EntityFrameworkCore;
using SmartHomeAutomation.Data;
using SmartHomeAutomation.Models;

namespace SmartHomeAutomation.Repositories
{
    public class RoomRepository

    {
        private readonly SmartHomeDbContext _context;
        public RoomRepository(SmartHomeDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Rooms>> GetAvailableRooms()
        {

            return await _context.Rooms.Include(r => r.Devices).ToListAsync();
        }
        
        public async Task<Rooms> AddRoom(Rooms room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;

        }
        public async Task<IEnumerable<Rooms>> GetRoomsByUser(int userId)
        {
            var rooms = await _context.Rooms
                .Where(r => r.UserId == userId)
                .Include(r => r.Devices)
                .ToListAsync();

            return rooms;
        }
        public async Task<IEnumerable<Rooms>> FindRoomsByUserDetailsAsync(string username, string useremail)
        {
            return await _context.Rooms
                .Where(r => r.User.Username == username && r.User.Email == useremail)
                .ToListAsync();
        }

    }
}
