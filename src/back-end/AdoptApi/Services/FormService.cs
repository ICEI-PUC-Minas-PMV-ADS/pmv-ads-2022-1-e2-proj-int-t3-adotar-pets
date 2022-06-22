using AdoptApi.Enums;
using AdoptApi.Models;
using AdoptApi.Models.Dtos;
using AdoptApi.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AutoMapper;

namespace AdoptApi.Services;

public class FormService
{
    private readonly ModelStateDictionary _modelState;
    private FormRepository _formRepository;
    private PetRepository _petRepository;
    private readonly IMapper _mapper;

    public FormService(IActionContextAccessor actionContextAccessor, FormRepository repository, PetRepository petRepository, IMapper mapper)
    {
        _modelState = actionContextAccessor.ActionContext.ModelState;
        _formRepository = repository;
        _petRepository = petRepository;
        _mapper = mapper;
    }

    private QuestionDto GetQuestionDto(Question question)
    {
        return _mapper.Map<Question, QuestionDto>(question);
    }

    private FormDto GetFormDto(Form form, int totalQuestions, Question? question)
    {
        return new FormDto
        {
            Id = form.Id,
            CurrentQuestion = question != null ? GetQuestionDto(question) : null,
            IsFinished = form.IsFinished,
            Percentage = (double) form.Answers.Count * 100 / totalQuestions,
            TotalQuestions = totalQuestions,
            QuestionsLeft = totalQuestions - form.Answers.Count
        };
    }

    public async Task<FormDto?> GetAdoptionProgress(int userId, int petId)
    {
        Console.WriteLine(petId);
        try {
            var pet = await _petRepository.GetAvailablePet(petId);
            var form = await _formRepository.GetOrCreateFormByUserAndPet(userId, pet);
            var currentQuestion = await _formRepository.GetUnansweredQuestion(form.Answers.LastOrDefault()?.Alternative.QuestionId ?? 0, form.Pet.Type);
            var totalQuestions = await _formRepository.CountTotalQuestions(pet.Type);
            return GetFormDto(form, totalQuestions, currentQuestion);
        }
        catch (InvalidOperationException)
        {
            _modelState.AddModelError("Pet", "Pet não existe ou não está mais ativo.");
            return null;
        }
    }

    public async Task<FormDto?> AnswerQuestion(int userId, int petId, int? alternativeId)
    {
        try
        {
            var formDto = await GetAdoptionProgress(userId, petId);
            if (formDto == null)
            {
                return null;
            }

            if (formDto.IsFinished || formDto.CurrentQuestion == null)
            {
                _modelState.AddModelError("Form", "Não há mais perguntas para responder.");
                return null;
            }

            var alternative = await _formRepository.GetAlternativeById(formDto.CurrentQuestion.Alternatives.SingleOrDefault(a => a.Id == alternativeId)?.Id ?? 0);
            var pet = await _petRepository.GetAvailablePet(petId);
            var answer = new Answer
            {
                Alternative = alternative,
                FormId = formDto.Id,
                Penalties = CalculatePenalty(alternative, pet)
            };
            await _formRepository.AddAnswer(answer);
            var form = await _formRepository.GetFormById(formDto.Id);
            form.IsFinished = form.Answers.Count == formDto.TotalQuestions;
            form.TotalScore -= answer.Penalties;
            await _formRepository.UpdateForm(form);
            return await GetAdoptionProgress(userId, petId);
        }
        catch (InvalidOperationException)
        {
            _modelState.AddModelError("Alternative", "Alternativa não encontrada.");
            return null;
        }
    }

    private static int GetPetSizePenalty(Alternative alternative, Pet pet)
    {
        return pet.Size switch
        {
            PetSize.Small => alternative.SmallSizePenalty,
            PetSize.Medium => alternative.MediumSizePenalty,
            PetSize.Large => alternative.SmallSizePenalty,
            _ => 0
        };
    }
    
    private static int GetPetAgePenalty(Alternative alternative, Pet pet)
    {
        var years = DateOnly.FromDateTime(DateTime.Now).Year - pet.BirthDate.Year;
        return years switch
        {
            < 1 => alternative.BabyAgePenalty,
            < 7 => alternative.AdultAgePenalty,
            _ => alternative.SeniorAgePenalty
        };
    }

    private static int GetPetGenderPenalty(Alternative alternative, Pet pet)
    {
        return pet.Gender switch
        {
            PetGender.Male => alternative.MaleGenderPenalty,
            _ => alternative.FemaleGenderPenalty
        };
    }

    private static int CalculatePenalty(Alternative alternative, Pet pet)
    {
        var penalty = 0;
        penalty += GetPetSizePenalty(alternative, pet);
        penalty += GetPetAgePenalty(alternative, pet);
        penalty += GetPetGenderPenalty(alternative, pet);
        return penalty;
    }
    public async Task<List<FormProtectorDto>> ListFormsByPetId(int protectorId, int petId)
    {
        var forms = await _formRepository.ListFormsByPet(petId, protectorId);
        return _mapper.Map<List<Form>, List<FormProtectorDto>>(forms);
    }

    public async Task<FormProtectorDto?> ViewFormApplication(int protectorId, int formId)
    {
        try
        {
            var form = await _formRepository.GetFormByIdAndProtector(formId, protectorId);
            return _mapper.Map<Form, FormProtectorDto>(form);
        } catch (InvalidOperationException)
        {
            _modelState.AddModelError("Form", "Formulário não encontrado.");
            return null;
        }
    }
}