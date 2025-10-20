IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [AspNetRoles] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetUsers] (
    [Id] uniqueidentifier NOT NULL,
    [ReferrerId] uniqueidentifier NULL,
    [Password] nvarchar(max) NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
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
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUsers_AspNetUsers_ReferrerId] FOREIGN KEY ([ReferrerId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [categoryFoodPlans] (
    [Id] int NOT NULL IDENTITY,
    [name] nvarchar(max) NULL,
    CONSTRAINT [PK_categoryFoodPlans] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Sickness] (
    [Id] int NOT NULL IDENTITY,
    [name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Sickness] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [State] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_State] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Symptoms] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_Symptoms] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] uniqueidentifier NOT NULL,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] uniqueidentifier NOT NULL,
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
    [UserId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] uniqueidentifier NOT NULL,
    [RoleId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] uniqueidentifier NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Opinion] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [insertTime] datetime2 NULL,
    [userId] uniqueidentifier NULL,
    CONSTRAINT [PK_Opinion] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Opinion_AspNetUsers_userId] FOREIGN KEY ([userId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [userId] uniqueidentifier NOT NULL,
    [TotalPrise] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_AspNetUsers_userId] FOREIGN KEY ([userId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Foodplan] (
    [Id] int NOT NULL IDENTITY,
    [UserId] uniqueidentifier NULL,
    [ExpirationDate] datetime2 NOT NULL,
    [DuratioTImeMeal] int NULL,
    [CategoryFoodPlanId] int NOT NULL,
    CONSTRAINT [PK_Foodplan] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Foodplan_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Foodplan_categoryFoodPlans_CategoryFoodPlanId] FOREIGN KEY ([CategoryFoodPlanId]) REFERENCES [categoryFoodPlans] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [City] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [stateId] int NOT NULL,
    CONSTRAINT [PK_City] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_City_State_stateId] FOREIGN KEY ([stateId]) REFERENCES [State] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Food] (
    [Id] int NOT NULL IDENTITY,
    [name] nvarchar(max) NOT NULL,
    [FoodPlanId] int NOT NULL,
    CONSTRAINT [PK_Food] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Food_Foodplan_FoodPlanId] FOREIGN KEY ([FoodPlanId]) REFERENCES [Foodplan] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [OrderItems] (
    [Id] int NOT NULL IDENTITY,
    [orderId] int NULL,
    [foodplanId] int NULL,
    [price] decimal(18,2) NULL,
    CONSTRAINT [PK_OrderItems] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_OrderItems_Foodplan_foodplanId] FOREIGN KEY ([foodplanId]) REFERENCES [Foodplan] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_OrderItems_Orders_orderId] FOREIGN KEY ([orderId]) REFERENCES [Orders] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Spice] (
    [Id] int NOT NULL IDENTITY,
    [name] int NOT NULL,
    [foodPlanId] int NOT NULL,
    CONSTRAINT [PK_Spice] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Spice_Foodplan_foodPlanId] FOREIGN KEY ([foodPlanId]) REFERENCES [Foodplan] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Vitamins] (
    [Id] int NOT NULL IDENTITY,
    [name] int NOT NULL,
    [foodPlanId] int NOT NULL,
    CONSTRAINT [PK_Vitamins] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Vitamins_Foodplan_foodPlanId] FOREIGN KEY ([foodPlanId]) REFERENCES [Foodplan] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [UserInfo] (
    [Id] int NOT NULL IDENTITY,
    [UserId] uniqueidentifier NOT NULL,
    [ImageUrls] nvarchar(max) NULL,
    [gender] int NULL,
    [marrige] int NULL,
    [LastMeal] nvarchar(max) NULL,
    [FavoritFood] nvarchar(max) NULL,
    [ActionSkiny] nvarchar(max) NULL,
    [CityId] int NULL,
    [AbdominalRound] decimal(18,2) NULL,
    [ArmRound] decimal(18,2) NULL,
    [ThighRound] decimal(18,2) NULL,
    [LegRound] decimal(18,2) NULL,
    [AssRound] decimal(18,2) NULL,
    [ImageFiles] nvarchar(max) NULL,
    [Deal] bit NULL,
    [wakeTime] int NULL,
    [SleepTime] int NULL,
    [BreakfastMeal] nvarchar(max) NULL,
    [morningBetweenMeal] nvarchar(max) NULL,
    [LaunchMeal] nvarchar(max) NULL,
    [LaunchTime] nvarchar(max) NULL,
    [dinnerMeal] nvarchar(max) NULL,
    [dinnerTime] nvarchar(max) NULL,
    [EaveningMeal] nvarchar(max) NULL,
    [Job] nvarchar(max) NULL,
    [DailyActivity] nvarchar(max) NULL,
    [BirthDay] nvarchar(max) NULL,
    [registerDate] nvarchar(max) NULL,
    [Historysickness] nvarchar(max) NULL,
    [age] int NULL,
    [height] int NULL,
    [weight] int NULL,
    [dislikeFood] nvarchar(max) NULL,
    [medicineUse] nvarchar(max) NULL,
    [favoriteFood] nvarchar(max) NULL,
    [DurationUsed] nvarchar(max) NULL,
    CONSTRAINT [PK_UserInfo] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserInfo_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UserInfo_City_CityId] FOREIGN KEY ([CityId]) REFERENCES [City] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Medicins] (
    [Id] int NOT NULL IDENTITY,
    [name] nvarchar(max) NOT NULL,
    [UserInfoId] int NULL,
    CONSTRAINT [PK_Medicins] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Medicins_UserInfo_UserInfoId] FOREIGN KEY ([UserInfoId]) REFERENCES [UserInfo] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [SicknessUserInfo] (
    [sicKnessId] int NOT NULL,
    [userInfosId] int NOT NULL,
    CONSTRAINT [PK_SicknessUserInfo] PRIMARY KEY ([sicKnessId], [userInfosId]),
    CONSTRAINT [FK_SicknessUserInfo_Sickness_sicKnessId] FOREIGN KEY ([sicKnessId]) REFERENCES [Sickness] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_SicknessUserInfo_UserInfo_userInfosId] FOREIGN KEY ([userInfosId]) REFERENCES [UserInfo] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [SymptomsUserInfo] (
    [SymptomsId] int NOT NULL,
    [userInfosId] int NOT NULL,
    CONSTRAINT [PK_SymptomsUserInfo] PRIMARY KEY ([SymptomsId], [userInfosId]),
    CONSTRAINT [FK_SymptomsUserInfo_Symptoms_SymptomsId] FOREIGN KEY ([SymptomsId]) REFERENCES [Symptoms] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_SymptomsUserInfo_UserInfo_userInfosId] FOREIGN KEY ([userInfosId]) REFERENCES [UserInfo] ([Id]) ON DELETE NO ACTION
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

CREATE INDEX [IX_AspNetUsers_ReferrerId] ON [AspNetUsers] ([ReferrerId]);
GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;
GO

CREATE INDEX [IX_City_stateId] ON [City] ([stateId]);
GO

CREATE INDEX [IX_Food_FoodPlanId] ON [Food] ([FoodPlanId]);
GO

CREATE INDEX [IX_Foodplan_CategoryFoodPlanId] ON [Foodplan] ([CategoryFoodPlanId]);
GO

CREATE INDEX [IX_Foodplan_UserId] ON [Foodplan] ([UserId]);
GO

CREATE INDEX [IX_Medicins_UserInfoId] ON [Medicins] ([UserInfoId]);
GO

CREATE INDEX [IX_Opinion_userId] ON [Opinion] ([userId]);
GO

CREATE INDEX [IX_OrderItems_foodplanId] ON [OrderItems] ([foodplanId]);
GO

CREATE INDEX [IX_OrderItems_orderId] ON [OrderItems] ([orderId]);
GO

CREATE INDEX [IX_Orders_userId] ON [Orders] ([userId]);
GO

CREATE INDEX [IX_SicknessUserInfo_userInfosId] ON [SicknessUserInfo] ([userInfosId]);
GO

CREATE INDEX [IX_Spice_foodPlanId] ON [Spice] ([foodPlanId]);
GO

CREATE INDEX [IX_SymptomsUserInfo_userInfosId] ON [SymptomsUserInfo] ([userInfosId]);
GO

CREATE INDEX [IX_UserInfo_CityId] ON [UserInfo] ([CityId]);
GO

CREATE UNIQUE INDEX [IX_UserInfo_UserId] ON [UserInfo] ([UserId]);
GO

CREATE INDEX [IX_Vitamins_foodPlanId] ON [Vitamins] ([foodPlanId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251018080700_InitExisting', N'8.0.19');
GO

COMMIT;
GO

