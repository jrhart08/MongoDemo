using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using MongoDemo.Data;
using MongoDemo.MediatorHandlers;
using System;

namespace MongoDemo.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            AddWebApi(builder);
            AddMediatR(builder);
            AddMongo(builder);

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
        }

        static void AddMongo(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IFormsMongoClient, FormsMongoClient>((provider) =>
            {
                string connString = builder.Configuration.GetConnectionString("MongoConnectionString");

                return new FormsMongoClient(connString);
            });
        }

        static void AddWebApi(WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        static void AddMediatR(WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(
                typeof(MediatorHandlersRef)
            );
        }
    }
}