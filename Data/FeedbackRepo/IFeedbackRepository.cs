using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data.FeedbackRepo
{
    public interface IFeedbackRepository
    {
        bool SaveChanges();
        IEnumerable<Feedback> GetAllFeedbacks();
        Feedback GetFeedbackById(int id);
        void CreateFeedback(Feedback feedback);
        void UpdateFeedback(int id, Feedback feedback);
        void DeleteFeedback(int id);
    }
}