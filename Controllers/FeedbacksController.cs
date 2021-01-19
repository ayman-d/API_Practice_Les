using System.Collections.Generic;
using AutoMapper;
using Commander.Data.FeedbackRepo;
using Commander.DTOs.FeedbackDTOs;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public FeedbacksController(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _mapper = mapper;
            _feedbackRepository = feedbackRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Feedback>> GetAllFeedbacks()
        {
            var feedbacks = _feedbackRepository.GetAllFeedbacks();
            return Ok(_mapper.Map<IEnumerable<FeedbackReadDTO>>(feedbacks));
        }
    }
}