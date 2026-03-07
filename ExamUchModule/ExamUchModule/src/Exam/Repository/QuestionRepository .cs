using System.Text.Json;
using Exam.Entiti;

namespace Exam.Repository
{
    public class QuestionRepository : IQuestionRepository
    {

        private readonly string FilePath;
        public QuestionRepository()
        {
            FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Question.json");
            var directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

            
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

           
            if (!File.Exists(FilePath))
            {

                var stream = File.Create(FilePath);
                stream.Close();
            }
        }

        public List<Question>? GetAll()
        {
            var json = File.ReadAllText(FilePath);

            if (string.IsNullOrEmpty(json))
            {
                return new List<Question>();
            }

            var users = JsonSerializer.Deserialize<List<Question>>(json);
            return users;
        }

        public void SaveAll(List<Question> users)
        {
            var json = JsonSerializer.Serialize(users);
            File.WriteAllText(FilePath, json);
        }

        

    }

}
