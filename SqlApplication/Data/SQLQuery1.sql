
CREATE TABLE Addresses
(
	Id int not null identity primary key,
	StreetName nvarchar(max) not null,
	PostalCode varchar(6),
	City nvarchar(max) not null
)


CREATE TABLE Customers
(
	Id int not null identity primary key,
	FirstName nvarchar(max) not null,
	LastName nvarchar (max) not null,
	Email varchar (max),
	PhoneNumber varchar (10),
	AddressId int not null references Addresses(Id)
)

CREATE TABLE Companies
(
	Id int not null identity primary key,
	CompanyName nvarchar(max) not null 
)


CREATE TABLE Categories
(
	Id int not null identity primary key,
	CategoryName nvarchar(max) not null 
)


CREATE TABLE Products
(
	ArticleNumber nvarchar(max) not null,
	Title nvarchar(max) not null,
	Description nvarchar(max) null,
	Price money not null,
	CompanyId int not null references Companies(Id),
	CategoryId int not null references Categories(Id),
)