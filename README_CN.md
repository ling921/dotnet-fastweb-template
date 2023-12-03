# FastWeb Template
[English](README.md) | 简体中文

这是一个基于`dotnet cli`的用于创建Web项目的模板，同时可用于生成CRUD项。

这个项目依赖于[FastEndpoints](https://github.com/FastEndpoints/FastEndpoints)

> 文档参考
> [Official tutorial](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/cli-templates-create-item-template)
> [Official wiki](https://github.com/dotnet/templating/wiki/Reference-for-template.json)
> [Official blog](https://devblogs.microsoft.com/dotnet/how-to-create-your-own-templates-for-dotnet-new/)


## 如何安装模板

1. 定位到 `FastWeb.sln` 所在的文件夹
2. 运行 `dotnet new install ./`

note: 删除该模板内部的文件，可能会导致运行 `dotnet new fw` 时报错


## 如何修改和更新模板

1. 根据需求修改模板
2. 运行 `dotnet new install ./ --force`


## 如何使用模板

1. 运行 `dotnet new fw -?` 获取帮助
2. 运行 `dotnet new fw -n MyProject` 创建项目

| 选项 | 必填 | 默认 | 说明 |
| --- | --- | --- | --- |
| `-?` |  |  | 获取帮助 |
| `-n` | `true` |  | 解决方案名称，默认为输出文件夹名称 |
| `-o` | `false` |  | 文件输出目录，默认为当前命令执行的文件夹 |
| `-t` | `false` | `project` | 项目类型，`project` 为创建项目，`item` 为创建 CRUD 项 |
| `-c` | `false` | `Core` | 放置实体、数据传输对象和验证器的不含前缀的项目名称 |
| `-s` | `false` | `Storage` | 放置数据库上下文和实体配置的不含前缀的项目名称 |
| `-f` | `false` | `Infrastructure` | 放置终结点、服务和映射器的不含前缀的项目名称 |
| `-w` | `false` | `Web` | 放置程序集入口和 HTTP 文件的不含前缀的项目名称 |
| `-r` | `false` | `false` | 是否使用 RESTful API |
| `-e` | `false`\|`true` | `Sample` | 实体名称，当 `-t item` 时为必填 |
| `-pk` | `false` | `object` | 实体主键类型(`string`\|`int`\|`long`\|`guid`\|`object`) |
| `-pg` | `false` | `false` | 是否使用分页查询 |


## 如何卸载模板

1. 定位到 `FastWeb.sln` 所在的文件夹
2. 运行 `dotnet new uninstall ./`


# 相关项目

- [FastEndpoints](https://github.com/FastEndpoints/FastEndpoints)
- [FluentValidation](https://github.com/FluentValidation/FluentValidation)
- [AutoMapper](https://github.com/AutoMapper/AutoMapper)
- [Serilog.Extensions.Logging.File](https://github.com/serilog/serilog-extensions-logging-file)


# 许可证

本项目使用 [MIT 许可证](LICENSE)
