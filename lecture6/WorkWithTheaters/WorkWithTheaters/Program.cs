using System.Linq.Expressions;
using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

WorkWithTheatersDbContext dbContext = new();
// Создание сущностей
//CreatePlay(dbContext);

// Получение сущностей
Theater theater = dbContext.Set<Theater>()
                                        // Говорим EF, что при выборе из таблицы Theater
                                        // Также необходимо включить в сборку все Play, которые относятся к Theater
                                        .Include(t => t.Plays)
                                        // -> WHERE t.Id == 1
                                        .FirstOrDefault(t => t.Id == 1);

var newPlay = new Play("Завершающее выступление", "Герасимов", DateTime.UtcNow.AddMinutes(10), DateTime.UtcNow.AddMinutes(15));
theater.Plays.Add(newPlay);
dbContext.SaveChanges();


Console.WriteLine("finished working");

void CreatePlay( WorkWithTheatersDbContext dbContext)
{
    // Создаем сущности
    var theater = new Theater("google meet", "***", "89276741289", DateTime.Parse("2012-11-11"));
    var play = new Play("В честь субботнего отдыха", "Нехваток времени в четверг", DateTime.UtcNow, DateTime.UtcNow);
    theater.Plays.Add(play);
    
    // Добавляем сущности в таблицу
    //playTable.Add(play);
    dbContext.Set<Theater>().Add(theater);

    // Сохраняем изменения
    dbContext.SaveChanges();
}