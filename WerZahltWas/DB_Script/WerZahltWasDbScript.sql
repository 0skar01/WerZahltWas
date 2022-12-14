USE [master]
GO
/****** Object:  Database [WerZahltWas]    Script Date: 17.10.2022 15:00:28 ******/
CREATE DATABASE [WerZahltWas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'WerZahltWas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\WerZahltWas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WerZahltWas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\WerZahltWas_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [WerZahltWas] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WerZahltWas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WerZahltWas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WerZahltWas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WerZahltWas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WerZahltWas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WerZahltWas] SET ARITHABORT OFF 
GO
ALTER DATABASE [WerZahltWas] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WerZahltWas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WerZahltWas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WerZahltWas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WerZahltWas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WerZahltWas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WerZahltWas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WerZahltWas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WerZahltWas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WerZahltWas] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WerZahltWas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WerZahltWas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WerZahltWas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WerZahltWas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WerZahltWas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WerZahltWas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WerZahltWas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WerZahltWas] SET RECOVERY FULL 
GO
ALTER DATABASE [WerZahltWas] SET  MULTI_USER 
GO
ALTER DATABASE [WerZahltWas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WerZahltWas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [WerZahltWas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [WerZahltWas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [WerZahltWas] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [WerZahltWas] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'WerZahltWas', N'ON'
GO
ALTER DATABASE [WerZahltWas] SET QUERY_STORE = OFF
GO
USE [WerZahltWas]
GO
/****** Object:  Table [dbo].[BeguenstigstePersonen]    Script Date: 17.10.2022 15:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BeguenstigstePersonen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransaktionId] [int] NOT NULL,
	[BeguenstigtePersonId] [int] NOT NULL,
	[BetragAnteil] [float] NOT NULL,
 CONSTRAINT [PK__Beguenst__3214EC07C7D30100] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 17.10.2022 15:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Person__3214EC07C7708280] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaktionen]    Script Date: 17.10.2022 15:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaktionen](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Betrag] [float] NOT NULL,
	[BezahltePerson] [int] NOT NULL,
	[Bezeichnung] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Transakt__3214EC0760C1A9F3] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BeguenstigstePersonen]  WITH CHECK ADD  CONSTRAINT [FK_BeguenstigstePersonen_Person] FOREIGN KEY([BeguenstigtePersonId])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[BeguenstigstePersonen] CHECK CONSTRAINT [FK_BeguenstigstePersonen_Person]
GO
ALTER TABLE [dbo].[BeguenstigstePersonen]  WITH CHECK ADD  CONSTRAINT [FK_BeguenstigstePersonen_Transaktionen] FOREIGN KEY([TransaktionId])
REFERENCES [dbo].[Transaktionen] ([Id])
GO
ALTER TABLE [dbo].[BeguenstigstePersonen] CHECK CONSTRAINT [FK_BeguenstigstePersonen_Transaktionen]
GO
ALTER TABLE [dbo].[Transaktionen]  WITH CHECK ADD  CONSTRAINT [FK_BezahltePerson] FOREIGN KEY([BezahltePerson])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Transaktionen] CHECK CONSTRAINT [FK_BezahltePerson]
GO
/****** Object:  StoredProcedure [dbo].[Add_Transaction]    Script Date: 17.10.2022 15:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_Transaction]
	@bezahlte int,
	@beguenstigteList nvarchar(max),
	@betrag float,
	@bezeichnung nvarchar(50),
	@anzahlBeguenstigte int
AS
	Begin try

		declare @TransId [int]
		declare @anteil [float]
		insert into Transaktionen Values (@betrag, @bezahlte, @bezeichnung);
		SET @TransId = @@IDENTITY;
		SET @anteil = round(@betrag / (@anzahlBeguenstigte + 1),2);
		insert into BeguenstigstePersonen select @TransId, value, @anteil FROM STRING_SPLIT(@beguenstigteList, ';');
	end try
	begin catch
		select error_message()
	end catch
GO
/****** Object:  StoredProcedure [dbo].[Add_Transaction_With_Anteile]    Script Date: 17.10.2022 15:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_Transaction_With_Anteile]
	@bezahlte int,
	@beguenstigteList nvarchar(max),
	@betrag float,
	@betragAnteile nvarchar(max),
	@bezeichnung nvarchar(50),
	@anzahlBeguenstigte int
AS
	begin try
		declare @TransId [int]
		declare @anteil [float]
		insert into Transaktionen Values (@betrag, @bezahlte, @bezeichnung);
		SET @TransId = @@IDENTITY;
		create table beg ( Id int identity(1,1) primary key, beg int not null);
		create table anteil ( Id int identity(1,1) primary key, anteil float not null);
		insert into beg select value from string_split(@beguenstigteList, ';');
		insert into anteil select round(value, 2) from string_split(@betragAnteile, ';');

		declare @i int;
		set @i = 1;
		while @i <= @anzahlBeguenstigte
		begin
 
			insert into BeguenstigstePersonen values ( @TransId,
												(select beg from beg where Id = @i),
												(select round(anteil,2) from anteil where Id = @i))
			set @i = @i + 1;
		end;
		drop table anteil;
		drop table beg;
	end try
	begin catch
		select error_message()
	end catch
GO
/****** Object:  StoredProcedure [dbo].[Add_User]    Script Date: 17.10.2022 15:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Add_User]
	@name nvarchar(50)
AS
	Insert into Person Values (@name);
GO
/****** Object:  StoredProcedure [dbo].[GET_Transaction_Info]    Script Date: 17.10.2022 15:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_Transaction_Info]
	@transactionId int
	
AS

	select Concat(BetragAnteil, ' € an ', Person.Name) AS Schuld from BeguenstigstePersonen join Person on Person.Id = BeguenstigstePersonen.BeguenstigtePersonId where TransaktionId = @transactionId
GO
/****** Object:  StoredProcedure [dbo].[Get_Transactions]    Script Date: 17.10.2022 15:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Get_Transactions]
AS
select t.Id ,Concat( p1.Name ,' hat für ', t.Bezeichnung, ' ', t.Betrag, ' € bezahlt für',(
STUFF((select ', ' + p2.Name from BeguenstigstePersonen b join person p2 on p2.Id = b.BeguenstigtePersonId where b.TransaktionId = t.Id for XML PATH('')),1,1,'')
)) as Transactions from Transaktionen t  JOIN Person p1 ON t.BezahltePerson = p1.Id
GO
/****** Object:  StoredProcedure [dbo].[Get_User_Transactions]    Script Date: 17.10.2022 15:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Get_User_Transactions]
	@userId int
AS
	select t.Id ,Concat( p1.Name ,' hat für ', t.Bezeichnung, ' ', t.Betrag, ' € bezahlt für',(
	STUFF((select ', ' + p2.Name from BeguenstigstePersonen b join person p2 on p2.Id = b.BeguenstigtePersonId where b.TransaktionId = t.Id for XML PATH('')),1,1,'')
	)) as Transactions from Transaktionen t  JOIN Person p1 ON t.BezahltePerson = p1.Id where t.BezahltePerson = @userId
GO
/****** Object:  StoredProcedure [dbo].[Wer_Zahlt_Was_User]    Script Date: 17.10.2022 15:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Wer_Zahlt_Was_User]
@userId int
AS


drop table if EXISTS tmp
create table tmp(
Id int identity(1,1) primary key, Zahler nvarchar(50),
	Schuldner nvarchar(50), Betrag float)

insert into tmp select p2.Name,
	 p.Name ,
	 Sum(b.BetragAnteil)
from BeguenstigstePersonen b 
join Person p on p.Id = b.BeguenstigtePersonId 
join Transaktionen t on t.Id = b.TransaktionId 
join Person p2 on p2.Id = t.BezahltePerson
where t.BezahltePerson = @userId or b.BeguenstigtePersonId = @userId
group by p.Name, p2.Name
order by p.Name

declare @lastId int;
set @lastId = SCOPE_IDENTITY();

declare @i int = 1

drop table if EXISTS tmp2
create table tmp2 (
Id int identity(1,1) primary key, Zahler nvarchar(50), Schuldner nvarchar(50), Betrag float)

declare @dif float;

while @i <= @lastId
	begin
		
		set @dif = ((select round(Betrag, 2) from tmp
		where Zahler = (select Schuldner from tmp where Id = @i)
		and Schuldner = (select Zahler from tmp where Id = @i))
		-
		(select round(Betrag, 2) from tmp where Id = @i))
		if(@dif > 0)
				begin
					insert into tmp2 values((select Schuldner from tmp where Id = @i),
										(select Zahler from tmp where Id = @i), @dif)
					delete from tmp where Zahler = (select Schuldner from tmp where Id = @i)
										and Schuldner = (select Zahler from tmp where Id = @i)
				end
			else
				if(@dif < 0)
					begin
						insert into tmp2 values((select Zahler from tmp where Id = @i),
											(select Schuldner from tmp where Id = @i), @dif)
						delete from tmp where Zahler = (select Schuldner from tmp where Id = @i)
											and Schuldner = (select Zahler from tmp where Id = @i)
					end
				else
					if(@dif is null)
						begin
							insert into tmp2 values((select Zahler from tmp where Id = @i), (select Schuldner from tmp where Id = @i), (select Betrag from tmp where Id = @i))
						end

		set @i = @i + 1
		set @dif = 0
	end

set @i = 1;
set @lastId = SCOPE_IDENTITY()

drop table if EXISTS tmp3;
create table tmp3(
Id int identity(1,1) primary key, WerSchuldetWas nvarchar(max))

while @i <= @lastId
	begin
		if((select Betrag from tmp2 where Id = @i) > 0)
			begin
				insert into tmp3 values((select concat(Schuldner, ' schuldet ', Zahler, ' ', Betrag, ' €') 
				from tmp2 where Id = @i))
			end
		else
			if((select Betrag from tmp2 where Id = @i) < 0)
				begin
					insert into tmp3 values((select CONCAT(Schuldner, ' schuldet ', Zahler, ' ', (Betrag * -1), ' €')
					from tmp2 where Id = @i))
				end
		set @i = @i + 1
	end
select * from tmp3 order by WerSchuldetWas
drop table tmp3;
drop table tmp2;
drop table tmp;
GO
/****** Object:  StoredProcedure [dbo].[Wer_Zaht_Was]    Script Date: 17.10.2022 15:00:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Wer_Zaht_Was]

AS
	
drop table if EXISTS tmp
create table tmp(
Id int identity(1,1) primary key, Zahler nvarchar(50),
	Schuldner nvarchar(50), Betrag float)

insert into tmp select p2.Name,
	 p.Name ,
	 Sum(b.BetragAnteil)
from BeguenstigstePersonen b 
join Person p on p.Id = b.BeguenstigtePersonId 
join Transaktionen t on t.Id = b.TransaktionId 
join Person p2 on p2.Id = t.BezahltePerson
group by p.Name, p2.Name
order by p.Name

declare @lastId int;
set @lastId = SCOPE_IDENTITY();

declare @i int = 1


drop table if EXISTS tmp2
create table tmp2 (
Id int identity(1,1) primary key, Zahler nvarchar(50), Schuldner nvarchar(50), Betrag float)

declare @dif float;

while @i <= @lastId
	begin
		
		set @dif = ((select round(Betrag, 2) from tmp
		where Zahler = (select Schuldner from tmp where Id = @i)
		and Schuldner = (select Zahler from tmp where Id = @i))
		-
		(select round(Betrag, 2) from tmp where Id = @i))
		if (@dif is null)
			begin
				insert into tmp2 select Zahler, Schuldner, Betrag from tmp where Id = @i
			end
		else
			if(@dif > 0)
				begin
					insert into tmp2 values((select Schuldner from tmp where Id = @i),
										(select Zahler from tmp where Id = @i), @dif)
					delete from tmp where Zahler = (select Schuldner from tmp where Id = @i)
										and Schuldner = (select Zahler from tmp where Id = @i)
				end
			else
				if(@dif < 0)
					begin
						insert into tmp2 values((select Zahler from tmp where Id = @i),
											(select Schuldner from tmp where Id = @i), @dif)
						delete from tmp where Zahler = (select Schuldner from tmp where Id = @i)
											and Schuldner = (select Zahler from tmp where Id = @i)
					end

		set @i = @i + 1
		set @dif = 0
	end


set @i = 1;
set @lastId = SCOPE_IDENTITY()

drop table if EXISTS tmp3;
create table tmp3(
Id int identity(1,1) primary key, WerSchuldetWas nvarchar(max))

while @i <= @lastId
	begin
		if((select Betrag from tmp2 where Id = @i) > 0)
			begin
				insert into tmp3 values((select concat(Schuldner, ' schuldet ', Zahler, ' ', Betrag, ' €') 
				from tmp2 where Id = @i))
			end
		else
			if((select Betrag from tmp2 where Id = @i) < 0)
				begin
					insert into tmp3 values((select CONCAT(Schuldner, ' schuldet ', Zahler, ' ', (Betrag * -1), ' €')
					from tmp2 where Id = @i))
				end
		set @i = @i + 1
	end
select * from tmp3 order by WerSchuldetWas
drop table tmp3;
drop table tmp2;
drop table tmp;

GO
USE [master]
GO
ALTER DATABASE [WerZahltWas] SET  READ_WRITE 
GO
