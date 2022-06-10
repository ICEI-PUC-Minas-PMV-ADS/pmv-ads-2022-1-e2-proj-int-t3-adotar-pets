using AdoptApi.Database;
using AdoptApi.Enums;
using AdoptApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AdoptApi.Repositories;

public class FormRepository
{
    private Context _context;

    public FormRepository(Context context)
    {
        _context = context;
    }

    public async Task<Alternative> GetAlternativeById(int id)
    {
        return await _context.Alternatives.SingleAsync(a => a.Id == id && a.IsActive == true);
    }

    public async Task<int> CountTotalQuestions(PetType type)
    {
        return await _context.Questions.CountAsync(q => q.IsActive == true && q.PetType == type);
    }

    public async Task<Question?> GetUnansweredQuestion(int lastAnsweredQuestionId, PetType type)
    {
        try
        {
            return await _context.Questions.Include(nameof(Question.Alternatives)).FirstAsync(q => q.Id > lastAnsweredQuestionId && q.PetType == type);
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }

    public async Task<Form> GetFormById(int id)
    {
        return await _context.Forms.Include(nameof(Form.Answers)).SingleAsync(f => f.Id == id);
    }

    public async Task<Form> GetOrCreateFormByUserAndPet(int userId, Pet pet)
    {
        try
        {
            return await _context.Forms.Include("Answers.Alternative").Where(f => f.UserId == userId && f.PetId == pet.Id).SingleAsync();
        }
        catch (InvalidOperationException)
        {
            var form = new Form {Pet = pet, UserId = userId, Answers = new List<Answer>()};
            await _context.AddAsync(form);
            await _context.SaveChangesAsync();
            return form;
        }
    }

    public async Task<Answer> AddAnswer(Answer answer)
    {
        await _context.AddAsync(answer);
        await _context.SaveChangesAsync();
        return answer;
    }

    public async Task<Form> UpdateForm(Form form)
    {
        _context.Update(form);
        await _context.SaveChangesAsync();
        return form;
    }
}