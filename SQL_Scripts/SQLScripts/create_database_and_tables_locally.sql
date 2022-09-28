/* CREATE WEXO_GREET_ME DATABASE */

CREATE DATABASE [WEXO_GREET_ME]
GO

/* CREATE TABELS dd */

USE [WEXO_GREET_ME]
GO

CREATE TABLE [dbo].[company_addresses](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[street_name] [nvarchar](50) NOT NULL,
	[street_number] [int] NOT NULL,
	[apartment_number] [nvarchar](10) NULL,
	[zipcode] [int] NOT NULL,
	[city] [nvarchar] NOT NULL
	)
GO

CREATE TABLE [dbo].[people](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[job_title] [nvarchar](50) NOT NULL,
	[work_email] [nvarchar](128) NOT NULL,
	[work_phone_number] [int] NULL
	)
GO

CREATE TABLE [dbo].[logins](
	[person_id] [int] PRIMARY KEY NOT NULL, --FK relation to person_id
	[username] [nvarchar](50) NOT NULL,
	[hashed_password] [varchar](128) NOT NULL,
	[salt] [varchar](128) NOT NULL,

	--FK relations
	CONSTRAINT [FK_people_id] FOREIGN KEY (person_id) REFERENCES people (id) ON DELETE CASCADE
	)
GO

CREATE TABLE [dbo].[customers](
	[person_id] [int] PRIMARY KEY NOT NULL, --FK relation to person_id
	[company_name] [nvarchar](50) NULL,

	--FK relations
	CONSTRAINT [FK_people_id] FOREIGN KEY (person_id) REFERENCES people (id) ON DELETE CASCADE
	)
GO

CREATE TABLE [dbo].[employees](
	[person_id] [int] PRIMARY KEY NOT NULL, --FK relation to person_id
	[nickname] [nvarchar](50) NULL,
	[role] [nvarchar](50) NOT NULL,
	[date_of_birth] [datetime] NOT NULL,
	[hiring_date] [datetime] NOT NULL,
	[company_address_id] [int] NOT NULL, --FK relation to company_address_id

	--FK relations
	CONSTRAINT [FK_people_id] FOREIGN KEY (person_id) REFERENCES people (id) ON DELETE CASCADE,
	CONSTRAINT [FK_company_addresses_id] FOREIGN KEY (company_address_id) REFERENCES company_addresses (id)
	)
GO

CREATE TABLE [dbo].[meeting_rooms](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[room_name] [nvarchar](50) NOT NULL,
	[decription] [nvarchar](560) NOT NULL,
	[capacity] [int] NOT NULL,
	[company_address_id] [int] NOT NULL, --FK relation to company_address_id

	--FK relations
	CONSTRAINT [FK_company_addresses_id] FOREIGN KEY (company_address_id) REFERENCES company_addresses (id) ON DELETE CASCADE
	)
GO

CREATE TABLE [dbo].[meetings](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[meeting_code] [varchar](4) NOT NULL,
	[meeting_title] [nvarchar](50) NOT NULL,
	[start_date_time] [datetime] NOT NULL,
	[end_date_time] [datetime] NOT NULL,
	[status] [nvarchar](50) NOT NULL,
	[decription] [nvarchar](560) NULL,
	[preparation_decription] [nvarchar](560) NULL,
	[meeting_room_id] [int] NULL, --FK relation to meeting_room_id

	--FK relations
	CONSTRAINT [FK_meeting_rooms_id] FOREIGN KEY (meeting_room_id) REFERENCES meeting_rooms (id)
	)
GO

	-- Meeting_people (Bridge Table)
CREATE TABLE [dbo].[meetings_people](
	[meeting_id] [int] NOT NULL,
	[person_id] [int] NOT NULL,

	CONSTRAINT [FK_meetings_id] FOREIGN KEY (meeting_id) REFERENCES meetings (id) ON DELETE CASCADE,
	CONSTRAINT [FK_people_id] FOREIGN KEY (person_id) REFERENCES people (id) ON DELETE CASCADE
	)
GO