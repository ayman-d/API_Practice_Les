using System.Collections.Generic;
using System.Linq;
using Commander.DataAccess;
using Commander.Models;

namespace Commander.Data.FeedbackRepo
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly CommanderContext _context;
        public FeedbackRepository(CommanderContext context)
        {
            _context = context;
        }

        public IEnumerable<Feedback> GetAllFeedbacks()
        {
            var feedbacks = _context.Feedbacks.ToList();
            return feedbacks;
        }
        public Feedback GetFeedbackById(int id)
        {
            throw new System.NotImplementedException();
        }
        public void CreateFeedback(Feedback feedback)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateFeedback(int id, Feedback feedback)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteFeedback(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}