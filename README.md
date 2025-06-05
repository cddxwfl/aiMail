# aiMail

aiMail 是一个用 C# 编写的简单邮件客户端示例，目标 **.NET&nbsp;9**。它演示了如何添加邮件账户、接收邮件并使用轻量级的 AI 进行信息过滤。

仓库包含位于 `src/AiMailClient` 的控制台应用，以及一个模仿 Foxmail 的 Windows Forms 程序 `src/AiMailWin`，界面提供账户列表、邮件列表和内容查看区，并可发送、接收邮件。程序使用 Deepseek 对邮件内容进行简单分析。

## Building

使用 .NET SDK 构建控制台项目：

```bash
dotnet build src/AiMailClient/AiMailClient.csproj
```

构建 Windows Forms 界面：

```bash
dotnet build src/AiMailWin/AiMailWin.csproj
```

## Running

运行控制台应用：

```bash
dotnet run --project src/AiMailClient/AiMailClient.csproj
```

启动 GUI：

```bash
dotnet run --project src/AiMailWin/AiMailWin.csproj
```

程序启动时会添加一个示例账户、接收一条虚拟邮件并对关键字 `important` 进行过滤。

