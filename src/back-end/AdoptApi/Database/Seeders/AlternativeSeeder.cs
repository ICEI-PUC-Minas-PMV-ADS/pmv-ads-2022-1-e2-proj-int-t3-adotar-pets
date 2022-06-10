using AdoptApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AdoptApi.Database.Seeders;

public class AlternativeSeeder : ISeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alternative>().HasData(
            new Alternative {Id = 1, QuestionId = 1, Title = "Imóvel próprio onde são permitidos animais de estimação."},
            new Alternative {Id = 2, QuestionId = 1, Title = "Imóvel alugado onde são permitidos animais de estimação."},
            new Alternative
            {
                Id = 3, QuestionId = 1, Title = "Imóvel próprio ou alugado, mas não sei se animais de estimação são permitidos.",
                MaleGenderPenalty = 50, FemaleGenderPenalty = 50
            },
            new Alternative {Id = 4, QuestionId = 2, Title = "Imóvel próprio onde são permitidos animais de estimação."},
            new Alternative {Id = 5, QuestionId = 2, Title = "Imóvel alugado onde são permitidos animais de estimação."},
            new Alternative
            {
                Id = 6, QuestionId = 2, Title = "Imóvel próprio ou alugado, mas não sei se animais de estimação são permitidos.",
                MaleGenderPenalty = 50, FemaleGenderPenalty = 50
            },
            new Alternative {Id = 7, QuestionId = 3, Title = "Casa com área externa (quintal, jardim, etc)."},
            new Alternative
            {
                Id = 8, QuestionId = 3, Title = "Casa sem área externa.",
                LargeSizePenalty = 10
            },
            new Alternative
            {
                Id = 9, QuestionId = 3, Title = "Casa com muro baixo.",
                LargeSizePenalty = 50
            },
            new Alternative
            {
                Id = 10, QuestionId = 3, Title = "Apartamento com tela.",
                MediumSizePenalty = 10, LargeSizePenalty = 20
            },
            new Alternative
            {
                Id = 11, QuestionId = 3, Title = "Apartamento sem tela.",
                SmallSizePenalty = 10, MediumSizePenalty = 15, LargeSizePenalty = 25
            },
            new Alternative {Id = 12, QuestionId = 4, Title = "Casa com área externa (quintal, jardim, etc)."},
            new Alternative {Id = 13, QuestionId = 4, Title = "Casa sem área externa."},
            new Alternative
            {
                Id = 14, QuestionId = 4, Title = "Casa com muro baixo.",
                MaleGenderPenalty = 25, FemaleGenderPenalty = 25
            },
            new Alternative {Id = 15, QuestionId = 4, Title = "Apartamento com tela."},
            new Alternative
            {
                Id = 16, QuestionId = 4, Title = "Apartamento sem tela.",
                MaleGenderPenalty = 20, FemaleGenderPenalty = 20
            },
            new Alternative
            {
                Id = 17, QuestionId = 5, Title = "Por mais de 12 horas ao dia.",
                MaleGenderPenalty = 20, FemaleGenderPenalty = 20
            },
            new Alternative
            {
                Id = 18, QuestionId = 5, Title = "De 6 a 12 horas ao dia.",
                MaleGenderPenalty = 10, FemaleGenderPenalty = 10
            },
            new Alternative {Id = 19, QuestionId = 5, Title = "Menos de 6 horas ao dia."},
            new Alternative
            {
                Id = 20, QuestionId = 6, Title = "Por mais de 12 horas ao dia.",
                MaleGenderPenalty = 20, FemaleGenderPenalty = 20
            },
            new Alternative
            {
                Id = 21, QuestionId = 6, Title = "De 6 a 12 horas ao dia.",
                MaleGenderPenalty = 10, FemaleGenderPenalty = 10
            },
            new Alternative {Id = 22, QuestionId = 6, Title = "Menos de 6 horas ao dia."},
            new Alternative {Id = 23, QuestionId = 7, Title = "Não."},
            new Alternative {Id = 24, QuestionId = 7, Title = "Há um ou mais pets."},
            new Alternative {Id = 25, QuestionId = 8, Title = "Não."},
            new Alternative {Id = 26, QuestionId = 8, Title = "Há um ou mais pets."},
            new Alternative {Id = 27, QuestionId = 9, Title = "Sim."},
            new Alternative
            {
                Id = 28, QuestionId = 9, Title = "Não.",
                MaleGenderPenalty = 50, FemaleGenderPenalty = 50
            },
            new Alternative {Id = 29, QuestionId = 10, Title = "Sim."},
            new Alternative
            {
                Id = 30, QuestionId = 10, Title = "Não.",
                MaleGenderPenalty = 50, FemaleGenderPenalty = 50
            },
            new Alternative {Id = 31, QuestionId = 11, Title = "Sim."},
            new Alternative
            {
                Id = 32, QuestionId = 11, Title = "Não.",
                MaleGenderPenalty = 50, FemaleGenderPenalty = 50
            },
            new Alternative {Id = 33, QuestionId = 12, Title = "Sim."},
            new Alternative
            {
                Id = 34, QuestionId = 12, Title = "Não.",
                MaleGenderPenalty = 50, FemaleGenderPenalty = 50
            },
            new Alternative {Id = 35, QuestionId = 13, Title = "Ração seca/úmida e/ou alimentos específicos para cachorros."},
            new Alternative
            {
                Id = 36, QuestionId = 13, Title = "Sobras de refeições.",
                MaleGenderPenalty = 20, FemaleGenderPenalty = 20
            },
            new Alternative {Id = 37, QuestionId = 14, Title = "Ração seca/úmida e/ou alimentos específicos para gatos."},
            new Alternative
            {
                Id = 38, QuestionId = 14, Title = "Sobras de refeições.",
                MaleGenderPenalty = 20, FemaleGenderPenalty = 20
            },
            new Alternative {Id = 39, QuestionId = 15, Title = "Sim, diariamente."},
            new Alternative
            {
                Id = 40, QuestionId = 15, Title = "Sim, de 3 a 5 vezes por semana.",
                LargeSizePenalty = 20,
                BabyAgePenalty = 10, AdultAgePenalty = 5
            },
            new Alternative
            {
                Id = 41, QuestionId = 15, Title = "Sim, de 1 a 2 vezes por semana.",
                SmallSizePenalty = 10, MediumSizePenalty = 15, LargeSizePenalty = 30,
                BabyAgePenalty = 15, AdultAgePenalty = 10, SeniorAgePenalty = 5
            },
            new Alternative
            {
                Id = 42, QuestionId = 15, Title = "Não.",
                MaleGenderPenalty = 50, FemaleGenderPenalty = 50
            },
            new Alternative {Id = 43, QuestionId = 16, Title = "Sim."},
            new Alternative {Id = 44, QuestionId = 16, Title = "Não, mas comprarei para o pet."},
            new Alternative
            {
                Id = 45, QuestionId = 16, Title = "Não, mas não será necessário.",
                MaleGenderPenalty = 20, FemaleGenderPenalty = 20
            },
            new Alternative {Id = 46, QuestionId = 17, Title = "Sim."},
            new Alternative
            {
                Id = 47, QuestionId = 17, Title = "Não.",
                MaleGenderPenalty = 50, FemaleGenderPenalty = 50
            },
            new Alternative {Id = 48, QuestionId = 18, Title = "Sim."},
            new Alternative
            {
                Id = 49, QuestionId = 18, Title = "Não.",
                MaleGenderPenalty = 50, FemaleGenderPenalty = 50
            },
            new Alternative {Id = 50, QuestionId = 19, Title = "Sim."},
            new Alternative
            {
                Id = 51, QuestionId = 19, Title = "Não.",
                MaleGenderPenalty = 50, FemaleGenderPenalty = 50
            },
            new Alternative {Id = 52, QuestionId = 20, Title = "Sim."},
            new Alternative
            {
                Id = 53, QuestionId = 20, Title = "Não.",
                MaleGenderPenalty = 50, FemaleGenderPenalty = 50
            }
        );
    }
}