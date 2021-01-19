using AutoMapper;
using Commander.DTOs.FeedbackDTOs;
using Commander.Models;

namespace Commander.Profiles
{
    public class FeedbacksProfile : Profile
    {
        public FeedbacksProfile()
        {
            CreateMap<Feedback, FeedbackReadDTO>();
        }
    }
}