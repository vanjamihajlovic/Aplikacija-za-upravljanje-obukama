using AutoMapper;
using CourseManagementApp.DTO;
using CourseManagementApp.Model;
using CourseManagementApp.Service.Inteface;
using Microsoft.AspNetCore.Identity;

namespace CourseManagementApp.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public List<CandidateDTO> GetAllCandidates()
        {
            var canidates = _mapper.Map<List<CandidateDTO>>(_userManager.Users.Where(x => x.Role == Role.CANDIDATE).ToList());
            return canidates;
        }

        public List<MentorDTO> GetAllMentors()
        {
            var mentors = _mapper.Map<List<MentorDTO>>(_userManager.Users.Where(x => x.Role == Role.MENTOR).ToList());
            return mentors;
        }
    }
}
