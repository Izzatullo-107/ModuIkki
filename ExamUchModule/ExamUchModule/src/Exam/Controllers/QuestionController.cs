using Exam.DTOs;
using Exam.Entiti;
using Exam.Repository;
using Exam.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Exam.Controllers;



[ApiController]
[Route("question")]
public class QuestionController : ControllerBase
{

    private readonly IQuestionService questionService;
    public QuestionController()
    {
        questionService = new QuestionService();
    }

    [HttpPost]
    public Guid Add(QuestionCreatDto questionCreatDto)
    {
        return questionService.Add(questionCreatDto);
    }

    [HttpGet]
    public List<QuestionGetDto> GetAllQuestions()
    {
        return questionService.GetAllQuestions();
    }

    [HttpPut]
    public bool UpdateQuestion(Guid questionId, QuestionUpdateDto questionNew)
    {
        return questionService.UpdateQuestion(questionId, questionNew);
    }

    [HttpDelete]
    public bool DeleteQuestion(Guid questionId)
    {
        return questionService.DeleteQuestion(questionId);
    }


    [HttpPut]
    public (bool, string) SolveQuestion(Guid questionId, string answer) 
    {
        return questionService.SolveQuestion(questionId,answer);
    }

    [HttpPut]
    public QuestionGetDto GetRandomQuestion()
    {
        return questionService.GetRandomQuestion();
    }

    [HttpPut]
    public int GetQuestionCount()
    {
        return questionService.GetQuestionCount();
    }
}


