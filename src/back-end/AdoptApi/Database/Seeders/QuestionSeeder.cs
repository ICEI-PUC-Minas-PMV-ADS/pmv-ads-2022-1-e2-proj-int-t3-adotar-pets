using AdoptApi.Enums;
using AdoptApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AdoptApi.Database.Seeders;

public class QuestionSeeder : ISeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Question>().HasData(
            new Question {Id = 1, Title = "Eu moro em...", PetType = PetType.Dog},
            new Question {Id = 2, Title = "Eu moro em...", PetType = PetType.Cat},
            new Question {Id = 3, Title = "Meu tipo de residência é...", PetType = PetType.Dog},
            new Question {Id = 4, Title = "Meu tipo de residência é...", PetType = PetType.Cat},
            new Question {Id = 5, Title = "O pet ficará sozinho?", PetType = PetType.Dog},
            new Question {Id = 6, Title = "O pet ficará sozinho?", PetType = PetType.Cat},
            new Question {Id = 7, Title = "Há outros pets em casa?", PetType = PetType.Dog},
            new Question {Id = 8, Title = "Há outros pets em casa?", PetType = PetType.Cat},
            new Question {Id = 9, Title = "Em caso de viagens, há quem cuide do pet em sua ausência?", PetType = PetType.Dog},
            new Question {Id = 10, Title = "Em caso de viagens, há quem cuide do pet em sua ausência?", PetType = PetType.Cat},
            new Question {Id = 11, Title = "Está ciente/de acordo com a castração e vacinação?", PetType = PetType.Dog},
            new Question {Id = 12, Title = "Está ciente/de acordo com a castração e vacinação?", PetType = PetType.Cat},
            new Question {Id = 13, Title = "Como será a alimentação do pet?", PetType = PetType.Dog},
            new Question {Id = 14, Title = "Como será a alimentação do pet?", PetType = PetType.Cat},
            new Question {Id = 15, Title = "Você pode levar o pet para passear?", PetType = PetType.Dog},
            new Question {Id = 16, Title = "Possui caixa de transporte para o pet?", PetType = PetType.Cat},
            new Question {Id = 17, Title = "Está ciente/de acordo dos possíveis contratempos no processo de adaptação do pet?", PetType = PetType.Dog},
            new Question {Id = 18, Title = "Está ciente/de acordo dos possíveis contratempos no processo de adaptação do pet?", PetType = PetType.Cat},
            new Question {Id = 19, Title = "Está ciente/de acordo dos possíveis custos na manutenção do pet?", PetType = PetType.Dog},
            new Question {Id = 20, Title = "Está ciente/de acordo dos possíveis custos na manutenção do pet?", PetType = PetType.Cat}
        );
    }
}