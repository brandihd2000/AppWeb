IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Paciente] (
    [idPaciente] int NOT NULL IDENTITY,
    [apellido] nvarchar(max) NULL,
    [cedula] nvarchar(max) NULL,
    [fechaNacimiento] datetime2 NOT NULL,
    [grupoSanguineo] nvarchar(max) NULL,
    [nombre] nvarchar(max) NULL,
    [telefono] nvarchar(max) NULL,
    CONSTRAINT [PK_Paciente] PRIMARY KEY ([idPaciente])
);

GO

CREATE TABLE [Usuario] (
    [idUsuario] int NOT NULL IDENTITY,
    [apellido] nvarchar(max) NULL,
    [contraseña] nvarchar(max) NULL,
    [email] nvarchar(max) NULL,
    [especialidad] nvarchar(max) NULL,
    [nombre] nvarchar(max) NULL,
    [tipo] nvarchar(max) NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([idUsuario])
);

GO

CREATE TABLE [Diagnostico] (
    [idDiagnostico] int NOT NULL IDENTITY,
    [comentario] nvarchar(max) NULL,
    [enfermedad] nvarchar(max) NULL,
    [especialidad] nvarchar(max) NULL,
    [fecha] datetime2 NOT NULL,
    [idDoctor] int NOT NULL,
    [idPaciente] int NOT NULL,
    [sintomas] nvarchar(max) NULL,
    [usuarioidUsuario] int NULL,
    CONSTRAINT [PK_Diagnostico] PRIMARY KEY ([idDiagnostico]),
    CONSTRAINT [FK_Diagnostico_Paciente_idPaciente] FOREIGN KEY ([idPaciente]) REFERENCES [Paciente] ([idPaciente]) ON DELETE CASCADE,
    CONSTRAINT [FK_Diagnostico_Usuario_usuarioidUsuario] FOREIGN KEY ([usuarioidUsuario]) REFERENCES [Usuario] ([idUsuario]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Diagnostico_idPaciente] ON [Diagnostico] ([idPaciente]);

GO

CREATE INDEX [IX_Diagnostico_usuarioidUsuario] ON [Diagnostico] ([usuarioidUsuario]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180626235233_Inicial', N'2.1.1-rtm-30846');

GO

