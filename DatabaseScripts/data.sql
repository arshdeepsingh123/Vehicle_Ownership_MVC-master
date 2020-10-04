INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'e084adee-2bdf-46ae-9bab-abea3b7dd5d4', N'admin@vehicles.com', N'ADMIN@VEHICLES.COM', N'admin@vehicles.com', N'ADMIN@VEHICLES.COM', 1, N'AQAAAAEAACcQAAAAEFH9lJbcDfz9tBThDHTrbc+ORozGw2fvIszkXrK3hJlZYbkMUbdv9OaRmeQu1Eo76w==', N'TZ4N353BG5IVLJBOUJZXCHCEABHGZAKK', N'd5c404f5-9a39-485d-a7ba-b51538ebc221', NULL, 0, 0, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Citizen] ON
INSERT INTO [dbo].[Citizen] ([Id], [Name], [Address]) VALUES (1, N'John Franklin', N'340A Queen Street Auckland')
INSERT INTO [dbo].[Citizen] ([Id], [Name], [Address]) VALUES (2, N'Stephen Daniel ', N'345B Great South Rd, Auckland')
INSERT INTO [dbo].[Citizen] ([Id], [Name], [Address]) VALUES (3, N'David Harris', N'340G Queen Street Auckland')
SET IDENTITY_INSERT [dbo].[Citizen] OFF
SET IDENTITY_INSERT [dbo].[Vehicle] ON
INSERT INTO [dbo].[Vehicle] ([Id], [RegistrationNumber], [RegisteredDate]) VALUES (1, N'LYE567', N'2020-09-12 09:00:00')
INSERT INTO [dbo].[Vehicle] ([Id], [RegistrationNumber], [RegisteredDate]) VALUES (2, N'GYE567', N'2020-08-29 10:20:00')
INSERT INTO [dbo].[Vehicle] ([Id], [RegistrationNumber], [RegisteredDate]) VALUES (3, N'GYH568', N'2020-07-10 11:30:00')
SET IDENTITY_INSERT [dbo].[Vehicle] OFF
SET IDENTITY_INSERT [dbo].[OwnerShip] ON
INSERT INTO [dbo].[OwnerShip] ([Id], [VehicleId], [CitizenId]) VALUES (1, 1, 1)
INSERT INTO [dbo].[OwnerShip] ([Id], [VehicleId], [CitizenId]) VALUES (2, 3, 3)
INSERT INTO [dbo].[OwnerShip] ([Id], [VehicleId], [CitizenId]) VALUES (3, 2, 2)
SET IDENTITY_INSERT [dbo].[OwnerShip] OFF
