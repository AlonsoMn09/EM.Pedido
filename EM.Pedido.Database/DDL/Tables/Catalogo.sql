CREATE TABLE [sch_configuracion].[Catalogo]
(
	[Id] INT NOT NULL PRIMARY KEY DEFAULT NEXT VALUE FOR seq_catalogo, 
    [Codigo] VARCHAR(20) NOT NULL UNIQUE, 
    [Nombre] VARCHAR(50) NULL, 
    [Descripcion] VARCHAR(200) NULL, 
    [Estado] BIT NOT NULL DEFAULT 1, 
    [FechaCreacion] DATETIME NOT NULL DEFAULT Getdate(), 
    [UsuarioCreacion] VARCHAR(50) NOT NULL DEFAULT 'SqlServer', 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL
)
