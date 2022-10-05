﻿
using CM.TeamReport.Domain.Services.Interfaces;
using CM.TeamRepots.DataLayer.Entity;
using CM.TeamRepots.DataLayer.Interfaces;
using CM.TeamRepots.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.TeamReport.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usersRepository;
        private readonly ILeaderRepository _leaderRepository;
        private readonly IRepository<Teams> _teamRepository;

        public UserService(IUserRepository usersRepository, ILeaderRepository leaderRepository, IRepository<Teams> teamsRepository)
        {
            _usersRepository = usersRepository;
            _leaderRepository = leaderRepository;
            _teamRepository = teamsRepository;
        }

        public void AddUser(Users user)
        {
            var passwordHashSalt = new PasswordHash().CreatePasswordHash(user.Password);
            user.Password = Convert.ToBase64String(passwordHashSalt.salt) + "." + Convert.ToBase64String(passwordHashSalt.hash) ;
            _usersRepository.Create(user);
        }

        public bool ChoseLeader(int teamId, int userId)
        {
            var user = _usersRepository.Read(userId);
            var team = _teamRepository.Read(teamId);

            if(user != null && team != null)
            {
                var leader = new Leaders() { TeamId = teamId, UserId = userId };

                _leaderRepository.Delete(userId);

                _leaderRepository.Create(leader);

                return true;
            }

            return false;
        }
    }
}

