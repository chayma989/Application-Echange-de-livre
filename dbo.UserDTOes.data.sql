SET IDENTITY_INSERT [dbo].[UserDTOes] ON
INSERT INTO [dbo].[Users] ([Id], [Name], [Email], [Password], [TotalPoints], [Photo], [IsAdmin]) VALUES (1, N'Admin', N'admin@gmail.com', N'admin1010', 0, N'photo1', 1)
INSERT INTO [dbo].[Users] ([Id], [Name], [Email], [Password], [TotalPoints], [Photo], [IsAdmin]) VALUES (2, N'User', N'user@gmail.com', N'user1010', 0, N'photo1', 0)
INSERT INTO [dbo].[Users] ([Id], [Name], [Email], [Password], [TotalPoints], [Photo], [IsAdmin]) VALUES (11, N'Jiji', N'jiji@gmail.com', N'jiji1010', 0, N'photo2', 0)

SET IDENTITY_INSERT [dbo].[UserDTOes] OFF
