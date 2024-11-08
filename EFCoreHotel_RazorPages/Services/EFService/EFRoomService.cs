using EFCoreHotel_RazorPages.HotelDBContext;
using EFCoreHotel_RazorPages.Models;
using EFCoreHotel_RazorPages.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreHotel_RazorPages.Services.EFService
{
    public class EFRoomService : IRoomService
    {
        private HoteldbContext context;
        public EFRoomService(HoteldbContext service)
        {
            context = service;
        }

        public Room GetRoom(int hotel, int roomNo)
        {
            IQueryable<Room> result = context.Rooms.Where<Room>(r =>r.HotelNo == hotel && r.RoomNo == roomNo);
            result = result.Include(r => r.HotelNoNavigation);
            result = result.Include(r => r.Bookings).ThenInclude(b => b.GuestNoNavigation); 
            return result.FirstOrDefault();
        }

        public IEnumerable<Room> GetRooms()
        {
            return context.Rooms;
        }
    }
}
