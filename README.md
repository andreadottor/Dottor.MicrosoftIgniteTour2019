# Dottor.MicrosoftIgniteTour2019
Demo della sessione "Real case: migrate from Web Forms to ASP.NET Core gradually" [15 minuti] tenuta al Microsoft Ignite The Tour di Milano il 1 febbraio 2019.

- Progetto **Dottor.NewCoreApplication.Web** ASP.NET Core 2.2. 
  - Emula il comportamento di una nuova applicazione.
  - Sfrutta le Razor Pages per facilitare la migrazione da Web Form (es: Pages/Cities/List.cshtml)
- Progetto **Dottor.WebFormApplication.Web** ASP.NET WebForm (.NET Framework 4.7.2). 
  - Simula una vecchia aplicazione da portare verso ASP.NET Core.
  - Se si tenta di accedere ad una pagina che richiede autenticazione, si viene rimandati verso l'applicazione ASP.NET Core.
  - Le due applicazione condividono i cookie di autenticazione
- Progetto **Dottor.MicrosoftIgnite.Data** Class Library (.NetStandard)
  - Contiene le classi di accesso ai dati, condivise tra i due applicativi

## Link utili per approfondire l'argomento
- [.NET Standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)
- [Share cookies among apps with ASP.NET and ASP.NET Core](https://docs.microsoft.com/it-it/aspnet/core/security/cookie-sharing?view=aspnetcore-2.2)
- [Cookie Sharing Sample App](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/cookie-sharing/sample/)
- [Introduction to Razor Pages in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-2.2&tabs=visual-studio)
- [Get Started with ASP.NET Core and Entity Framework 6](https://docs.microsoft.com/en-us/aspnet/core/data/entity-framework-6?view=aspnetcore-2.2)
- [Porting an EF6 Code-Based Model to EF Core](https://docs.microsoft.com/en-us/ef/efcore-and-ef6/porting/port-code)