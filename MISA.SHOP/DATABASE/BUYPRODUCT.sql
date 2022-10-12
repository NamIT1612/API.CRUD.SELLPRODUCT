create database QL_MUAHANG
use QL_MUAHANG
create table CLIENT
(
IDCE int not null,
US nvarchar(50),
PW nvarchar(50),
NAME nvarchar(50),
NUMBERPHONE char(11),
BIRTHYEAR INT,
EMAIL nvarchar(50),
constraint pk_kh primary key(IDCE)
)

insert into CLIENT values 
(1,N'user',N'123',N'Nguyễn Nhựt Nam','0339906489',2001,N'nam@gmail.com')
insert into CLIENT values
(2,N'Nam',N'123',N'Nguyễn Nhựt Nam','0338924145',2000,N'NguyenNhutnam@gmail.com')
insert into CLIENT values 
(3,N'Namkk',N'123',N'Nguyễn Nhựt Nam','0939345071',1999,N'nam112@gmail.com')

select *from CLIENT


create table PRODUCT
(
IDPD int not null,
NAMEPD nvarchar(50),
PRICE int,
IMG NVARCHAR(50),
YEARPRODUCT INT,
CONSTRAINT PK_pd primary key(IDPD)
)
insert into PRODUCT values
(1,N'IPHONE 13 GREEN',20999099,'ip13G.jpg',2020)
insert into PRODUCT values
(2,N'IPHONE 13 BLUE',30999099,'ip13B.jpg',2020)
insert into PRODUCT values
(3,N'IPHONE 13 BLUA 2',25999099,'ip13B2.jpg',2020)
create table CART
(
	ID INT not null,
	IDCE INT not null,
	IDPD INT not null,
	SELLNUMBER INT,
	DATEBUY dateTime,
	STATUSCLIENT int,
	constraint pf_c primary key(ID),
	constraint fk_c1 foreign key(IDCE) references CLIENT(IDCE),
	constraint fk_c2 foreign key(IDPD) references PRODUCT(IDPD)
)
set dateformat dmy
select* from CART
insert into CART values
(1,1,2,2,'10/10/2022',0)
insert into CART values
(2,1,3,3,'10/10/2022',0)
