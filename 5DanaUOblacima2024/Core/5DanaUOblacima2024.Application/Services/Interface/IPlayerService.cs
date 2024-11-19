using _5DanaUOblacima2024.Application.Dto;
using _5DanaUOblacima2024.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5DanaUOblacima2024.Application.Services.Interface
{
    public interface IPlayerService
    {
        Player? GetPlayerById(Guid id);
        Player GetPlayerByNickname(string nickname);
        List<Player> GetAllPlayers();
        Player? AddPlayer(CreatePlayerDto playerDto);
        Player UpdatePlayer(Player player);
        void DeletePlayer(Guid id);
    }
}
