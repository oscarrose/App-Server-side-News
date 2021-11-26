--craate the database
create database News;
go
use News;
go

--create the table---------------
create table source
(
idSource int not null identity constraint  pk_idSource primary key(idSource),
Namesource varchar(50)
);
go
create table category
(
idCategory int not null identity(1,1) constraint pk_idCategory primary key,
Namecategory varchar(50) not null
);
go

create table country
(
codeCountry varchar(2) not null constraint PK_codeCountry primary key,
Namecountry varchar(100) not null
);
go

create table article
(
idAritcle int not null identity constraint pk_idArticle primary key,
IDsource int not null constraint Fk_article_source_idSource foreign key references source(idSource),
IDcategory int not null constraint FK_article_category_idCategory foreign key references category(idCategory),
IDcountry varchar(2) not null constraint FK_article_country_codeCountry foreign key references country(codeCountry),
title varchar (max),
description varchar (max),
imageUrl varchar(max),
articleUrl varchar(max),
dateCreate datetime not null default GetDate(),
publicationDate date not null,
author varchar(max),
visible bit not null default 0
);
go
--inserting the first data

insert into category(Namecategory)
		values('entertainment'),
				('technology')
go

insert into country(codeCountry,Namecountry)
			values('us','united states'),
					('nz','new zealand')
go

insert into source(Namesource)
			values('BBC News'),
				('t-online.de')
go


insert into article(IDsource,IDcategory,IDcountry,title,description,imageUrl,articleUrl,dateCreate,
publicationDate,author,visible)values(1,2,'us','Apple announces self-service repair scheme in win for campaigners',
'Apple has announced a "self-service repair" programme so "customers who are comfortable" can fix their own devices.
At launch, in early 2022 in the US, it will cover replacing the batteries, screens and cameras of recent iPhones.',
'https://ichef.bbci.co.uk/news/976/cpsprodpb/772D/production/_121590503_gettyimages-1235543028.jpg',
'https://www.bbc.com/news/technology-59322349',GETDATE(),'11/17/2021','BBC',0);


insert into article(IDsource,IDcategory,IDcountry,title,description,imageUrl,articleUrl,dateCreate,
publicationDate,author,visible)values(13,1,'us','Premios Grammy 2022: estos son los nominados a las principales categorías',
'La Academia Nacional de Artes y Ciencias de la Grabación dio a conocer este martes los nominados a la edición 
64 de los premios Grammy, cuya ceremonia se llevará a cabo el lunes 31 de enero de 2022.
En total, se presentaron nominaciones par 86 categorías, de las cuales dos son nuevas:
mejor actuación musical global y mejor álbum de música urbana latina.','https://quetalvirtual.com/upload/grammy%202022.jpg',
'https://cnnespanol.cnn.com/2021/11/23/premios-grammy-nominados-2022-orix/',GETDATE(),'11/23/2021',
'CNN Español',1);

insert into article(IDsource,IDcategory,IDcountry,title,description,imageUrl,articleUrl,dateCreate,
publicationDate,author,visible)values(13,2,'us','¿Cómo podrán los astronautas protegerse de la radiación en Marte?',
'Cuando en un futuro el hombre llegue a Marte, ¿cómo podrá refugiarse de la fuerte radiación? El vehículo 
explorador de la NASA, Curiosity, está ayudando a resolver este desafío.','https://cnnespanol.cnn.com/wp-content/uploads/2021/11/191104125247-mars-rover-curiosity-1101-full-169.jpg?quality=100&strip=info&w=780&h=438&crop=1',
'https://cnnespanol.cnn.com/video/marte-radiacion-nasa-astronautas-supervivencia-extraterrestre-investigacion-curiosity-encuentro-cnn/','10/23/2021','11/23/2021',
'Rebeca Pérez Arocho',1);
go
select * from article
select * from country
select * from source
select * from category

insert [dbo].[country]([codeCountry], [Namecountry])values('ar', 'Argentina')
insert [dbo].[country]([codeCountry], [Namecountry])values('au', 'Australia')
insert [dbo].[country]([codeCountry], [Namecountry])values('at', 'Austria')
insert [dbo].[country]([codeCountry], [Namecountry])values('be', 'Belgium')
insert [dbo].[country]([codeCountry], [Namecountry])values('br', 'Brazil')
insert [dbo].[country]([codeCountry], [Namecountry])values('bg', 'Bulgaria')
insert [dbo].[country]([codeCountry], [Namecountry])values('ca', 'Cánada')
insert [dbo].[country]([codeCountry], [Namecountry])values('cn', 'China')
insert [dbo].[country]([codeCountry], [Namecountry])values('co', 'Colombia')
insert [dbo].[country]([codeCountry], [Namecountry])values('cu','Cuba')
insert [dbo].[country]([codeCountry], [Namecountry])values('cz','Czech Republic')
insert [dbo].[country]([codeCountry], [Namecountry])values('eg','Egypt')
insert [dbo].[country]([codeCountry], [Namecountry])values('fr','France')
insert [dbo].[country]([codeCountry], [Namecountry])values('de', 'Germany')
insert [dbo].[country]([codeCountry], [Namecountry])values('gr', 'Greece')
insert [dbo].[country]([codeCountry], [Namecountry])values('hk', 'Hong Kong')
insert [dbo].[country]([codeCountry], [Namecountry])values('hu', 'Hungary')
insert [dbo].[country]([codeCountry], [Namecountry])values('in', 'India')
insert [dbo].[country]([codeCountry], [Namecountry])values('id', 'Indonesia')
insert [dbo].[country]([codeCountry], [Namecountry])values('ie', 'Ireland')
insert [dbo].[country]([codeCountry], [Namecountry])values('il', 'Israel')
insert [dbo].[country]([codeCountry], [Namecountry])values('it', 'Italy')
insert [dbo].[country]([codeCountry], [Namecountry])values('jp', 'Japan')
insert [dbo].[country]([codeCountry], [Namecountry])values('lv', 'Latvia')
insert [dbo].[country]([codeCountry], [Namecountry])values('lt', 'Lithuania')
insert [dbo].[country]([codeCountry], [Namecountry])values('my', 'Malaysia')
insert [dbo].[country]([codeCountry], [Namecountry])values('mx', 'Mexico')
insert [dbo].[country]([codeCountry], [Namecountry])values('ma', 'Morocco')
insert [dbo].[country]([codeCountry], [Namecountry])values('nl', 'Netherlands')
insert [dbo].[country]([codeCountry], [Namecountry])values('nz', 'New Zealand')
insert [dbo].[country]([codeCountry], [Namecountry])values('ng', 'Nigeria')
insert [dbo].[country]([codeCountry], [Namecountry])values('no', 'Norway')
insert [dbo].[country]([codeCountry], [Namecountry])values('ph', 'Philippines')
insert [dbo].[country]([codeCountry], [Namecountry])values('pl', 'Poland')
insert [dbo].[country]([codeCountry], [Namecountry])values('pt', 'Portugal')
insert [dbo].[country]([codeCountry], [Namecountry])values('ro', 'Romania')
insert [dbo].[country]([codeCountry], [Namecountry])values('ru', 'Russian Federation')
insert [dbo].[country]([codeCountry], [Namecountry])values('sa', 'Saudi Arabia')
insert [dbo].[country]([codeCountry], [Namecountry])values('rs', 'Serbia')
insert [dbo].[country]([codeCountry], [Namecountry])values('sg', 'Singapore')
insert [dbo].[country]([codeCountry], [Namecountry])values('sk', 'Slovakia')
insert [dbo].[country]([codeCountry], [Namecountry])values('si', 'Slovenia')
insert [dbo].[country]([codeCountry], [Namecountry])values('za', 'South Africa')
insert [dbo].[country]([codeCountry], [Namecountry])values('kp', 'North Korea')
insert [dbo].[country]([codeCountry], [Namecountry])values('se', 'Sweden')
insert [dbo].[country]([codeCountry], [Namecountry])values('ch', 'Switzerland')
insert [dbo].[country]([codeCountry], [Namecountry])values('tw', 'Taiwan')
insert [dbo].[country]([codeCountry], [Namecountry])values('th', 'Thailand')
insert [dbo].[country]([codeCountry], [Namecountry])values('tr', 'Turkey')
insert [dbo].[country]([codeCountry], [Namecountry])values('ua', 'Ukraine')
insert [dbo].[country]([codeCountry], [Namecountry])values('ae', 'United Arab Emirates')
insert [dbo].[country]([codeCountry], [Namecountry])values('gb', 'United Kingdom ')
insert [dbo].[country]([codeCountry], [Namecountry])values('us', 'United States of America')
insert [dbo].[country]([codeCountry], [Namecountry])values('ve', 'Venezuela')
go



insert [dbo].[category] ( [Namecategory]) values ('Business')
insert [dbo].[category] ( [Namecategory]) values ('General')
insert [dbo].[category] ( [Namecategory]) values ('Health')
insert [dbo].[category] ( [Namecategory]) values ('Science')
insert [dbo].[category] ( [Namecategory]) values ('Sports')
insert [dbo].[category] ( [Namecategory]) values ('Policy')
go


insert [dbo].[source] ([Namesource]) values ('TechCrunch')
insert [dbo].[source] ([Namesource]) values ('Mashable')
insert [dbo].[source] ([Namesource]) values ('The Verge')
insert [dbo].[source] ([Namesource]) values ('Reuters')
insert [dbo].[source] ([Namesource]) values ('MarketBeat')
insert [dbo].[source] ([Namesource]) values ('ESPN')
insert [dbo].[source] ([Namesource]) values ('New York Post')
insert [dbo].[source] ([Namesource]) values ('CNBC')
insert [dbo].[source] ([Namesource]) values ('NBC News')
insert [dbo].[source] ([Namesource]) values ('CNN')
insert [dbo].[source] ([Namesource]) values ('CNN Español')
go

