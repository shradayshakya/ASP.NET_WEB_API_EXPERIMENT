## CLI

### Create Migrations
```
dotnet ef migrations add SeededCountriesAndHotels
```

### Scaffolding Controller
```
dotnet ef database update
```

### Scaffolding Controller
```
dotnet aspnet-codegenerator controller -name CountryController -m cs_webapi_experiment.Data.Country -dc cs_webapi_experiment.Data.HotelListingDbContext --relativeFolderPath Controllers -api
```
