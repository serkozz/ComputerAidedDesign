CREATE TABLE Documents
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [document_name] VARCHAR(50) NOT NULL, 
    [document_creation_time] DATETIME NOT NULL, 
    [document_full_path] NVARCHAR(100) NOT NULL, 
    [document_byte_array] VARBINARY(MAX) NOT NULL
)
