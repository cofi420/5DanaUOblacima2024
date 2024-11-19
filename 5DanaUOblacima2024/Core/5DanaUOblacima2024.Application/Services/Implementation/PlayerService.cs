using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5DanaUOblacima2024.Application.Contracts;
using _5DanaUOblacima2024.Application.Dto;
using _5DanaUOblacima2024.Application.Services.Interface;
using _5DanaUOblacima2024.Domain.Entities;

namespace _5DanaUOblacima2024.Application.Services.Implementation
{
    public class PlayerService: IPlayerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PlayerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Player? GetPlayerById(Guid id)
        {
            return _unitOfWork.PlayerRepository.GetById(id);
        }

        public bool IsNicknameUnique(string nickname)
        {
            return _unitOfWork.PlayerRepository.IsNicknameUnique(nickname);
        }

        public List<Player> GetAllPlayers()
        {
            throw new NotImplementedException();
        }

        public Player? AddPlayer(CreatePlayerDto playerDto)
        {
            if (!IsNicknameUnique(playerDto.Nickname))
            {
                return null;
            }
            var player = new Player(playerDto.Nickname);
            _unitOfWork.PlayerRepository.Add(player);
            return player;
        }

        public Player UpdatePlayer(Player player)
        {
            return _unitOfWork.PlayerRepository.Update(player, player.Id);
        }

        public void DeletePlayer(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
