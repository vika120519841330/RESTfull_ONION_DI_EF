using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using InfrastructureServices.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureServices.Contexts
{
    public class MyContext : DbContext
    {
        public DbSet<ClientInfrastr> Clients { get; set; }
        public DbSet<AccountInfrastr> Accounts { get; set; }

        //Конструктор, инициализирующий БД
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        // Конфигурирование подключения к БД
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
        //                                Database=clientsaccounts;
        //                                Trusted_Connection=True;");
        //}

        // Инициализация БД начальными значениями
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region
            // Инициализация таблицы с моделями Client
            modelBuilder.Entity<ClientInfrastr>().HasData(
                 new ClientInfrastr
                 {
                     ClientId = 1,
                     ClientTitle = "Стриго",
                     ClientMarkJuridical = false,
                     ClientTaxpayNum = "MP1234565"
                 },
                 new ClientInfrastr
                 {
                     ClientId = 2,
                     ClientTitle = "Петров Петр Петрович",
                     ClientMarkJuridical = false,
                     ClientTaxpayNum = "PB1234964"
                 },
                 new ClientInfrastr
                 {
                     ClientId = 3,
                     ClientTitle = "Сидоров Николай Петрович",
                     ClientMarkJuridical = false,
                     ClientTaxpayNum = "PB7812764"
                 },
                 new ClientInfrastr
                 {
                     ClientId = 4,
                     ClientTitle = "Стройтехносистем",
                     ClientMarkJuridical = true,
                     ClientTaxpayNum = "123456789"
                 },
                 new ClientInfrastr
                 {
                     ClientId = 5,
                     ClientTitle = "Види",
                     ClientMarkJuridical = true,
                     ClientTaxpayNum = "123456788"
                 },
                 new ClientInfrastr
                 {
                     ClientId = 6,
                     ClientTitle = "Промтехнология",
                     ClientMarkJuridical = true,
                     ClientTaxpayNum = "123456787"
                 },
                 new ClientInfrastr
                 {
                     ClientId = 7,
                     ClientTitle = "Модная Галактика",
                     ClientMarkJuridical = true,
                     ClientTaxpayNum = "123456786"
                 }
                 );
            #endregion

            #region
            // Инициализация таблицы с моделями Account
            modelBuilder.Entity<AccountInfrastr>().HasData(
                new AccountInfrastr
                {
                    AccountId = 1,
                    AccountBalance = 120,
                    AccountNumber = "123456781",
                    ClientClientId = 1
                },
                new AccountInfrastr
                {
                    AccountId = 2,
                    AccountBalance = 0,
                    AccountNumber = "123456782",
                    ClientClientId = 1
                },
                new AccountInfrastr
                {
                    AccountId = 3,
                    AccountBalance = 1100,
                    AccountNumber = "123456783",
                    ClientClientId = 2
                },
                new AccountInfrastr
                {
                    AccountId = 4,
                    AccountBalance = 1230,
                    AccountNumber = "123456784",
                    ClientClientId = 2
                },
                new AccountInfrastr
                {
                    AccountId = 5,
                    AccountBalance = 57457,
                    AccountNumber = "123456785",
                    ClientClientId = 3
                },
                 new AccountInfrastr
                 {
                     AccountId = 6,
                     AccountBalance = 1250,
                     AccountNumber = "123456786",
                     ClientClientId = 4
                 },
                 new AccountInfrastr
                 {
                     AccountId = 7,
                     AccountBalance = 124530,
                     AccountNumber = "123456787",
                     ClientClientId = 4
                 },
                 new AccountInfrastr
                 {
                     AccountId = 8,
                     AccountBalance = 0,
                     AccountNumber = "123456788",
                     ClientClientId = 5
                 },
                 new AccountInfrastr
                 {
                     AccountId = 9,
                     AccountBalance = 6550,
                     AccountNumber = "123456789",
                     ClientClientId = 6
                 },
                 new AccountInfrastr
                 {
                     AccountId = 10,
                     AccountBalance = 124530,
                     AccountNumber = "123456790",
                     ClientClientId = 6
                 },
                new AccountInfrastr
                {
                    AccountId = 11,
                    AccountBalance = 0,
                    AccountNumber = "123456791",
                    ClientClientId = 6
                },
                new AccountInfrastr
                {
                    AccountId = 12,
                    AccountBalance = 15990,
                    AccountNumber = "123456792",
                    ClientClientId = 7
                }
                );
            #endregion

            modelBuilder.ApplyConfiguration<ClientInfrastr>(new ClientConfiguration());
            modelBuilder.ApplyConfiguration<AccountInfrastr>(new AccountConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnModelCreating
        //    (ModelBuilder modelBuilder) =>
        //       base
        //        .OnModelCreating
        //        (
        //           modelBuilder
        //           .ApplyConfiguration<AccountInfrastr>(new AccountConfiguration())
        //           .ApplyConfiguration<ClientInfrastr>(new ClientConfiguration())
        //        );

    }
}

