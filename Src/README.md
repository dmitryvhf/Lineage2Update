# Lineage2Update
Lineage II Client Updater tool.

![Lineage2Update demo screen](https://github.com/dmitryvhf/Lineage2Update/Docs/Images/LineageIIUpdate-demo.png)

## Features
Client self-update support.  
Lightweight server services.  
Can modding for any products.  
Can use without Administrator privelegies.

## Current stage
Shared old project to game community.  
Migrating VB.NET source code to C#. Refactoring code to latest .NET.  
Creating documentation for modding and using.

## Architecture
### Server side
#### Admin tool for content generation
Tool for generating web-hosting content and self update file.
#### Web-hosting content folder
Web-hosting folder for content downloading. Static content.
### Client side
Tool executable and configuration file. Configuration: content source address and other settings.
