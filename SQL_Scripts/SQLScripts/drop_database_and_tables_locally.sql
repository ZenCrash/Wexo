/* DROP TABLES */

USE [WEXO_Greet_Me]
GO

--DROP FK's

	--DROP MEETINGS_PEOPLE
ALTER TABLE [dbo].[meetings_people] DROP CONSTRAINT [FK_meetings_people_people_id]
GO
ALTER TABLE [dbo].[meetings_people] DROP CONSTRAINT [FK_meetings_people_meetings_id]
GO

	--DROP MEETINGS
ALTER TABLE [dbo].[meetings] DROP CONSTRAINT [FK_meetings_meeting_rooms_id]
GO

	--DROP MEETING_ROOMS
ALTER TABLE [dbo].[meeting_rooms] DROP CONSTRAINT [FK_meeting_rooms_company_addresses_id]
GO

	--DROP SERVICES
ALTER TABLE [dbo].[services] DROP CONSTRAINT [FK_services_people_id]
GO

	--DROP EMPLOYEES
ALTER TABLE [dbo].[employees] DROP CONSTRAINT [FK_employees_company_addresses_id]
GO
ALTER TABLE [dbo].[employees] DROP CONSTRAINT [FK_employees_people_id]
GO

	--DROP CUSTOMERS
ALTER TABLE [dbo].[customers] DROP CONSTRAINT [FK_customers_people_id]
GO

	--DROP LOGINS
ALTER TABLE [dbo].[logins] DROP CONSTRAINT [FK_logins_people_id]
GO

	--DROP PEOPLE
	--DROP COMPANY_ADDRESSES

--DROP TABLES
DROP TABLE [dbo].[meetings_people]
GO
DROP TABLE [dbo].[meetings]
GO
DROP TABLE [dbo].[services]
GO
DROP TABLE [dbo].[employees]
GO
DROP TABLE [dbo].[employees]
GO
DROP TABLE [dbo].[customers]
GO
DROP TABLE [dbo].[logins]
GO
DROP TABLE [dbo].[people]
GO
DROP TABLE [dbo].[company_addresses]
GO

/* DROP WEXO_GREET_ME DATABASE */
DROP DATABASE [WEXO_Greet_Me];
GO