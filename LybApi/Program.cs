var builder = WebApplication.CreateBuilder(args);

// получаем строку подключения из файла конфигурации
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение/ Это поле сервиса которое будет жить всегда когда наше прилождение запустилось
//в него можно накидывать разные полезные плюшки
builder.Services.AddDbContext<EfCoreContext>(options => options.UseSqlServer(connection));



//своя иньекция зависимости
//builder.Services.AddSingleton<ITest, TestConcrete>();
//builder.Services.AddSingleton<ITest, TestConcreteSecond>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//1. по аналагии с weatherForcoast сделать метод get который будет отдавать ВСЕ книги без фильтра. +
//2. Сделать ещё один метод GET который будет с фильтром. Весь код для методов есть его надо адаптировать. +
//3. Разобраться Post Get запросы +-
//4. инверсия зависимости и инверсия зависимости -+
//5. сделать метод который по id книги её отдаст BookGetById(int bookId) если подходящей DTO нет то создать её
//6.  дочитать и понять json  и Postman +-
//7 читать метанит https://metanit.com/sharp/aspnet6/12.1.php      https://metanit.com/sharp/aspnet6/2.11.php
//8 посмотреть создание метода с параметрами и повторить в моём случае https://www.infoworld.com/article/3568209/how-to-pass-parameters-to-action-methods-in-asp-net-core-mvc.html
//9. книга https://rutracker.org/forum/viewtopic.php?t=6096673
//10. Глава 7. Интерфейсы ( о с# metanit) +
//11. Глава 10. Коллекции ( о с# metanit) +
//12. Глава 14. Многопоточность  ( о с# metanit) +
//13. Глава 16. Aсинхронное программирование. Task-based Asynchronous Pattern ( о с# metanit) +
//14. залить в git +
//15 перенести static int BookAdd(BookAddDto bookAddDto) перенести логику... адаптировать +
//16 расширить класс автора , добавить туда webUrl +
//17 сделать метод создания автора. Если такого автора нет то его создаём, если он есть то редактируем ( кретерий сравнения не айди, по имени). Метод должен возвращать АвторДто +
//18 сделать метод редактировния автора +
//19 создать отдельнй контроллер на автора AuthorsController и перенести имеющиеся методы ВОПРОС [Route("BookGetById/{bookId:int}")]???
//20 добавить в AuthorsController аналогичные методы как в BooksController
//21 интерфейсы
//22 иньекция зависимости
//23 шилдт
//24 все методы из booksController перенести в booksLogic и тоже самое для authorContoller.
//Когда я перенесету все методы то я могу избавится внутри baseController от dbContex

//27.04.2023
//25 Удалить лишние папки
//26 все сущности и дто привести к моему старому типу, как у меня, а не как в исходнике Вити
//27 Разобраться в пагинации
//28 удалить старые миграции и сделать миграцию (-Project -Datalayer) убедиться, что default project LibraryApi
//29 избавится от зависимости от лайбрариАпи с сервис(бизнес) логикой

