# dotnet-crud-template

This is a template for dotnet-cli to create CRUD items.

> Documents references  
> [Official tutorial](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/cli-templates-create-item-template)  
> [Official wiki](https://github.com/dotnet/templating/wiki/Reference-for-template.json)  
> [Official blog](https://devblogs.microsoft.com/dotnet/how-to-create-your-own-templates-for-dotnet-new/)  


## How to install template

1. locate folder `src`
2. run `dotnet new -i ./`

note: can not delete `src` folder, it will cause error when running `dotnet new cruditems`

## How to modify and update template

1. make your changes
2. locate folder `src`
3. run `dotnet new -i ./ --force`

## How to use template

1. run `dotnet new cruditems -?` to get help
2. run `dotnet new cruditems -n User -p MyProject -o src` to create items


## How to uninstall template

1. locate folder `src`
2. run `dotnet new uninstall ./`
