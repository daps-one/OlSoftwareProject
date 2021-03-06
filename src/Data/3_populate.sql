USE [Projects]
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([StatusId], [Description]) VALUES (1, N'En Negociación')
INSERT [dbo].[Status] ([StatusId], [Description]) VALUES (2, N'En Proceso')
INSERT [dbo].[Status] ([StatusId], [Description]) VALUES (3, N'Termiando')
INSERT [dbo].[Status] ([StatusId], [Description]) VALUES (4, N'Anulado')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([ClientId], [Name], [Identification], [Address], [Phone]) VALUES (1, N'Bancolombia', N'11223132145', N'Carrera 30 # 20-50', N'3552214')
INSERT [dbo].[Client] ([ClientId], [Name], [Identification], [Address], [Phone]) VALUES (2, N'Pepito Perez', N'1550541145', N'Calle 170 # 45-20', N'6355214')
INSERT [dbo].[Client] ([ClientId], [Name], [Identification], [Address], [Phone]) VALUES (3, N'Lopez Asociados', N'9500120054', N'Av Americas # 65-06', N'9551247')
INSERT [dbo].[Client] ([ClientId], [Name], [Identification], [Address], [Phone]) VALUES (4, N'Calc SA', N'9851216548', N'Carrera 14 # 15-85', N'9543215')
INSERT [dbo].[Client] ([ClientId], [Name], [Identification], [Address], [Phone]) VALUES (5, N'Caja Social', N'9856231245', N'Carrera 110 # 80-01', N'6545484')
INSERT [dbo].[Client] ([ClientId], [Name], [Identification], [Address], [Phone]) VALUES (6, N'FNA', N'8564231354', N'Diagonal 20 S # 12-21', N'5464564')
INSERT [dbo].[Client] ([ClientId], [Name], [Identification], [Address], [Phone]) VALUES (7, N'Colmena Seguros', N'3201506450', N'Carrera 95 # 73-20', N'9865431')
INSERT [dbo].[Client] ([ClientId], [Name], [Identification], [Address], [Phone]) VALUES (8, N'Marinesros SAS', N'9845121354', N'Av. Caracas # 30-12', N'6366451')
INSERT [dbo].[Client] ([ClientId], [Name], [Identification], [Address], [Phone]) VALUES (9, N'Mercado Zapatoca', N'9341527740', N'Carrera 60 # 04-01', N'7511214')
INSERT [dbo].[Client] ([ClientId], [Name], [Identification], [Address], [Phone]) VALUES (10, N'Hospital del sur', N'9564056407', N'Calle 50 Sur # 20-32', N'6455484')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (1, N'Portal Web', 1, CAST(N'2021-01-20' AS Date), CAST(N'2021-05-20' AS Date), 10000000, 640, 3)
INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (2, N'Nequi App', 1, CAST(N'2020-01-01' AS Date), CAST(N'2020-08-29' AS Date), 20000000, 800, 2)
INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (3, N'App Version', 2, CAST(N'2021-01-20' AS Date), CAST(N'2021-05-20' AS Date), 25000000, 400, 3)
INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (4, N'CRM', 2, CAST(N'2021-01-20' AS Date), CAST(N'2021-05-20' AS Date), 8000000, 651, 1)
INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (5, N'Portal Web', 3, CAST(N'2021-01-20' AS Date), CAST(N'2021-05-20' AS Date), 7000000, 214, 2)
INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (6, N'Portal Ventas', 3, CAST(N'2021-01-20' AS Date), CAST(N'2021-05-20' AS Date), 4000000, 40, 3)
INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (7, N'Carrito Compras', 4, CAST(N'2021-01-20' AS Date), CAST(N'2021-05-20' AS Date), 10000000, 652, 4)
INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (8, N'Camaras web', 4, CAST(N'2021-01-20' AS Date), CAST(N'2021-05-20' AS Date), 10000000, 215, 1)
INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (9, N'Portal proveedores', 5, CAST(N'2021-01-20' AS Date), CAST(N'2021-05-20' AS Date), 10000000, 42, 1)
INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (10, N'Portal Servicios', 5, CAST(N'2021-01-20' AS Date), CAST(N'2021-05-20' AS Date), 3200000, 512, 1)
INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (11, N'Mobile Music', 6, CAST(N'2021-01-20' AS Date), CAST(N'2021-05-20' AS Date), 50000000, 321, 2)
INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (12, N'Gestion proyectos', 6, CAST(N'2021-01-20' AS Date), CAST(N'2021-05-20' AS Date), 10000000, 230, 3)
INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (13, N'Contabilidad', 7, CAST(N'2021-01-20' AS Date), CAST(N'2021-05-20' AS Date), 14000000, 254, 4)
INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (14, N'Portal Seguros', 7, CAST(N'2021-01-20' AS Date), CAST(N'2021-05-20' AS Date), 7500000, 250, 3)
INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (15, N'Portal Web', 8, CAST(N'2021-01-20' AS Date), CAST(N'2021-05-20' AS Date), 35000000, 850, 2)
INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (16, N'Tiempos de trabajo', 8, CAST(N'2021-01-20' AS Date), CAST(N'2021-05-20' AS Date), 10000000, 990, 3)
INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (17, N'Portal Web', 9, CAST(N'2021-01-20' AS Date), CAST(N'2021-05-20' AS Date), 15000000, 784, 3)
INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (18, N'Stock', 9, CAST(N'2021-01-20' AS Date), CAST(N'2021-05-20' AS Date), 34000000, 450, 2)
INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (19, N'Portal Web', 10, CAST(N'2021-01-20' AS Date), CAST(N'2021-05-20' AS Date), 2000000, 640, 1)
INSERT [dbo].[Project] ([ProjectId], [Name], [ClientId], [StartDate], [EndDate], [Price], [TotalHours], [StatusId]) VALUES (20, N'Citas online', 10, CAST(N'2021-01-20' AS Date), CAST(N'2021-05-20' AS Date), 1000000, 154, 3)
SET IDENTITY_INSERT [dbo].[Project] OFF
GO
SET IDENTITY_INSERT [dbo].[Level] ON 

INSERT [dbo].[Level] ([LevelId], [Description]) VALUES (1, N'Alto')
INSERT [dbo].[Level] ([LevelId], [Description]) VALUES (2, N'Medio')
INSERT [dbo].[Level] ([LevelId], [Description]) VALUES (3, N'Bajo')
SET IDENTITY_INSERT [dbo].[Level] OFF
GO
SET IDENTITY_INSERT [dbo].[Language] ON 

INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (1, N'PHP', 1, 1)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (2, N'Javascript', 2, 1)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (3, N'Kotlin', 1, 1)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (4, N'.Net Core', 3, 2)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (5, N'Java', 2, 2)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (6, N'Java', 2, 3)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (7, N'.Net Core', 3, 3)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (8, N'Kotlin', 1, 3)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (9, N'PHP', 1, 4)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (10, N'Javascript', 2, 4)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (11, N'PHP', 1, 5)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (12, N'Javascript', 2, 5)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (13, N'PHP', 1, 6)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (14, N'Javascript', 2, 6)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (15, N'PHP', 1, 7)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (16, N'Javascript', 2, 7)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (17, N'PHP', 1, 8)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (18, N'Javascript', 2, 8)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (19, N'.Net Core', 3, 9)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (20, N'Java', 2, 9)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (21, N'.Net Core', 3, 10)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (22, N'Java', 2, 10)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (23, N'.Net Core', 3, 11)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (24, N'Java', 2, 11)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (25, N'.Net Core', 3, 12)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (26, N'Java', 2, 12)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (27, N'.Net Core', 3, 13)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (28, N'Kotlin', 1, 13)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (29, N'PHP', 1, 13)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (30, N'Java', 2, 14)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (31, N'PHP', 1, 15)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (32, N'C++', 3, 16)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (33, N'.Net', 1, 16)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (34, N'Javascript', 2, 17)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (35, N'Java', 2, 17)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (36, N'Javascript', 1, 18)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (37, N'PHP', 1, 18)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (38, N'Objective-C', 1, 19)
INSERT [dbo].[Language] ([LanguageId], [Description], [LevelId], [ProjectId]) VALUES (39, N'R', 1, 20)
SET IDENTITY_INSERT [dbo].[Language] OFF
GO
