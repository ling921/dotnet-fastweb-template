# FastWeb Template
English | [简体中文](README_CN.md)

This is a `dotnet cli` based template for creating Web projects. It can also be used to generate CRUD items.

This project depends on [FastEndpoints](https://github.com/FastEndpoints/FastEndpoints)

> Documents references
> [Official tutorial](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/cli-templates-create-item-template)  
> [Official wiki](https://github.com/dotnet/templating/wiki/Reference-for-template.json)  
> [Official blog](https://devblogs.microsoft.com/dotnet/how-to-create-your-own-templates-for-dotnet-new/)  


## How to install template

1. locate into `FastWeb.sln` folder
2. run `dotnet new install ./`

note: it may cause `dotnet new fw` to fail if remove files inside


## How to modify and update template

1. make your changes
2. run `dotnet new install ./ --force`


## How to use template

1. run `dotnet new fw -?` to get help
2. run `dotnet new fw -n MyProject` to create project

| Option | Required | Default | Description |
| --- | --- | --- | --- |
| `-?` | | | get help |
| `-n` | `false` | | Solution name, default is output folder name |
| `-o` | `false` | | Output folder, default is folder command executed |
| `-t` | `false` | `project` | Type of dotnet cli creation, `project` to create project, `item` to create CRUD items |
| `-c` | `false` | `Core` | Project name without prefix for entities, DTOs and validators |
| `-s` | `false` | `Storage` | Project name without prefix for DbContext and entity type configuration |
| `-f` | `false` | `Infrastructure` | Project name without prefix for endpoints, services and mappers |
| `-w` | `false` | `Web` | Project name without prefix for startup and http files |
| `-r` | `false` | `false` | Whether to use RESTful API |
| `-e` | `false`\|`true` | `Sample` | Entity name without 'Entity' suffix, required when `-t item` |
| `-pk` | `false` | `int` | Primary key type of entity (`string`\|`int`\|`long`\|`guid`\|`object`) |
| `-pg` | `false` | `false` | Whether to use pagination for list query |

## How to uninstall template

1. locate into `FastWeb.sln` folder
2. run `dotnet new uninstall ./`


# Related projects

- [FastEndpoints](https://github.com/FastEndpoints/FastEndpoints)
- [FluentValidation](https://github.com/FluentValidation/FluentValidation)
- [AutoMapper](https://github.com/AutoMapper/AutoMapper)
- [Serilog.Extensions.Logging.File](https://github.com/serilog/serilog-extensions-logging-file)


# License

This project is licensed under the [MIT license](LICENSE).
