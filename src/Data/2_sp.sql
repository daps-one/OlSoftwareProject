USE [Projects]
GO
/****** Object:  StoredProcedure [dbo].[GetProjectsClient]    Script Date: 5/02/2022 4:26:45 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetProjectsClient]
	@ClientId INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		C.ClientId, 
		C.Name, 
		C.Identification, 
		C.Address, 
		C.Phone
	FROM Client C
	WHERE C.ClientId = @ClientId;

	SELECT 
		P.ProjectId, 
		P.Name AS ProjectName, 
		P.StartDate, 
		P.EndDate, 
		P.Price, 
		P.TotalHours, 
		S.Description AS Status, 
		L.LanguageId, 
		L.Description AS Language,
		LV.LevelId,
		LV.Description AS Level
	FROM Project P
	JOIN Status S ON S.StatusId = P.StatusId
	JOIN Language L ON L.ProjectId = P.ProjectId
	JOIN Level LV ON LV.LevelId = L.LevelId
	WHERE P.ClientId = @ClientId;
END
GO
