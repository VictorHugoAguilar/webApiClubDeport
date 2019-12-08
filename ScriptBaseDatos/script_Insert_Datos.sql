-- /******************** DEPORTES ***********************/
USE [WebApiClubDeportivo]
SET IDENTITY_INSERT [Deportes] ON
GO

INSERT INTO [dbo].[Deportes]
      ([Nombre]
      ,[Id])
VALUES
      ('Futbol', 1)
GO
INSERT INTO [dbo].[Deportes]
      ([Nombre]
      ,[Id])
VALUES
      ('Pelota vasca', 2)
GO
INSERT INTO [dbo].[Deportes]
      ([Nombre]
      ,[Id])
VALUES
      ('Padel', 3)
GO
INSERT INTO [dbo].[Deportes]
      ([Nombre]
      ,[Id])
VALUES
      ('Tenis', 4)
GO
INSERT INTO [dbo].[Deportes]
      ([Nombre]
      ,[Id])
VALUES
      ('Basquetbol', 5)
GO
INSERT INTO [dbo].[Deportes]
      ([Nombre]
      ,[Id])
VALUES
      ('Voleibol', 6)
GO
INSERT INTO [dbo].[Deportes]
      ([Nombre]
      ,[Id])
VALUES
      ('Balonmano', 7)
GO
INSERT INTO [dbo].[Deportes]
      ([Nombre]
      ,[Id])
VALUES
      ('Badminton', 8)
GO
INSERT INTO [dbo].[Deportes]
      ([Nombre]
      ,[Id])
VALUES
      ('Hockey sobre patines', 9)
GO
INSERT INTO [dbo].[Deportes]
      ([Nombre]
      ,[Id])
VALUES
      ('Hockey sobre cesped', 10)
GO
INSERT INTO [dbo].[Deportes]
      ([Nombre]
      ,[Id])
VALUES
      ('Atletismo', 11)
GO
INSERT INTO [dbo].[Deportes]
      ([Nombre]
      ,[Id])
VALUES
      ('Boxeo', 12)
GO
INSERT INTO [dbo].[Deportes]
      ([Nombre]
      ,[Id])
VALUES
      ('Ping pong', 13)
GO
INSERT INTO [dbo].[Deportes]
      ([Nombre]
      ,[Id])
VALUES
      ('Rugby', 14)
GO
INSERT INTO [dbo].[Deportes]
      ([Nombre]
      ,[Id])
VALUES
      ('Beisbol', 15)
GO

SET IDENTITY_INSERT [Deportes] OFF
GO

-- /********************** PISTAS *****************************/
-- /*** Futbol ***/

USE [WebApiClubDeportivo]
SET IDENTITY_INSERT [Pistas] ON
GO

INSERT INTO [dbo].[Pistas]
      ([Numero]
      ,[Descripcion]
      ,[Localizacion]
      ,[DeporteId]
      ,[Id])
VALUES
      ('F1', 'Futbol 5 techada' , 'San juan' , 1 , 1 )
GO
INSERT INTO [dbo].[Pistas]
      ([Numero]
      ,[Descripcion]
      ,[Localizacion]
      ,[DeporteId]
      ,[Id])
VALUES
      ('F2', 'Futbol 5 techada', 'Muchamiel', 1, 2)
GO
INSERT INTO [dbo].[Pistas]
      ([Numero]
      ,[Descripcion]
      ,[Localizacion]
      ,[DeporteId]
      ,[Id])
VALUES
      ('F3', 'Futbol 5 sin techar', 'Muchamiel', 1, 3)
GO
INSERT INTO [dbo].[Pistas]
      ([Numero]
      ,[Descripcion]
      ,[Localizacion]
      ,[DeporteId]
      ,[Id])
VALUES
      ('F4', 'Futbol 5 sin techar', 'Campello', 1, 4)
GO
INSERT INTO [dbo].[Pistas]
      ([Numero]
      ,[Descripcion]
      ,[Localizacion]
      ,[DeporteId]
      ,[Id])
VALUES
      ('F5', 'Futbol 5 sin techar', 'Campello', 1, 5)
GO

-- pelota Vasca 
INSERT INTO [dbo].[Pistas]
      ([Numero]
      ,[Descripcion]
      ,[Localizacion]
      ,[DeporteId]
      ,[Id])
VALUES
      ('PV1', 'Fronton de 30 metros', 'Campello', 2, 6)
GO
INSERT INTO [dbo].[Pistas]
      ([Numero]
      ,[Descripcion]
      ,[Localizacion]
      ,[DeporteId]
      ,[Id])
VALUES
      ('PV2', 'Fronton de 30 metros', 'San juan', 2, 7)
GO
INSERT INTO [dbo].[Pistas]
      ([Numero]
      ,[Descripcion]
      ,[Localizacion]
      ,[DeporteId]
      ,[Id])
VALUES
      ('PV3', 'Fronton de 36 metros', 'San juan', 2, 8)
GO
INSERT INTO [dbo].[Pistas]
      ([Numero]
      ,[Descripcion]
      ,[Localizacion]
      ,[DeporteId]
      ,[Id])
VALUES
      ('PV4', 'Fronton de 54 metros', 'San juan', 2, 9)
GO

-- /** Padel **/
INSERT INTO [dbo].[Pistas]
      ([Numero]
      ,[Descripcion]
      ,[Localizacion]
      ,[DeporteId]
      ,[Id])
VALUES
      ('PAD1', 'Pista de hormigon poroso', 'Muchamiel', 3, 10)
GO
INSERT INTO [dbo].[Pistas]
      ([Numero]
      ,[Descripcion]
      ,[Localizacion]
      ,[DeporteId]
      ,[Id])
VALUES
      ('PAD2', 'Pista de resina sintetica', 'Muchamiel', 3, 11)
GO
INSERT INTO [dbo].[Pistas]
      ([Numero]
      ,[Descripcion]
      ,[Localizacion]
      ,[DeporteId]
      ,[Id])
VALUES
      ('PAD3', 'Pista de resina sintetica', 'San Juan', 3, 12 )
GO
INSERT INTO [dbo].[Pistas]
      ([Numero]
      ,[Descripcion]
      ,[Localizacion]
      ,[DeporteId]
      ,[Id])
VALUES
      ('PAD4', 'Pista de hormigon poroso', 'San Juan', 3, 13)
GO

-- /** Tenis **/
INSERT INTO [dbo].[Pistas]
      ([Numero]
      ,[Descripcion]
      ,[Localizacion]
      ,[DeporteId]
      ,[Id])
VALUES
      ('T1', 'Pista de cesped', 'Campello', 3, 14)
GO
INSERT INTO [dbo].[Pistas]
      ([Numero]
      ,[Descripcion]
      ,[Localizacion]
      ,[DeporteId]
      ,[Id])
VALUES
      ('T2', 'Pista de arcilla', 'Campello', 3, 15)
GO

-- /** Basquet**/
INSERT INTO [dbo].[Pistas]
      ([Numero]
      ,[Descripcion]
      ,[Localizacion]
      ,[DeporteId]
      ,[Id])
VALUES
      ('BAS1', 'Pista techada', 'Muchamiel', 5 , 16)
GO
INSERT INTO [dbo].[Pistas]
      ([Numero]
      ,[Descripcion]
      ,[Localizacion]
      ,[DeporteId]
      ,[Id])
VALUES
      ('BAS2', 'Pista techada', 'Muchamiel', 7, 17)
GO

-- /**Badminton**/
INSERT INTO [dbo].[Pistas]
      ([Numero]
      ,[Descripcion]
      ,[Localizacion]
      ,[DeporteId]
      ,[Id])
VALUES
      ('BAD1', 'Pista sin techar', 'Campello', 8 , 18)
GO

SET IDENTITY_INSERT [Pistas] OFF
GO

-- /************************** SOCIOS *********************/

USE [WebApiClubDeportivo]
SET IDENTITY_INSERT [Socios] ON
GO

INSERT INTO [dbo].[Socios]
      ([Nombre]
      ,[Apellido]
      ,[Telefono]
      ,[Mail]
      ,[Baja]
      ,[Id])
VALUES
      ('ANTONIO MANUEL'
           , 'PAZ VENTURA'
           , 676170896
           , 'xd4egr72cp@netscape.net'
           , 0
		   , 1)
GO
INSERT INTO [dbo].[Socios]
      ([Nombre]
      ,[Apellido]
      ,[Telefono]
      ,[Mail]
      ,[Baja]
      ,[Id])
VALUES
      ('BERNARDO'
           , 'LORENZO ROJO'
           , 693951891
           , 'j88skhk4zi@yahoo.com'
           , 1
		   , 2)
GO
INSERT INTO [dbo].[Socios]
      ([Nombre]
      ,[Apellido]
      ,[Telefono]
      ,[Mail]
      ,[Baja]
      ,[Id])
VALUES
      ('ESTER'
           , 'VALLS OLIVER'
           , 673546409
           , 'gt37usmg3@earthling.net'
           , 0
		   , 3)
GO
INSERT INTO [dbo].[Socios]
      ([Nombre]
      ,[Apellido]
      ,[Telefono]
      ,[Mail]
      ,[Baja]
      ,[Id])
VALUES
      ('JUAN PABLO'
           , 'PONCE GUILLEN'
           , 675367469
           , '74sde3mqv@caramail.com'
           , 0
		   , 4)
GO
INSERT INTO [dbo].[Socios]
      ([Nombre]
      ,[Apellido]
      ,[Telefono]
      ,[Mail]
      ,[Baja]
      ,[Id])
VALUES
      ('ANGEL'
           , 'ARANDA MATA'
           , 765628491
           , 'rq9an2s16@journalism.com'
           , 0
		   , 5)
GO
INSERT INTO [dbo].[Socios]
      ([Nombre]
      ,[Apellido]
      ,[Telefono]
      ,[Mail]
      ,[Baja]
      ,[Id])
VALUES
      ('CANDIDO'
           , 'DEL VALLE MUÑIZ'
           , 747806900
           , 'd6dt7fqyf@lycos.it'
           , 1
		   , 6)
GO
INSERT INTO [dbo].[Socios]
      ([Nombre]
      ,[Apellido]
      ,[Telefono]
      ,[Mail]
      ,[Baja]
      ,[Id])
VALUES
      ('JAIME'
           , 'FUENTES BARRIOS'
           , 794420628
           , 'wo2p5a5zb4@lycos.co.uk'
           , 0
		   , 7)
GO
INSERT INTO [dbo].[Socios]
      ([Nombre]
      ,[Apellido]
      ,[Telefono]
      ,[Mail]
      ,[Baja]
      ,[Id])
VALUES
      ('ITZIAR'
           , 'CORDERO ALARCON'
           , 710708770
           , 'bc6lzh209@journalism.com'
           , 0
		   , 8)
GO
INSERT INTO [dbo].[Socios]
      ([Nombre]
      ,[Apellido]
      ,[Telefono]
      ,[Mail]
      ,[Baja]
      ,[Id])
VALUES
      ('RAUL'
           , 'AGUILERA SILVA'
           , 710708770
           , 'frmykl4ta@caramail.com'
           , 0
		   , 9)
GO
INSERT INTO [dbo].[Socios]
      ([Nombre]
      ,[Apellido]
      ,[Telefono]
      ,[Mail]
      ,[Baja]
      ,[Id])
VALUES
      ('MARIA GLORIA'
           , 'LLAMAS BRITO'
           , 658421244
           , '9rlv9ksi4u@usa.com'
           , 1
		   , 10)
GO
INSERT INTO [dbo].[Socios]
      ([Nombre]
      ,[Apellido]
      ,[Telefono]
      ,[Mail]
      ,[Baja]
      ,[Id])
VALUES
      ('MARIA REMEDIOS'
           , 'JUAREZ MARTOS'
           , 680473780
           , 'jw6ryxxi9@blu.it'
           , 0
		   , 11)
GO
INSERT INTO [dbo].[Socios]
      ([Nombre]
      ,[Apellido]
      ,[Telefono]
      ,[Mail]
      ,[Baja]
      ,[Id])
VALUES
      ('BRUNO'
           , 'JURADO VERA'
           , 636827943
           , '033twali@lycos.nl'
           , 0
		   , 12)
GO
INSERT INTO [dbo].[Socios]
      ([Nombre]
      ,[Apellido]
      ,[Telefono]
      ,[Mail]
      ,[Baja]
      ,[Id])
VALUES
      ('ERIK'
           , 'ESPEJO ALFARO'
           , 798133067
           , '2cag5srw38@unforgettable.com'
           , 0
		   , 13)
GO
INSERT INTO [dbo].[Socios]
      ([Nombre]
      ,[Apellido]
      ,[Telefono]
      ,[Mail]
      ,[Baja]
      ,[Id])
VALUES
      ('CRISTOBAL'
           , 'FERREIRA CANOVAS'
           , 712735975
           , 'jifnc2qnn@aol.com'
           , 0
		   , 14)
GO
INSERT INTO [dbo].[Socios]
      ([Nombre]
      ,[Apellido]
      ,[Telefono]
      ,[Mail]
      ,[Baja]
      ,[Id])
VALUES
      ('VICTORIANO'
           , 'PAZOS MAS'
           , 623220744
           , '044f8cbuut@whoever.com'
           , 0
		   , 15)
GO

INSERT INTO [dbo].[Socios]
      ([Nombre]
      ,[Apellido]
      ,[Telefono]
      ,[Mail]
      ,[Baja]
      ,[Id])
VALUES
      ('EVA'
           , 'VILLA VARELA'
           , 745994377
           , 'dnxe2bxo3u@journalism.com'
           , 0
		   , 16)
GO
INSERT INTO [dbo].[Socios]
      ([Nombre]
      ,[Apellido]
      ,[Telefono]
      ,[Mail]
      ,[Baja]
      ,[Id])
VALUES
      ('ARANZAZU'
           , 'HERNANDEZ BONILLA'
           , 711770962
           , 's5mmbzbd@blu.it'
           , 0
		   , 17)
GO

INSERT INTO [dbo].[Socios]
      ([Nombre]
      ,[Apellido]
      ,[Telefono]
      ,[Mail]
      ,[Baja]
      ,[Id])
VALUES
      ('SAUL'
           , 'PIÑERO SOSA'
           , 711770962
           , 'fjdozoijc@post.com'
           , 0
		   , 18)
GO

SET IDENTITY_INSERT [Socios] OFF
GO
-- /************************ RESERVAS *********************/

USE [WebApiClubDeportivo]
SET IDENTITY_INSERT [Reservas] OFF
GO

INSERT INTO [dbo].[Reservas]
           ([Fecha], [Hora], [SocioId], [PistaId])
     VALUES
           ('09-12-2019' , 8   , 8  , 1 )
GO
INSERT INTO [dbo].[Reservas]
           ([Fecha], [Hora], [SocioId], [PistaId])
     VALUES
           ('09-12-2019' , 9   , 2  , 1 )
GO
INSERT INTO [dbo].[Reservas]
           ([Fecha], [Hora], [SocioId], [PistaId])
     VALUES
           ('09-12-2019' , 10   , 3  , 1 )
GO
INSERT INTO [dbo].[Reservas]
           ([Fecha], [Hora], [SocioId], [PistaId])
     VALUES
           ('10-12-2019' , 8   , 1  , 10 )
GO
INSERT INTO [dbo].[Reservas]
           ([Fecha], [Hora], [SocioId], [PistaId])
     VALUES
           ('10-12-2019' , 8   , 6  , 10 )
GO
INSERT INTO [dbo].[Reservas]
           ([Fecha], [Hora], [SocioId], [PistaId])
     VALUES
           ('10-12-2019' , 9   , 6  , 10 )
GO
INSERT INTO [dbo].[Reservas]
           ([Fecha], [Hora], [SocioId], [PistaId])
     VALUES
           ('09-12-2019' , 16   , 12  , 14 )
GO
INSERT INTO [dbo].[Reservas]
           ([Fecha], [Hora], [SocioId], [PistaId])
     VALUES
           ('09-12-2019' ,  14 , 13  , 14 )
GO
INSERT INTO [dbo].[Reservas]
           ([Fecha], [Hora], [SocioId], [PistaId])
     VALUES
           ('11-12-2019' , 12   , 6  , 4 )
GO
INSERT INTO [dbo].[Reservas]
           ([Fecha], [Hora], [SocioId], [PistaId])
     VALUES
           ('11-12-2019' , 17 , 5  , 1 )
GO
INSERT INTO [dbo].[Reservas]
           ([Fecha], [Hora], [SocioId], [PistaId])
     VALUES
           ('11-12-2019' , 13   , 7  , 3 )
GO
INSERT INTO [dbo].[Reservas]
           ([Fecha], [Hora], [SocioId], [PistaId])
     VALUES
           ('12-12-2019' , 5   , 8  , 1 )
GO
INSERT INTO [dbo].[Reservas]
           ([Fecha], [Hora], [SocioId], [PistaId])
     VALUES
           ('12-12-2019' , 16   , 9  , 4 )
GO
INSERT INTO [dbo].[Reservas]
           ([Fecha], [Hora], [SocioId], [PistaId])
     VALUES
           ('12-12-2019' , 15   , 15  , 10 )
GO
INSERT INTO [dbo].[Reservas]
           ([Fecha], [Hora], [SocioId], [PistaId])
     VALUES
           ('12-12-2019' , 14   , 12  , 10 )
GO
INSERT INTO [dbo].[Reservas]
           ([Fecha], [Hora], [SocioId], [PistaId])
     VALUES
           ('13-12-2019' , 11   , 13 , 10 )
GO

SET IDENTITY_INSERT [Reservas] OFF
GO











