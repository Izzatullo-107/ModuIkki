
using WebApplication1.NodePractice;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var builder = WebApplication.CreateBuilder(args);

            //// Add services to the container.

            //builder.Services.AddControllers();
            //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            //var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            //app.UseHttpsRedirection();

            //app.UseAuthorization();


            //app.MapControllers();

            //app.Run();

            Node node = NodeService.CreateNode(4);
            var res = GetLengthOfNode(node);
            Console.WriteLine(res);


        }

        static int GetLengthOfNode(Node node)
        {
            var counter = 0;
            while (true)
            {
                if (node != null)
                {
                    ++counter;
                }
                if (node.Next == null)
                {
                    break;
                }
                node = node.Next;
            }

            return counter;
        }
    }
}