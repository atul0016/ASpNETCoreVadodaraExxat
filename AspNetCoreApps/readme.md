.NET Core Runtime
	- the "dotnet.exe"
		- Hosts the .NET Core app as "In-Process" for execution
ASP.NET Core Runtime	
	- ASP.NET WebForms
	- ASP.NET MVC
	- Api
# ============================================================================================================================
The Project file for InProc Hosting

  <PropertyGroup>
   <!--The Target Framework-->
    <TargetFramework>netcoreapp2.2</TargetFramework>
  <!--An Inprocess Hosting-->		
    <AspNetCoreHostingModel>InProcess</AspNetCoreHostingModel>
  </PropertyGroup>
#============================================================================================================================
  
Program.cs to provide initial application dependency configuration

The WebHosting Environment is created (Self-Host, IIS Express) WebHost uses the 'STartup' class to create default dependencies and object builder to
run and execute the application
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
