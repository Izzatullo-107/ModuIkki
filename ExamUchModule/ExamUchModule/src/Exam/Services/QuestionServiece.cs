using Exam.DTOs;
using Exam.Entiti;
using Exam.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace Exam.Services;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository QuestionRepository;

    private QuestionGetDto QuestionGetDtos(Question q)
    {
        return new QuestionGetDto()
        {
            QuestionId = q.QuestionId,
            Text = q.Text,
            VariantA = q.VariantA,
            VariantB = q.VariantB,
            VariantC = q.VariantC,

        };
    }


    public QuestionService()
    {
        QuestionRepository= new QuestionRepository();
    }

    public Guid Add(QuestionCreatDto questionCreatDto)
    {
        
        var questions = QuestionRepository.GetAll();
        var newQuestion = new Question
        {
           QuestionId=Guid.NewGuid(),
           Text = questionCreatDto.Text,
           VariantA = questionCreatDto.VariantA,
           VariantB = questionCreatDto.VariantB,
           VariantC = questionCreatDto.VariantC,
           Answer= questionCreatDto.Answer
        };
        questions.Add(newQuestion);
        QuestionRepository.SaveAll(questions);
        return newQuestion.QuestionId;
    }

    public List<QuestionGetDto> GetAllQuestions()
    {
        var test = QuestionRepository.GetAll();
        if (test == null)
        { test = new List<Question>(); return new List<QuestionGetDto>(); }

        var test2 = test.Select(q => QuestionGetDtos(q)).ToList();
        return test2;
    }


    public bool UpdateQuestion(Guid questionId,QuestionUpdateDto questionNew)
    {
        var questions = QuestionRepository.GetAll();

        if (questions == null)
        { questions = new List<Question>(); return false; }

        foreach (var question in questions)
        {
            if(question.QuestionId==questionId)
            {
                question.Text = questionNew.Text;
                question.VariantA = questionNew.VariantA;
                question.VariantB = questionNew.VariantB;
                question.VariantC = questionNew.VariantC;
                question.Answer = questionNew.Answer;
            }
        }

        QuestionRepository.SaveAll(questions);

        return true;
    }



    public bool DeleteQuestion(Guid questionId)
    {
        var questions = QuestionRepository.GetAll();
        if (questions == null)
        { questions = new List<Question>(); return false; }

        foreach (var question in questions)
        {
            if (question.QuestionId == questionId)
            {
                questions.Remove(question);
                QuestionRepository.SaveAll(questions);
                return true;
            }
        }

        return false;
    }

    public (bool, string) SolveQuestion(Guid questionId, string answer)
    {
        var questions = QuestionRepository.GetAll();
        if (questions == null)
        { questions = new List<Question>(); return (false,string.Empty); }

        var res = string.Empty;

        foreach(var question in questions)
        {
            if(question.QuestionId== questionId)
            {
                res = question.Answer;
                if(question.Answer==answer)
                {
                    return (true, answer);
                }
                
            }
        }
        return (false, res);
    }

    public QuestionGetDto GetRandomQuestion()
    {
        var questions = QuestionRepository.GetAll();
        if (questions == null)
        { questions = new List<Question>(); return new QuestionGetDto(); }

        Random random = new Random();

        for(var i=0; i<=questions.Count();i++)
        {
            if(i==random.Next(0,questions.Count()+1))
            {
                return QuestionGetDtos(questions[i]);
            }
        }
        return new QuestionGetDto();
    }

    public int GetQuestionCount()
    {
        var questions = QuestionRepository.GetAll();
        if (questions == null)
        { questions = new List<Question>(); return 0; }

        return questions.Count();
    }
}
