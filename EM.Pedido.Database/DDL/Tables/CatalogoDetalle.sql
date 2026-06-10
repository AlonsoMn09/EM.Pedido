CREATE TABLE [sch_configuracion].[CatalogoDetalle]
(
	[Id] INT NOT NULL PRIMARY KEY DEFAULT NEXT VALUE FOR seq_catalogo_detalle,
    [IdCatalogo] INT NOT NULL,
	[Codigo] VARCHAR(20) NOT NULL UNIQUE, 
    [Valor] VARCHAR(50) NULL,    
    [Estado] BIT NOT NULL DEFAULT 1, 
    [FechaCreacion] DATETIME NOT NULL DEFAULT Getdate(), 
    [UsuarioCreacion] VARCHAR(50) NOT NULL DEFAULT 'SqlServer', 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL, 
    CONSTRAINT [FK_CatalogoDetalle_ToCatalogo] FOREIGN KEY ([IdCatalogo]) REFERENCES [sch_configuracion].[catalogo](Id)
)
