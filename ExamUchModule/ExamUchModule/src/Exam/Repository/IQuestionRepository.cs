using Exam.Entiti;

namespace Exam.Repository
{
    public interface IQuestionRepository
    {
        public List<Question>? GetAll();
        public void SaveAll(List<Question> question);
    }
}
