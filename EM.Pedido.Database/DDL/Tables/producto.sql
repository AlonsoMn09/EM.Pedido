CREATE TABLE [sch_pedido].[Producto]
(
	[Id] INT NOT NULL PRIMARY KEY DEFAULT NEXT VALUE FOR seq_productos, 
    [Nombre] VARCHAR(50) NOT NULL, 
    [Descripcion] VARCHAR(200) NOT NULL, 
    [IdMarcaCat] INT NOT NULL, 
    [IdCategoriaCat] INT NOT NULL, 
    [PrecioUnitario] DECIMAL(18, 2) NOT NULL, 
    [Stock] INT NOT NULL, 
    [Estado] BIT NOT NULL DEFAULT 1, 
    [FechaCreacion] DATETIME NOT NULL DEFAULT Getdate(), 
    [UsuarioCreacion] VARCHAR(50) NOT NULL DEFAULT 'SqlServer', 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL, 
    CONSTRAINT [FK_Producto_ToMarca] FOREIGN KEY (IdMarcaCat) REFERENCES sch_configuracion.[CatalogoDetalle](Id), 
    CONSTRAINT [FK_Producto_ToCategoria] FOREIGN KEY (IdCategoriaCat) REFERENCES sch_configuracion.[CatalogoDetalle](Id)
)
