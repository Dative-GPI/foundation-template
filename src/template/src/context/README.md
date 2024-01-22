# Context

## Fixtures

Fixtures for permissions and translations (and those you create) are generated programmatically.  
To do so, run the command `dotnet run -- fixtures generate` in the XXXXX.Context.Migrations folder.  
This command will create XML files in the *Fixtures* folder will the data updated.  
You can also create fixtures in JSON files by hand. The name should be the DTO in kebab-case

## Migrations

To generate migrations, first make sure that your fixtures are updated.  
Then, go to the right folder (XXXXX.Context.Migrations for the development environement, XXXXX.Context.Migrations-PRD for the production one).  
There, execute the command `dotnet ef migrations add <MIGRATION_NAME>`.

If you wish to remove a migration that has not yet been applied to a database, you can use the following command: `dotnet ef migrations remove --force`

You can create as many migrations as you want in the development folder as migrations will not be pushed.  
However, you should create migrations in the production folder only when needed (e.g. when creating a PR).
