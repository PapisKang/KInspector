# Kentico Inspector

[![Join the chat at https://kentico-community.slack.com](https://img.shields.io/badge/join-slack-E6186D.svg)](https://kentico-community.slack.com)
[![Build](https://github.com/kentico/kinspector/actions/workflows/dotnet.yml/badge.svg)](https://github.com/kentico/kinspector/actions/workflows/dotnet.yml)
[![first-timers-only](https://img.shields.io/badge/first--timers--only-friendly-blue.svg)](http://www.firsttimersonly.com/)
[![Github All Releases](https://img.shields.io/github/downloads/kentico/kinspector/total.svg)](https://github.com/Kentico/KInspector/releases)

Kentico Inspector (formerly KInspector) is an application for analyzing the health, performance and security of **[Kentico EMS](https://www.kentico.com/)** solutions.

Kentico Inspector was initially developed as an internal application by the Kentico consulting team to help evaluation customer's web sites. We quickly realized that the broader community would benefit from this as well, so we made it open source.

The application is Kentico version agnostic and has no dependencies on version-specific DLLs. Most modules are designed to support version 10 and later, but some will work on older versions as well.

## Running Kentico Inspector

You can download the [latest release](https://github.com/Kentico/KInspector/releases/latest) and extract the contents to a local directory to use [console](#console-mode) or [IIS](#iis-mode) mode.

> :round_pushpin: **Note:** 
> 
> The application needs permission to create/modify files in the directory it is run from to save instances to a file.

Or, you can clone this repository and follow [these instructions](#local-development) to run the application locally.

### Console mode

Console mode is useful if you just want to quickly run the tool occasionally. To use console mode, run `KenticoInspector.WebApplication.exe` and open your browser to either https://localhost:5001 or http://localhost:5000.

### IIS mode

IIS mode allows you to have the tool always available, for example, on a development server. To use IIS mode, point your IIS directory to the folder you extracted everything to and make sure the application pool's .NET CLR version is set to `No managed code`. Open the site in your browser.

## Contributing

Want to improve the Kentico Inspector? Great! Read the [contributing guidelines](https://github.com/Kentico/KInspector/blob/master/CONTRIBUTING.md) and then [check out the open issues](https://github.com/Kentico/KInspector/issues) (especially issues marked as "[good first issue](https://github.com/Kentico/KInspector/labels/good%20first%20issue)") to get started.

If anything feels wrong or incomplete, please let us know. Create a new [issue](https://github.com/Kentico/KInspector/issues/new) or submit a [pull request](https://help.github.com/articles/using-pull-requests/).

## Local development

### Requirements

All versions below are from a known working environment. Lower versions may work but are not tested.

- [Visual Studio 2017 updated to 15.9.11 or later](https://visualstudio.microsoft.com/vs/)
- [.NET Core 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node for Windows (10.15.X - 20.7.0)](https://nodejs.org/en/)
- [NPM (6.4.X - 10.1.0) (included with Node)](https://www.npmjs.com/)
- [Vue CLI (3.x)](https://cli.vuejs.org/)

### First run

Even if you don't plan to make any changes in the Client UI application, you'll need to build it before your first run and any time the client code is updated. To build the Client UI application:

#### Frontend build instructions
1. Open Powershell/Command Prompt
1. Change the directory to `./KenticoInspector.WebApplication/ClientApp`
1. Run `npm i`
1. Run `npm run build`

#### Backend build instructions

1. Open `KInspector.sln` in Visual Studio
1. Do a build
1. Make sure the `KenticoInspector.WebApplication` project is the start up project
1. You can run it with either the `IIS Express` or `Console` debug launch settings

If you want to work on the Client UI applicaiton without running `npm run build` any time the code changes, you can set up an automatic build process:

1. Open Powershell/Command Prompt
1. Change the directory to `./KenticoInspector.WebApplication/ClientApp`
1. Run `npm i` (if you haven't already)
1. Run `npm run serve`
1. Leave the terminal open
1. Follow the steps to build the backend, but run it using the `UI Development` debug launch settings.
   - This runs the backend with a proxy to the running instance you started in Powershell and allows you to take advantage of the hot-reloading of the client application

