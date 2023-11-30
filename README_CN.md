# DotNet CRUD Template
[English](README.md) | 简体中文

这是一个用于创建 CRUD 项目的模板

> 文档参考
> [Official tutorial](https://learn.microsoft.com/zh-cn/dotnet/core/tutorials/cli-templates-create-item-template)
> [Official wiki](https://github.com/dotnet/templating/wiki/Reference-for-template.json)
> [Official blog](https://devblogs.microsoft.com/dotnet/how-to-create-your-own-templates-for-dotnet-new/)


## 如何安装模板

```bash
dotnet new install src
```

note: 不能删除 `src` 文件夹及其内部的文件，会导致运行 `dotnet new cruditems` 时报错


## 如何修改和更新模板

1. 根据需求修改模板
2. 运行 `dotnet new install src --force`


## 如何使用模板

1. 运行 `dotnet new cruditems -?` 获取帮助
2. 运行 `dotnet new cruditems -n User -p MyProject -o src` 创建项目

| 选项 | 必填 | 默认 | 说明 |
| --- | --- | --- | --- |
| `-?` |  |  | 获取帮助 |
| `-n` | `true` |  | 实体名称 |
| `-p` | `true` |  | 项目前缀名 |
| `-k` | `false` | `object` | 实体主键类型(`string`\|`int`\|`long`\|`guid`\|`object`) |
| `-o` | `false` | `./` | 文件输出目录 |
| `-c` | `false` | `Core` | 放置实体和数据传输对象的不含前缀的项目名称 |
| `-s` | `false` | `Storage` | 放置实体配置的不含前缀的项目名称 |
| `-f` | `false` | `Infrastructure` | 放置服务和映射器的不含前缀的项目名称 |
| `-w` | `false` | `Web` | 放置控制器的不含前缀的项目名称 |
| `-dc` | `false` | `false` | 是否阻止生成控制器 |


## 如何卸载模板

```bash
dotnet new uninstall src
```