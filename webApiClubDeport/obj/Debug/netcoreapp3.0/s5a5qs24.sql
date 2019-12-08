IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] nvarchar(450) NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);

GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191203211439_LoginSystem', N'3.0.0');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] ON;
INSERT INTO [AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName])
VALUES (N'f406bd6e-0de4-4679-874d-33bcb9c6861b', N'0d5f8cf2-d92a-4caa-80d0-69d916f42e78', N'admin', N'admin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'Name', N'NormalizedName') AND [object_id] = OBJECT_ID(N'[AspNetRoles]'))
    SET IDENTITY_INSERT [AspNetRoles] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191204195253_admin', N'3.0.0');

GO

CREATE TABLE [Deportes] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NULL,
    CONSTRAINT [PK_Deportes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Socios] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NULL,
    [Apellido] nvarchar(max) NULL,
    [Telefono] int NOT NULL,
    [Mail] nvarchar(max) NULL,
    [Baja] bit NOT NULL,
    CONSTRAINT [PK_Socios] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Pistas] (
    [id] int NOT NULL IDENTITY,
    [numero] nvarchar(max) NULL,
    [descripcion] nvarchar(max) NULL,
    [localizacion] nvarchar(max) NULL,
    [deporteId] int NULL,
    CONSTRAINT [PK_Pistas] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Pistas_Deportes_deporteId] FOREIGN KEY ([deporteId]) REFERENCES [Deportes] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Reservas] (
    [Id] int NOT NULL IDENTITY,
    [Fecha] datetime2 NOT NULL,
    [Hora] int NOT NULL,
    [SocioId] int NULL,
    [Pistaid] int NULL,
    CONSTRAINT [PK_Reservas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Reservas_Pistas_Pistaid] FOREIGN KEY ([Pistaid]) REFERENCES [Pistas] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Reservas_Socios_SocioId] FOREIGN KEY ([SocioId]) REFERENCES [Socios] ([Id]) ON DELETE NO ACTION
);

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'278b2da3-6cb8-40ed-b50c-10f58d0ba6c1'
WHERE [Id] = N'f406bd6e-0de4-4679-874d-33bcb9c6861b';
SELECT @@ROWCOUNT;


GO

CREATE INDEX [IX_Pistas_deporteId] ON [Pistas] ([deporteId]);

GO

CREATE INDEX [IX_Reservas_Pistaid] ON [Reservas] ([Pistaid]);

GO

CREATE INDEX [IX_Reservas_SocioId] ON [Reservas] ([SocioId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191206101035_entidades', N'3.0.0');

GO

ALTER TABLE [Pistas] DROP CONSTRAINT [FK_Pistas_Deportes_deporteId];

GO

ALTER TABLE [Reservas] DROP CONSTRAINT [FK_Reservas_Pistas_Pistaid];

GO

EXEC sp_rename N'[Reservas].[Pistaid]', N'PistaId', N'COLUMN';

GO

EXEC sp_rename N'[Reservas].[IX_Reservas_Pistaid]', N'IX_Reservas_PistaId', N'INDEX';

GO

EXEC sp_rename N'[Pistas].[numero]', N'Numero', N'COLUMN';

GO

EXEC sp_rename N'[Pistas].[localizacion]', N'Localizacion', N'COLUMN';

GO

EXEC sp_rename N'[Pistas].[descripcion]', N'Descripcion', N'COLUMN';

GO

EXEC sp_rename N'[Pistas].[deporteId]', N'DeporteId', N'COLUMN';

GO

EXEC sp_rename N'[Pistas].[id]', N'Id', N'COLUMN';

GO

EXEC sp_rename N'[Pistas].[IX_Pistas_deporteId]', N'IX_Pistas_DeporteId', N'INDEX';

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'4488be39-24e4-4e96-b86a-acab624c92d8'
WHERE [Id] = N'f406bd6e-0de4-4679-874d-33bcb9c6861b';
SELECT @@ROWCOUNT;


GO

ALTER TABLE [Pistas] ADD CONSTRAINT [FK_Pistas_Deportes_DeporteId] FOREIGN KEY ([DeporteId]) REFERENCES [Deportes] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [Reservas] ADD CONSTRAINT [FK_Reservas_Pistas_PistaId] FOREIGN KEY ([PistaId]) REFERENCES [Pistas] ([Id]) ON DELETE NO ACTION;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191206165726_Pista', N'3.0.0');

GO

ALTER TABLE [Pistas] DROP CONSTRAINT [FK_Pistas_Deportes_DeporteId];

GO

ALTER TABLE [Reservas] DROP CONSTRAINT [FK_Reservas_Pistas_PistaId];

GO

ALTER TABLE [Reservas] DROP CONSTRAINT [FK_Reservas_Socios_SocioId];

GO

DROP INDEX [IX_Pistas_DeporteId] ON [Pistas];

GO

DROP INDEX [IX_Reservas_SocioId] ON [Reservas];
DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Reservas]') AND [c].[name] = N'SocioId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Reservas] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Reservas] ALTER COLUMN [SocioId] int NOT NULL;
CREATE INDEX [IX_Reservas_SocioId] ON [Reservas] ([SocioId]);

GO

DROP INDEX [IX_Reservas_PistaId] ON [Reservas];
DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Reservas]') AND [c].[name] = N'PistaId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Reservas] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Reservas] ALTER COLUMN [PistaId] int NOT NULL;
CREATE INDEX [IX_Reservas_PistaId] ON [Reservas] ([PistaId]);

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Pistas]') AND [c].[name] = N'DeporteId');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Pistas] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Pistas] ALTER COLUMN [DeporteId] nvarchar(max) NULL;

GO

ALTER TABLE [Pistas] ADD [DeporteId1] int NULL;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'e7de2365-b9ef-493a-9a1c-9026591efedd'
WHERE [Id] = N'f406bd6e-0de4-4679-874d-33bcb9c6861b';
SELECT @@ROWCOUNT;


GO

CREATE INDEX [IX_Pistas_DeporteId1] ON [Pistas] ([DeporteId1]);

GO

ALTER TABLE [Pistas] ADD CONSTRAINT [FK_Pistas_Deportes_DeporteId1] FOREIGN KEY ([DeporteId1]) REFERENCES [Deportes] ([Id]) ON DELETE NO ACTION;

GO

ALTER TABLE [Reservas] ADD CONSTRAINT [FK_Reservas_Pistas_PistaId] FOREIGN KEY ([PistaId]) REFERENCES [Pistas] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [Reservas] ADD CONSTRAINT [FK_Reservas_Socios_SocioId] FOREIGN KEY ([SocioId]) REFERENCES [Socios] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191206173411_Pistas', N'3.0.0');

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'9620c544-623a-4755-922d-c08cdccbf069'
WHERE [Id] = N'f406bd6e-0de4-4679-874d-33bcb9c6861b';
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191206173718_pistas01', N'3.0.0');

GO

ALTER TABLE [Pistas] DROP CONSTRAINT [FK_Pistas_Deportes_DeporteId1];

GO

DROP INDEX [IX_Pistas_DeporteId1] ON [Pistas];

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Pistas]') AND [c].[name] = N'DeporteId1');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Pistas] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Pistas] DROP COLUMN [DeporteId1];

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Pistas]') AND [c].[name] = N'DeporteId');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Pistas] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Pistas] ALTER COLUMN [DeporteId] int NOT NULL;

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'1b2748a6-b2e1-446f-b7bc-d1bd2bc2499a'
WHERE [Id] = N'f406bd6e-0de4-4679-874d-33bcb9c6861b';
SELECT @@ROWCOUNT;


GO

CREATE INDEX [IX_Pistas_DeporteId] ON [Pistas] ([DeporteId]);

GO

ALTER TABLE [Pistas] ADD CONSTRAINT [FK_Pistas_Deportes_DeporteId] FOREIGN KEY ([DeporteId]) REFERENCES [Deportes] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191206174116_pistas02', N'3.0.0');

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'c331dd97-6829-41f8-9fec-37ab8e607390'
WHERE [Id] = N'f406bd6e-0de4-4679-874d-33bcb9c6861b';
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191206174142_pistas03', N'3.0.0');

GO

UPDATE [AspNetRoles] SET [ConcurrencyStamp] = N'274c3e91-bf6c-4fd1-a0a3-504ad2edd331'
WHERE [Id] = N'f406bd6e-0de4-4679-874d-33bcb9c6861b';
SELECT @@ROWCOUNT;


GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191206174605_pistas04', N'3.0.0');

GO

