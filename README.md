# SerilogLogging

-------------

### Packages:
 
-------------

#### Serilog.AspNetCore 3.4.0
#### Serilog.Settings.Configuration 3.1.0
#### Serilog.Sinks.MSSqlServer 5.6.0

--------------------------

### Database Table Script:

--------------------------

```
CREATE TABLE [SerilogLoggingTable] (
   [Id] int IDENTITY(1,1) NOT NULL,
   [Message] nvarchar(max) NULL,
   [MessageTemplate] nvarchar(max) NULL,
   [Level] nvarchar(128) NULL,
   [TimeStamp] datetimeoffset(7) NOT NULL,
   [Exception] nvarchar(max) NULL,
   [Properties] xml NULL,
   [LogEvent] nvarchar(max) NULL

   CONSTRAINT [PK_Log]
	 PRIMARY KEY CLUSTERED ([Id] ASC)
)
```

----------

### Notes:

----------

1. While using Serilog use appsetting.json for logging configuration.
2. It's a good practice to use logging in a single controller. 
3. Don't show error messages or exception to user. Log it down to Serilog file.
4. Don't make file extension as .txt, instead use a different custom extension.
