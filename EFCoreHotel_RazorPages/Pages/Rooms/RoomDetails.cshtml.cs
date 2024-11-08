using EFCoreHotel_RazorPages.Models;
using EFCoreHotel_RazorPages.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreHotel_RazorPages.Pages.Rooms
{
    public class RoomDetailsModel : PageModel
    {
        public Room Room { get; set; }
        IRoomService roomService;
        public RoomDetailsModel(IRoomService service)
        {
            roomService = service;
        }
        public void OnGet(int id1, int id2)
        {
            Room = roomService.GetRoom(id1, id2);
        }
    }
}
