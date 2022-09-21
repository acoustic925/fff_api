create database [fffdb];

drop table if exists [fffdb].[dbo].[data];
drop table if exists [fffdb].[dbo].[query_log_action];
drop table if exists [fffdb].[dbo].[service_log_action];

create table [fffdb].[dbo].[data] (
	[id] [int] identity (1,1) not null,
	[code] [int],
	[value] [varchar](300),
	constraint [pk_data_id] primary key clustered ([id])
);

create table [fffdb].[dbo].[query_log_action] (
	[id] [int] identity(1,1) not null,
	[action_date] [datetime],
	[action] [varchar](max),
	[user_ip] [varchar](255),
	constraint [pk_query_log_action_id] primary key clustered ([id])
);

create table [fffdb].[dbo].[service_log_action] (
	[id] [int] identity(1,1) not null,
	[action_date] [datetime],
	[action] [varchar](max),
	[user_ip] [varchar](255),
	constraint [pk_service_log_action_id] primary key clustered ([id])
);


