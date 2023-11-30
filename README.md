# DotNet CRUD Template
English | [简体中文](README_CN.md)

This is a template for dotnet-cli to create CRUD items.

> Documents references  
> [Official tutorial](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/cli-templates-create-item-template)  
> [Official wiki](https://github.com/dotnet/templating/wiki/Reference-for-template.json)  
> [Official blog](https://devblogs.microsoft.com/dotnet/how-to-create-your-own-templates-for-dotnet-new/)  


## How to install template

```bash
dotnet new install src
```

note: can not delete any item in `src` folder, it will cause error when running `dotnet new cruditems`


## How to modify and update template

1. make your changes
2. run `dotnet new install src --force`


## How to use template

1. run `dotnet new cruditems -?` to get help
2. run `dotnet new cruditems -n User -p MyProject -o src` to create items

| Option | Required | Default | Description |
| --- | --- | --- | --- |
| `-?` | | | get help |
| `-n` | `true` | | name of entity |
| `-p` | `true` | | project prefix |
| `-k` | `false` | `object` | primary key type of entity (`string`\|`int`\|`long`\|`guid`\|`object`) |
| `-o` | `false` | `./` | output folder |
| `-c` | `false` | `Core` | project name without prefix for entity and DTOs |
| `-s` | `false` | `Storage` | project name without prefix for entity type configuration |
| `-f` | `false` | `Infrastructure` | project name without prefix for service and mapper |
| `-w` | `false` | `Web` | project name without prefix for controllers |
| `-dc` | `false` | `false` | prevent generate controller |

## How to uninstall template

```bash
dotnet new uninstall src
```