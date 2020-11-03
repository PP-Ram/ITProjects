CREATE TABLE  tbl_Album (
    AlbumID INT  NOT NULL, 
    AlbumName varchar(50),
    Artist varchar(50),
    Stock int,
    AlbumTypeID int,
	 PRIMARY KEY (AlbumID),
    FOREIGN KEY (AlbumTypeID) REFERENCES tbl_AlbumType(TypeID)
);
GO;
Create Table tbl_AlbumType(
	TypeID int,
	Code varchar(10),
	TypeDesc varchar(50),
	 PRIMARY KEY (TypeID),

);
GO;
/* Select all album*/
CREATE PROCEDURE SelectAllAlbum
AS
BEGIN
SELECT 
	al.AlbumID
	,al.AlbumName
	,al.Artist
	,al.Stock
	,al.AlbumTypeID
	,aty.Code
	,aty.TypeDesc
FROM 
	tbl_Album al
INNER JOIN tbl_albumType aty ON al.AlbumTypeID = aty.typeid
END
GO;


/* Select all album by ID*/
CREATE PROCEDURE SelectAlbumByID
	@AlbumID nvarchar(30)
AS
BEGIN
SELECT 
	al.AlbumID
	,al.AlbumName
	,al.Artist
	,al.Stock
	,al.AlbumTypeID
	,aty.Code
	,aty.TypeDesc
FROM 
	tbl_Album al
INNER JOIN tbl_albumType aty ON al.AlbumTypeID = aty.typeid
WHERE al.AlbumID = @AlbumID
END
GO;
/* Delete Album*/

Create Procedure sp_DeleteAlbum
	@AlbumID nvarchar(30)
AS
Begin
DELETE FROM tbl_album Where AlbumID=@AlbumID
END
GO;

Create Procedure sp_AddAlbum
	@AlbumName varchar(50),
    @Artist varchar(50),
    @Stock int,
    @AlbumTypeID int
AS
BEGIN
	Insert Into tbl_album( 
		AlbumName,
		Artist,
		Stock,
		AlbumTypeID)
	values
		( @AlbumName,
		@Artist,
		@Stock,
		@AlbumTypeID)
END
GO;

Create Procedure sp_UpdateAlbum
	@AlbumName varchar(50),
    @Artist varchar(50),
    @Stock int,
    @AlbumTypeID int,
	@AlbumID int
AS
BEGIN
	Update  tbl_album SET 
		AlbumName = @AlbumName,
		Artist = @Artist,
		Stock = @stock,
		AlbumTypeID =@AlbumTypeID
	WHERE 
		albumID = @AlbumID
END
GO;