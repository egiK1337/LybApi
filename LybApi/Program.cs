var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� ����� ������������
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ��������� �������� ApplicationContext � �������� ������� � ����������/ ��� ���� ������� ������� ����� ���� ������ ����� ���� ����������� �����������
//� ���� ����� ���������� ������ �������� ������
builder.Services.AddDbContext<EfCoreContext>(options => options.UseSqlServer(connection));



//���� �������� �����������
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


//1. �� �������� � weatherForcoast ������� ����� get ������� ����� �������� ��� ����� ��� �������. +
//2. ������� ��� ���� ����� GET ������� ����� � ��������. ���� ��� ��� ������� ���� ��� ���� ������������. +
//3. ����������� Post Get ������� +-
//4. �������� ����������� � �������� ����������� -+
//5. ������� ����� ������� �� id ����� � ������ BookGetById(int bookId) ���� ���������� DTO ��� �� ������� �
//6.  �������� � ������ json  � Postman +-
//7 ������ ������� https://metanit.com/sharp/aspnet6/12.1.php      https://metanit.com/sharp/aspnet6/2.11.php
//8 ���������� �������� ������ � ����������� � ��������� � ��� ������ https://www.infoworld.com/article/3568209/how-to-pass-parameters-to-action-methods-in-asp-net-core-mvc.html
//9. ����� https://rutracker.org/forum/viewtopic.php?t=6096673
//10. ����� 7. ���������� ( � �# metanit) +
//11. ����� 10. ��������� ( � �# metanit) +
//12. ����� 14. ���������������  ( � �# metanit) +
//13. ����� 16. A���������� ����������������. Task-based Asynchronous Pattern ( � �# metanit) +
//14. ������ � git +
//15 ��������� static int BookAdd(BookAddDto bookAddDto) ��������� ������... ������������ +
//16 ��������� ����� ������ , �������� ���� webUrl +
//17 ������� ����� �������� ������. ���� ������ ������ ��� �� ��� ������, ���� �� ���� �� ����������� ( �������� ��������� �� ����, �� �����). ����� ������ ���������� �������� +
//18 ������� ����� ������������� ������ +
//19 ������� �������� ���������� �� ������ AuthorsController � ��������� ��������� ������ ������ [Route("BookGetById/{bookId:int}")]???
//20 �������� � AuthorsController ����������� ������ ��� � BooksController
//21 ����������
//22 �������� �����������
//23 �����
//24 ��� ������ �� booksController ��������� � booksLogic � ���� ����� ��� authorContoller.
//����� � ���������� ��� ������ �� � ���� ��������� ������ baseController �� dbContex

//27.04.2023
//25 ������� ������ �����
//26 ��� �������� � ��� �������� � ����� ������� ����, ��� � ����, � �� ��� � ��������� ����
//27 ����������� � ���������
//28 ������� ������ �������� � ������� �������� (-Project -Datalayer) ���������, ��� default project LibraryApi
//29 ��������� �� ����������� �� ����������� � ������(������) �������

