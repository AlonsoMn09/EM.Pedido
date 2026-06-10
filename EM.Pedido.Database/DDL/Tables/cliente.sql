CREATE TABLE [sch_pedido].[Cliente]
(
	[Id] INT NOT NULL PRIMARY KEY DEFAULT NEXT VALUE FOR seq_clientes, 
    [RazonSocial] VARCHAR(100) NOT NULL, 
    [IdTipoDocumentoCat] INT NOT NULL, 
    [NumeroDocumento] CHAR(12) NOT NULL, 
    [Representante] VARCHAR(200) NOT NULL, 
    [Direccion] VARCHAR(200) NOT NULL, 
    [Email] VARCHAR(200) NOT NULL, 
    [Celular] CHAR(9) NOT NULL, 
    [IdRubroCat] INT NOT NULL, 
    [Estado] BIT NOT NULL DEFAULT 1, 
    [FechaCreacion] DATETIME NOT NULL DEFAULT GetDate(), 
    [UsuarioCreacion] VARCHAR(50) NOT NULL DEFAULT 'SqlServer', 
    [FechaModificacion] DATETIME NULL, 
    [UsuarioModificacion] VARCHAR(50) NULL, 
    CONSTRAINT [FK_cliente_ToCatalogoDetalle] FOREIGN KEY ([IdRubroCat]) REFERENCES sch_configuracion.[CatalogoDetalle](Id), 
    CONSTRAINT [FK_Cliente_ToTipoDocumento] FOREIGN KEY (IdTipoDocumentoCat) REFERENCES sch_configuracion.[CatalogoDetalle](Id)
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Tipo de documento del cliente',
    @level0type = N'SCHEMA',
    @level0name = N'sch_pedido',
    @level1type = N'TABLE',
    @level1name = N'Cliente',
    @level2type = N'COLUMN',
    @level2name = N'IdTipoDocumentoCat'